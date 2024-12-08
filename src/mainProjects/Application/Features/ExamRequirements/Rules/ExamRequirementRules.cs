using Core.Application.Rules;
using static Application.Features.ExamRequirements.Constant.ExamRequirementMessages;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;

namespace Application.Features.ExamRequirements.Rules;
public class ExamRequirementRules : BaseBusinessRules
{
    public ExamRequirement Validate(ExamRequirement? entity)
    {
        if (entity is null)
        {
            throw new NotFoundException(NotFound);
        }
        return entity;
    }
}
