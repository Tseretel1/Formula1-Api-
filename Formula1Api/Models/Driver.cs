using System.ComponentModel.DataAnnotations.Schema;

namespace Formula1Api.Models
{
    public class Driver
    {
        public int ID { get; set; } 
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Titles { get; set; }
        public int TeamID { get; set; }
        public string DriverPhoto { get; set; }
        public int Points { get; set; }
        public int Age { get; set; }
        public string Nationality { get; set; }

        [NotMapped]
        public IFormFile Driver_Photo_Upload { get; set; }
    }
}
