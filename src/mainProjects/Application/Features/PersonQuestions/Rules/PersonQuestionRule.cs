using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;

namespace Application.Features.PersonQuestions.Rules;
public class PersonQuestionRule : BaseBusinessRules
{
    public PersonQuestion Validate(PersonQuestion? personQuestion)
    {
        if (personQuestion is null) throw new NotFoundException("PersonQuestion not found");

        return personQuestion;
    }
}
