﻿namespace Domain.Entities;
public class QuestionOption : AuditableEntity
{
    public string Option { get; set; } = default!;
    public bool IsAnswer { get; set; }
    public int QuestionId { get; set; }
    public Question Question { get; set; } = default!;
}
