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

    public void CheckList(IList<QuestionOption> questionOptions, string message)
    {
        if (questionOptions.Any()) throw new BusinessException(message);
    }

    public void QuestionLimit(IList<int> questionOptionIds,int questionOptionCount, int id)
    {
        if (id == 0 && questionOptionCount == questionOptionIds.Count())
        {
            throw new BusinessException(QuestionLimitErrorMessage);
        }

        if (id != 0 && !questionOptionIds.Contains(id) && questionOptionCount == questionOptionIds.Count())
        {
            throw new BusinessException(QuestionLimitErrorMessage);
        }
    }
}
