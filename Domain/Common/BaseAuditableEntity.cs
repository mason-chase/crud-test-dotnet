namespace Domain.Common;

public abstract class BaseAuditableEntity : BaseEntity
{
    public DateTime CreatedDate { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    public int? LastModifiedBy { get; set; }
}
