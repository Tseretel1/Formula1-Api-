using Formula1Api.Formula_Dtos;

namespace Formula1Api.Interfaces
{
    public interface AdminInterface
    {
        void AddDriver(DriversDTO dto);
        void DeleteDriver(int id);
        void UpdateDriver();
        void AddTeam();
        void DeleteTeam();
        void UpdateTeam();
    }
}
