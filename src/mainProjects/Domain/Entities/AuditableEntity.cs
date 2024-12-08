namespace Domain.Entities;
public abstract class AuditableEntity : Entity
{
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public bool IsDeleted { get; set; }
}
