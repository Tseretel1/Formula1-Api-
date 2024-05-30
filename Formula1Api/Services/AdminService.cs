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
        public void AddDriver(Driver driver)
        {
            try
            {
                if (driver != null)
                {
                    _context.Drivers.Add(driver);
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
