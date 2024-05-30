using Formula1Api.Formula_Dtos;
using Formula1Api.Models;

namespace Formula1Api.Interfaces
{
    public interface AdminInterface
    {
        void AddDriver(Driver driver);
        void DeleteDriver(int id);
        void UpdateDriver(Driver driver);
        void AddTeam(Team team);
        void DeleteTeam(int id);
        void UpdateTeam(Team team);
    }
}
