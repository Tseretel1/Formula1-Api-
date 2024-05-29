using Formula1Api.Formula_Dtos;
using Formula1Api.Interfaces;
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
        public IActionResult AddNewDrover(DriversDTO dto)
        {
            _admin.AddDriver(dto);
            if(ModelState.IsValid && ModelState!= null)
            {
                return Ok("Driver has been added");
            }
            else
            {
                return BadRequest("something went wrong");
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
            catch (Exception ex)
            {
                return BadRequest("Something went wrong");
            }
        }


    }
}
