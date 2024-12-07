namespace Domain.Entities;
public class Question : Entity
{
    public string QuestionDetail { get; set; } = default!;
    public int VacancyId { get; set; }
    public Vacancy Vacancy { get; set; } = default!;
    public int OptionCount { get; set; }
    public ICollection<QuestionOption> QuestionOptions { get; set; } = new List<QuestionOption>();
    public ICollection<PersonQuestion> PersonQuestions { get; set; } = new List<PersonQuestion>();
}
