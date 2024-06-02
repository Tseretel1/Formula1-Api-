namespace Formula1Api.Formula_Dtos
{
    public class DriversAndTeamsDTO
    {
        public int DriverID { get; set; }
        public string DriverName { get; set; }
        public string DriverLastName { get; set; }
        public int DriverTitles { get; set; }
        public int DriverPoints { get; set; }
        public int DriverAge { get; set; }
        public string DriverNationality { get; set; }
        public string DriverPhoto { get; set; }
        public string TeamName { get; set; }
        public int TeamTitleCount { get; set; }
        public string TeamPhoto { get; set; }
    }
}
