namespace HouseOflaw.API.Models
{
    public class Photo
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public User User { get; set; }

        public double UserCode { get; set; }
    }
}
