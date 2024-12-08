using static Application.Features.QuestionOptions.Constant.QuestionOptionMessages;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using Core.Application.Rules;
using MediatR;

namespace Application.Features.QuestionOptions.Rules;
public class QuestionOptionRules : BaseBusinessRules
{
    public QuestionOption Validate(QuestionOption? questionOption)
    {
        if (questionOption is null) throw new NotFoundException(NotFound);
        return questionOption;
    }

    public void EnsureCorrectAnswerFirst(IList<QuestionOption> questionOptions, bool isAnswer)
    {
        if (!questionOptions.Any() && isAnswer == false)
        {
            throw new BusinessException(CorrectAnswerFirst);
        }
    }

    public void CheckSecondaryAnswer(IList<QuestionOption> questionOptions, bool isAnswer)
    {
        if (questionOptions.Any() && isAnswer == true)
        {
            throw new BusinessException(OnlyOneCorrectAnswer);
        }
    }
}
