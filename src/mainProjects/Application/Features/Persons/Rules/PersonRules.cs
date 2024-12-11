using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;

namespace Application.Features.Persons.Rules;
public class PersonRules : BaseBusinessRules
{
    public Person Validate(Person? person)
    {
        if (person == null) throw new NotFoundException("Person not found");
        return person;
    }

    public void CheckExistence(Person? person)
    {
        if (person != null) throw new BusinessException("Person already exists");
    }

    public void IsAgreeExam(bool isAgree)
    {
        if (!isAgree) throw new BusinessException("You can not apply to this exam");
    }

    public void IsPersonVacancyExist(PersonVacancy? personVacancy)
    {
        if (personVacancy == null) throw new BusinessException("You can not participate this exam");
    }
}
