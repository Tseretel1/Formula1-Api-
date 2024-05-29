using Formula1Api.Interfaces;
using Formula1Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Formula1Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : Controller
    {
        private readonly DriversInterFace _driver;
        public DriversController(DriversInterFace driver)
        {
            _driver = driver;
        }
        [HttpGet("/All drivers")]
        public IActionResult AllDrivers()
        {
            var Driver = _driver.AllDrivers();

            if (Driver == null || !Driver.Any())
                return NotFound();
            return Ok(Driver);
        }
        [HttpGet("/Filter Driver By Name")]
        public IActionResult AllDriversByName(string Name)
        {
            var Driver = _driver.DriverFullInfo(Name);

            if (Driver == null || !Driver.Any())
                return NotFound();
            return Ok(Driver);
        }
        [HttpGet("/Filter Driver By Points")]
        public IActionResult FilterPoints()
        {
            var Driver = _driver.FilterByPoints();

            if (Driver == null || !Driver.Any())
                return NotFound();
            return Ok(Driver);
        }
        [HttpGet("/Filter Driver By Titles")]
        public IActionResult FilterTitles()
        {
            var Driver = _driver.FilterByTitles();

            if (Driver == null || !Driver.Any())
                return NotFound();
            return Ok(Driver);
        }
        [HttpGet("/All Drivers And Teams")]
        public IActionResult DriversAndTeams()
        {
            var Drivers = _driver.DriversAndTeams();

            if (Drivers == null || !Drivers.Any())
                return NotFound();
            return Ok(Drivers);
        }
    }
}
