using Application.Features.QuestionOptions.Command.Create;
using Application.Features.QuestionOptions.Command.Update;
using Application.Features.QuestionOptions.Dto;
using Application.Features.QuestionOptions.Dto.ForPersonQuestion;
using Application.Features.QuestionOptions.Model;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.QuestionOptions.Profiles;
public class QuestionOptionProfiles : Profile
{
    public QuestionOptionProfiles()
    {
        CreateMap<QuestionOption, GetQuestionOptionDto>();

        CreateMap<QuestionOption, QuestionOptionListDto>()
            .ForMember(m => m.QuestionName, opt => opt.MapFrom(src => src.Question.QuestionDetail));

        CreateMap<IPaginate<QuestionOption>, QuestionOptionListModel>();

        CreateMap<CreateQuestionOptionCommand, QuestionOption>();
        CreateMap<UpdateQuestionOptionCommand, QuestionOption>();

        CreateMap<QuestionOption, CreateQuestionOptionDto>();
        CreateMap<QuestionOption, UpdateQuestionOptionDto>();

        CreateMap<QuestionOption, OptionForPersonDto>();


    }
}
