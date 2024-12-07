namespace Domain.Entities;
public class PersonVacancy : Entity
{
    public int VacancyId { get; set; }
    public Vacancy Vacancy { get; set; } = default!;
    public int PersonId { get; set; }
    public Person Person { get; set; } = default!;
}
