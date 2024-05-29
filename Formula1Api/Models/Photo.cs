namespace Formula1Api.Models
{
    public class Photo
    {
        public int ID { get; set; } 
        public int? TeamID { get; set; }
        public string Path { get; set; }
        public string PathToDisplay { get; set; }
        public int Type { get; set; }
        public int? DriverId { get; set; }
    }
}
