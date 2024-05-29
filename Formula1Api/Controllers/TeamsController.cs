using Formula1Api.Interfaces;
using Formula1Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Formula1Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : Controller
    {
        private readonly TeamInterFace _teams;
        public TeamsController (TeamInterFace teamInterFace)
        {
            _teams = teamInterFace;
        }
        [HttpGet("/All Teams")]
        public IActionResult AllTeams()
        {
            var teams = _teams.AllTeams();

            if (teams == null || !teams.Any())
                return NotFound();
            return Ok(teams);
        }
        [HttpGet("/Teams By Name")]
        public IActionResult TeamsByName(string Name)
        {
            var teams = _teams.GetTeamsByName(Name);
            if (teams == null || !teams.Any())
                return NotFound();
            return Ok(teams);
        }
        [HttpGet("/Team Filter By Titles")]
        public IActionResult FilterbyTitles()
        {

            var teams = _teams.Filter_ByTitles();

            if (teams == null || !teams.Any())
                return NotFound();
            return Ok(teams);
        }
    }
}
