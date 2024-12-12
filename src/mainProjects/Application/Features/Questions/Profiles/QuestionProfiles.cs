using Application.Features.Questions.Command.Create;
using Application.Features.Questions.Command.Update;
using Application.Features.Questions.Dto;
using Application.Features.Questions.Dto.ForPersonQuestion;
using Application.Features.Questions.Model;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Questions.Profiles;
public class QuestionProfiles : Profile
{
    public QuestionProfiles()
    {
        CreateMap<Question, GetQuestionDto>()
            .ForMember(m => m.VacancyName, opt => opt.MapFrom(src => src.Vacancy.Title));
        CreateMap<Question, QuestionListDto>()
            .ForMember(m => m.VacancyName, opt => opt.MapFrom(src => src.Vacancy.Title));
        CreateMap<IPaginate<Question>, QuestionListModel>();
        CreateMap<CreateQuestionCommand, Question>();
        CreateMap<UpdateQuestionCommand, Question>();

        CreateMap<Question, CreateQuestionDto>();
        CreateMap<Question, UpdateQuestinDto>();

        CreateMap<Question, QuestionForPersonDto>();
    }
}
