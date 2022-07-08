using ToDoService.Entities;
using ToDoService.Protos;
using ToDoService.Repositories;
using Grpc.Core;
using System.Threading.Tasks;
using AutoMapper;

namespace ToDoService.Services
{
    public class MissionService : MissionProtoService.MissionProtoServiceBase
    {
        private readonly IMissionRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public MissionService(ILogger<MissionService> logger, IMissionRepository repository, IMapper mapper)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            SeedData();
        }

        private async Task SeedData()
        {
            var missions =  await _repository.GetMissions();
            if (!missions.Any())
            {
                await _repository.CreateMissions(new Mission { Id = 1, Title = "Ayman Task" });
            }
        }

        public override async Task<GetMissionModelResponse> GetMission(GetMissionModelRequest request, ServerCallContext context)
        {
            GetMissionModelResponse model = new GetMissionModelResponse();
            var messions = _mapper.Map<IEnumerable<MissionModel>>(await _repository.GetMissions());
            model.Mission.AddRange(messions);
            _logger.LogInformation("Get Missions Done");
            return model;
        }

        public override async Task<MissionModel> CreateMission(CreateMissionRquest request, ServerCallContext context)
        {
            Mission model = _mapper.Map<Mission>(request.Mission);
            var result = await _repository.CreateMissions(model);
            _logger.LogInformation("Missions Added.");
            return _mapper.Map<MissionModel>(result);
        }

    }
}
