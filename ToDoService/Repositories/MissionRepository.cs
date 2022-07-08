using Microsoft.EntityFrameworkCore;
using ToDoService.Data;
using ToDoService.Entities;

namespace ToDoService.Repositories
{
    public class MissionRepository : IMissionRepository
    {
        private readonly DataContext _db;
        public MissionRepository(DataContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<Mission>> GetMissions()
        {
            return await _db.Missions.ToListAsync();
        }
        public async Task<Mission?> GetMissionsById(int id)
        {
            return await _db.Missions.FindAsync(id) ?? null;
        }

        public async Task<Mission> CreateMissions(Mission model)
        {
            await _db.Missions.AddAsync(model);
            await _db.SaveChangesAsync();
            return model;
        }

        public async Task UpdateMissions(Mission model)
        {
            var entity = await _db.Missions.FindAsync(model.Id);
            if (entity == null)
            {
                throw new KeyNotFoundException("Mission not found");
            }
            entity.Title = model.Title;
            _db.Missions.Update(entity);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteMissions(int id)
        {
            var entity = await _db.Missions.FindAsync(id);
            if (entity == null)
            {
                throw new KeyNotFoundException("Mission not found");
            }
            _db.Missions.Remove(entity);
            await _db.SaveChangesAsync();
        }
    }
}
