using Application.Features.Questions.Command.Create;
using Application.Features.Questions.Command.Update;
using Application.Features.Questions.Dto;
using Application.Features.Questions.Model;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Questions.Profiles;
public class QuestionProfiles : Profile
{
    public QuestionProfiles()
    {
        CreateMap<Question, GetQuestionDto>();
        CreateMap<Question, QuestionListDto>();
        CreateMap<IPaginate<Question>, QuestionListModel>();
        CreateMap<CreateQuestionCommand, Question>();
        CreateMap<UpdateQuestionCommand, Question>();

        CreateMap<Question, CreateQuestionDto>();
        CreateMap<Question, UpdateQuestinDto>();
    }
}
