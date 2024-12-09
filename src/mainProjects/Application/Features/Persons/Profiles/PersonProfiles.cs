using Application.Features.Persons.Command.Create;
using Application.Features.Persons.Dto;
using Application.Features.Persons.Model;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Persons.Profiles;
public class PersonProfiles : Profile
{
    public PersonProfiles()
    {
        CreateMap<CreatePersonCommand, Person>();

        CreateMap<Person, CreatePersonDto>();

        CreateMap<Person, GetPersonDto>();

        CreateMap<Person, PersonListDto>();

        CreateMap<IPaginate<Person>, PersonListModel>();
    }
}
