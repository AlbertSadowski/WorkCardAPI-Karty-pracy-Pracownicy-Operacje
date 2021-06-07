using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkCardAPI.Entities;
using WorkCardAPI.Models;

namespace WorkCardAPI
{
    public class WorkCardMappingProfile : Profile 
    {
        public WorkCardMappingProfile()
        {
            CreateMap<WorkCard, WorkCardDto>()
                .ForMember(w => w.Name, n => n.MapFrom(k => k.Employee.Name))
                .ForMember(w => w.Description, n => n.MapFrom(k => k.Employee.Description))
                .ForMember(w => w.Category, n => n.MapFrom(k => k.Employee.Category));

            CreateMap<Operation, OperationDto>();

            CreateMap<CreateWorkCardDto,WorkCard>()
                .ForMember(w => w.Employee, n => n.MapFrom(dto => new Employee(){ Name = dto.Name, Description = dto.Description, Category = dto.Category}));

            CreateMap<CreateOperationDto, Operation>();
                
        }
    }
}
