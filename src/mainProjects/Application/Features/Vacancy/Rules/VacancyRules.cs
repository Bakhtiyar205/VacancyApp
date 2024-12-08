using static Application.Features.Vacancies.Constant.VacancyMessages;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;

namespace Application.Features.Vacancies.Rules;
public class VacancyRules : BaseBusinessRules
{
    public Vacancy Validate(Vacancy? vacancy)
    {
        if (vacancy is null) throw new NotFoundException(NotFound);
        return vacancy;
    }

    public void CheckExistence(Vacancy? vacancy)
    {
        if (vacancy is not null) throw new BusinessException(AlreadyExist);
    }
}
