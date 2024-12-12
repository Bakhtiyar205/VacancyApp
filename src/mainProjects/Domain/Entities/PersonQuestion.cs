namespace Domain.Entities;
public class PersonQuestion : Entity
{
    public int PersonId { get; set; }
    public Person Person { get; set; } = default!;
    public int QuestionId { get; set; }
    public Question Question { get; set; } = default!;
    public int VacancyId { get; set; }
    public Vacancy Vacancy { get; set; } = default!;
    public bool IsChecked { get; set; }
    public int AnswerId { get; set; }

}
