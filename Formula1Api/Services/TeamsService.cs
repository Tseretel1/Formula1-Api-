using Formula1Api.Data;
using Formula1Api.Formula_Dtos;
using Formula1Api.Interfaces;
using Formula1Api.Models;

namespace Formula1Api.Services
{
    public class TeamsService : TeamInterFace
    {
        private readonly FormulaDbContext _context;
        public TeamsService (FormulaDbContext context)
        {
            _context = context;
        }
        public ICollection<TeamsDTO> AllTeams()
        {
            var teams = _context.Teams.ToList();
            var Dto = new List<TeamsDTO>();
            foreach (var team in teams)
            {
                var Team = new TeamsDTO()
                {
                    TeamName = team.TeamName,
                    TeamTitleCount = team.TitleCount,
                };
                Dto.Add(Team);
            }
            return Dto;
        }
        public ICollection<Team> Filter_ByTitles()
        {
            return _context.Teams.OrderByDescending(u=>u.TitleCount).ToList();
        }

        public ICollection<Team> GetTeamsByName(string Name)
        {
            return _context.Teams.Where(u=>u.TeamName.Contains(Name)).ToList();
        }
    }
}
