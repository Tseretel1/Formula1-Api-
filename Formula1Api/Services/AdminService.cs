using Formula1Api.Data;
using Formula1Api.Formula_Dtos;
using Formula1Api.Interfaces;
using Formula1Api.Models;

namespace Formula1Api.Services
{
    public class AdminService : AdminInterface
    {
        private readonly FormulaDbContext _context;
        public AdminService(FormulaDbContext context)
        {
            _context = context;
        }
        public void AddDriver(DriversDTO dto)
        {
            try
            {
                if (dto != null) {
                    var Driver = new Driver
                    {
                        Name = dto.DriverName,
                        LastName = dto.DriverLastName,
                        Titles = dto.DriverTitles,
                        Age = dto.DriverAge,
                        DriverPhoto = dto.DriverPhoto,
                        Nationality = dto.DriverNationality,
                        Points = dto.DriverPoints,
                        TeamID = dto.TeamID
                    };
                    _context.Drivers.Add(Driver);
                    _context.SaveChanges();
                }
            }
            catch(Exception ex)
            {
            }
            
        }
        public enum DeleteResult
        {
            Success,
            NotFound,
            Error
        }
        public void DeleteDriver(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ArgumentException("Invalid ID");
                }

                var driver = _context.Drivers.FirstOrDefault(x => x.ID == id);
                if (driver == null)
                {
                    throw new KeyNotFoundException("Driver not found with the given ID");
                }

                _context.Drivers.Remove(driver);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public void AddTeam()
        {
            throw new NotImplementedException();
        }
        public void DeleteTeam()
        {
            throw new NotImplementedException();
        }

        public void UpdateDriver()
        {
            throw new NotImplementedException();
        }

        public void UpdateTeam()
        {
            throw new NotImplementedException();
        }
    }
}
