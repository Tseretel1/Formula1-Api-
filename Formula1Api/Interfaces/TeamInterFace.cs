using Formula1Api.Formula_Dtos;
using Formula1Api.Models;

namespace Formula1Api.Interfaces
{
    public interface TeamInterFace
    {
        ICollection <TeamsDTO> AllTeams();
        ICollection <Team> GetTeamsByName(string Name);
        ICollection<Team> Filter_ByTitles();
    }
}
