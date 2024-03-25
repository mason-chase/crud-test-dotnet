namespace Mc2.CrudTest.Domain.Models;

public class BaseModel
{
    public DateTime CreatedAt { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime UpdatedAt { get; set; }
}