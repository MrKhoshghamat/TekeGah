using System.ComponentModel.DataAnnotations;

namespace TekeGah.Domain.Entities.Common;

public class BaseEntity
{
    [Key] public Guid Id { get; set; } 
    public DateTime CreationDate { get; set; } = DateTime.Now;
    public string? CreatedBy { get; set; } 
    public DateTime ModificationDate { get; set; }
    public string? ModifiedBy { get; set; }
    public bool IsDeleted { get; set; } = false;
}