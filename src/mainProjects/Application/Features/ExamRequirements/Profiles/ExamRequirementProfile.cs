using Domain.Entities;
using AutoMapper;
using System.Runtime.CompilerServices;
using Application.Features.ExamRequirements.Dto;
using Core.Persistence.Paging;
using Application.Features.ExamRequirements.Model;
using Application.Features.ExamRequirements.Command.Create;
using Application.Features.ExamRequirements.Command.Update;

namespace Application.Features.ExamRequirements.Profiles;
public class ExamRequirementProfile : Profile
{
    public ExamRequirementProfile()
    {
        CreateMap<ExamRequirement, GetExamRequirementDto>();
        CreateMap<ExamRequirement, ExamRequiementListDto>();
        CreateMap<IPaginate<ExamRequirement>, ExamRequirementListModel>();
        CreateMap<ExamRequirement, CreateExamRequirementDto>();
        CreateMap<ExamRequirement, UpdateExamRequirementDto>();

        CreateMap<CreateExamRequirementCommand, ExamRequirement>();
        CreateMap<UpdateExamRequirementCommand, ExamRequirement>();

    }
}
