using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoApi.Entities;
using ToDoApi.Repositories;

namespace ToDoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionController : ControllerBase
    {
        private readonly IMissionRepository _repository;
        public MissionController(IMissionRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mission>>> Get()
        {
            return Ok(await _repository.GetMissions()) ;
        }
        
        [HttpPost]
        public async Task<ActionResult<Mission>> Post(Mission model)
        {
            return Ok(await _repository.CreateMissions(model)) ;
        }
    }
}
