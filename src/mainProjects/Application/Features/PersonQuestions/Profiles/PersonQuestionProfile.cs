using Application.Features.PersonQuestions.Dto;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.PersonQuestions.Profiles;
public class PersonQuestionProfile : Profile
{
    public PersonQuestionProfile()
    {
        CreateMap<PersonQuestion, PersonQuestionDto>();
    }
}
