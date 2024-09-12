namespace Backend.Models
{
    public class Provider
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Specialization { get; set; }
        public List<Availability> Availability { get; set; }
    }
    public class Availability
    {
        public string Day { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }

}
