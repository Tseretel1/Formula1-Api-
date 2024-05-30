using Formula1Api.Formula_Dtos;
using Formula1Api.Interfaces;
using Formula1Api.Models;
using Microsoft.AspNetCore.Mvc;
using static Formula1Api.Services.AdminService;

namespace Formula1Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : Controller
    {
        private readonly AdminInterface _admin;
        public AdminController(AdminInterface admin)
        {
            _admin = admin;
        }
        [HttpPost("/Add New Driver")]
        public IActionResult AddNewDrover(Driver driver)
        {        
            try
            {
                _admin.AddDriver(driver);
                return Ok("Driver has been Added");
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong");
            }
        }
        [HttpPost("/DeleteDriver")]
        public IActionResult DeleteDriver(int id)
        {
            try
            {
                _admin.DeleteDriver(id);
                return Ok("Driver has been deleted");
            }
            catch (ArgumentException ex)
            {
                return BadRequest("Invalid ID");
            }
            catch (KeyNotFoundException ex)
            {
                
                return NotFound("Driver not found with the given ID");
            }
        }
        [HttpPost("/Update Driver")]
        public IActionResult UpdateDriver(Driver driver)
        {
            try
            {
                _admin.UpdateDriver(driver);
                return Ok("Driver has been updated");
            }
            catch (ArgumentException ex)
            {
                return BadRequest("Something went wrong updating person");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound("Driver not found with the given ID");
            }
        }
        [HttpPost("/Add New Team")]
        public IActionResult AddnewTeam(Team team)
        {
            try
            {
                _admin.AddTeam(team);
                return Ok("Team has been Added");
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong");
            }
        }
        [HttpPost("/delete Team")]
        public IActionResult DeleteTeam(int id)
        {
            try
            {
                _admin.DeleteTeam(id);
                return Ok("Team has been deleted");
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong");
            }
        }
        [HttpPost("/Update Team")]
        public IActionResult Updateteam(Team team)
        {
            try
            {
                _admin.UpdateTeam(team);
                return Ok("Team has been updated");
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong");
            }
        }
    }
}
