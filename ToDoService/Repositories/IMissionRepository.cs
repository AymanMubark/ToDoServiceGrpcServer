using ToDoService.Entities;

namespace ToDoService.Repositories
{
    public interface IMissionRepository
    {
        Task<IEnumerable<Mission>> GetMissions();
        Task<Mission?> GetMissionsById(int id);
        Task<Mission> CreateMissions(Mission model);
        Task UpdateMissions(Mission model);
        Task DeleteMissions(int id);
    }
}
