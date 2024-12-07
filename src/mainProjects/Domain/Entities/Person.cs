namespace Domain.Entities;
public class Person : Entity
{
    public string Name { get; set; } = default!;
    public string Surname { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public int Point { get; set; }
    public bool ExamRequirmentAgreement { get; set; }
    public bool IsParticipated { get; set; }
    public string? CvPath { get; set; }
    public DateTime? ExamStartDate { get; set; }
    public DateTime? ExamEndDate { get; set; }
    public ICollection<PersonVacancy> PersonVacancies { get; set; } = new List<PersonVacancy>();
    public ICollection<PersonQuestion> PersonQuestions { get; set; } = new List<PersonQuestion>();
}
