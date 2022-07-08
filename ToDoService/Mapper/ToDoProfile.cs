using AutoMapper;
using ToDoService.Entities;
using ToDoService.Protos;

namespace ToDoService.Mapper
{
    public class ToDoProfile : Profile
    {
        public ToDoProfile()
        {
            CreateMap<Mission, MissionModel>().ReverseMap();
        }
    }
}
