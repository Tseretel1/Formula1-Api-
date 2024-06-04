using Formula1Api.Data;
using Formula1Api.Formula_Dtos;
using Formula1Api.Interfaces;
using Formula1Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Formula1Api.Services
{
    public class AdminService : AdminInterface
    {
        private readonly FormulaDbContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public AdminService(FormulaDbContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }
        public void AddDriver(Driver driver, IFormFile driver_Photo_Upload)
        {
            try
            {   if (driver != null)
                {
                    if (driver.Driver_Photo_Upload != null && driver.Driver_Photo_Upload.Length > 0)
                    {
                        string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath + "/" + "Photos/Drivers");
                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + driver.Driver_Photo_Upload.FileName;
                        string PattoDisplay = $"/Photos/Drivers/{uniqueFileName}";
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            driver.Driver_Photo_Upload.CopyTo(stream);
                        }
                        string localhostString = "https://localhost:7197";
                        var NewDriver = new Driver
                        {
                            Age = driver.Age,
                            Name = driver.Name,
                            LastName = driver.Name,
                            DriverPhoto = localhostString + PattoDisplay,
                            Nationality = driver.Nationality,
                            Points = driver.Points,
                            TeamID = driver.TeamID,
                            Titles = driver.Titles,
                        };
                        _context.Drivers.Add(NewDriver);
                        _context.SaveChanges();
                    }
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
        public void UpdateDriver(Driver driver)
        {
            if (driver != null)
            {
                _context.Drivers.Update(driver);
                _context.SaveChanges();
            }
        }
        public void AddTeam(Team team)
        {
            if (team != null)
            {
                _context.Teams.Add(team);
                _context.SaveChanges();
            }
        }
        public void DeleteTeam(int id )
        {
            var team = _context.Teams.FirstOrDefault(x => x.ID == id);
            if (team != null)
            {
                _context.Teams.Remove(team);
                _context.SaveChanges();
            }
        }
        public void UpdateTeam(Team team)
        {
            if (team != null && team.ID!=null)
            {
                _context.Teams.Update(team);
                _context.SaveChanges();
            }
        }
    }
}
