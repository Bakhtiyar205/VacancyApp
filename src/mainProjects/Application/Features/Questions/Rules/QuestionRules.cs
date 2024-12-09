using static Application.Features.Questions.Constant.QuestionMessages;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;

namespace Application.Features.Questions.Rules;
public class QuestionRules : BaseBusinessRules  
{
    public Question Validate(Question? question)
    {
        if (question is null) throw new NotFoundException(NotFound);
        return question;
    }

    public void CheckList(IList<Question> questionList,string message)
    {
        if(questionList.Any()) throw new BusinessException(message);
    }
}
