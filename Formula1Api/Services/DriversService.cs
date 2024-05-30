using Formula1Api.Data;
using Formula1Api.Formula_Dtos;
using Formula1Api.Interfaces;
using Formula1Api.Models;

namespace Formula1Api.Services
{
    public class DriversService : DriversInterFace
    {
        private readonly FormulaDbContext _context;
        public DriversService(FormulaDbContext context)
        {
            _context = context;
        }

        public ICollection<Driver> AllDrivers()
        {
            return _context.Drivers.ToList();;
        }

        public ICollection<Driver> DriverFullInfo(string Name)
        {
            return _context.Drivers.Where(i => i.Name.Contains(Name) || i.LastName.Contains(Name)).ToList();  
        }
        public ICollection<DriversAndTeamsDTO> FilterByPoints()
        {
            var sortedDrivers = _context.Drivers.OrderByDescending(driver => driver.Points).ToList();
            var dtos = new List<DriversAndTeamsDTO>();
            string fullpath = "https://localhost:7197/Filter%20Driver%20By%20Points";
            foreach (var driver in sortedDrivers)
            {
                var dto = new DriversAndTeamsDTO
                {
                    DriverName = driver.Name,
                    DriverLastName = driver.LastName,
                    DriverAge = driver.Age,
                    DriverNationality =driver.Nationality,
                    DriverTitles = driver.Titles,
                    DriverPhoto = fullpath + "/"+ driver.DriverPhoto,
                    DriverPoints = driver.Points,
                    DriverID =driver.ID,
                };
                dtos.Add(dto);
            }
            return dtos;
        }
        public ICollection<DriversAndTeamsDTO> FilterByTitles()
        {
            var sortedDrivers = _context.Drivers.OrderByDescending(driver => driver.Titles).ToList();
            var dtos = new List<DriversAndTeamsDTO>();

            foreach (var driver in sortedDrivers)
            {
                var dto = new DriversAndTeamsDTO
                {
                    DriverName = driver.Name,
                    DriverLastName = driver.LastName,
                    DriverAge = driver.Age,
                    DriverNationality = driver.Nationality,
                    DriverTitles = driver.Titles,
                    DriverPhoto = driver.DriverPhoto,
                    DriverPoints = driver.Points,
                    DriverID = driver.ID,
                };
                dtos.Add(dto);
            }
            return dtos;
        }
        public ICollection<DriversAndTeamsDTO> DriversAndTeams()
        {
            var driversAndTeams = (from driver in _context.Drivers
                                   join team in _context.Teams on driver.TeamID equals team.ID
                                   select new DriversAndTeamsDTO
                                   {
                                       DriverName = driver.Name,
                                       DriverLastName = driver.LastName,
                                       DriverTitles = driver.Titles,
                                       DriverPoints = driver.Points,
                                       DriverAge = driver.Age,
                                       DriverNationality = driver.Nationality,
                                       TeamName = team.TeamName,
                                       TeamTitleCount = team.TitleCount,
                                       DriverPhoto = driver.DriverPhoto,
                                       DriverID = driver.ID
                                   }).ToList();
            return driversAndTeams;
        }

    }
}
