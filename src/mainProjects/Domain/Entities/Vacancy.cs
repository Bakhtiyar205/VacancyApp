namespace Domain.Entities;
public class Vacancy : AuditableEntity
{
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public int ExamQuestionCount { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public ICollection<PersonVacancy> PersonVacancies { get; set; } = new List<PersonVacancy>();
    public ICollection<Question> Questions { get; set; } = new List<Question>();
    public ICollection<PersonQuestion> PersonQuestions { get; set; } = new List<PersonQuestion>();
}
