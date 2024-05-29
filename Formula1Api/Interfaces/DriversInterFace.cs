using Formula1Api.Formula_Dtos;
using Formula1Api.Models;

namespace Formula1Api.Interfaces
{
    public interface DriversInterFace
    {
        public ICollection<Driver> DriverFullInfo(string Name);
        public ICollection<Driver> AllDrivers();
        
        public ICollection<DriversAndTeamsDTO> FilterByTitles();
        public ICollection<DriversAndTeamsDTO> FilterByPoints();
        public ICollection<DriversAndTeamsDTO> DriversAndTeams();
    }
}
