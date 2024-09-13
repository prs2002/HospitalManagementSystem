using Backend.Models;
using Backend.Repositories;
using Backend.Service;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));

            // Register MongoDbSettings as a singleton
            builder.Services.AddSingleton(sp =>
            {
                return sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
            });

            // Register the MongoClient instance
            builder.Services.AddSingleton<IMongoClient, MongoClient>(sp =>
            {
                var settings = sp.GetRequiredService<MongoDbSettings>();
                if (string.IsNullOrEmpty(settings.ConnectionString))
                {
                    throw new ArgumentNullException(nameof(settings.ConnectionString), "MongoDB connection string is not configured properly.");
                }
                return new MongoClient(settings.ConnectionString);
            });

            // Register MongoDatabase instance
            builder.Services.AddScoped(sp =>
            {
                var client = sp.GetRequiredService<IMongoClient>();
                var settings = sp.GetRequiredService<MongoDbSettings>();
                return client.GetDatabase(settings.DatabaseName);
            });


            builder.Services.AddControllers();

            builder.Services.AddScoped<IRepo<User>, UserRepo>();
            builder.Services.AddScoped<IRepo<Provider>, ProviderRepo>();
            builder.Services.AddScoped<IRepo<Appointment>, AppointmentRepo>();

            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IProviderService, ProviderService>();
            builder.Services.AddScoped<IAppointmentService, AppointmentService>();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}