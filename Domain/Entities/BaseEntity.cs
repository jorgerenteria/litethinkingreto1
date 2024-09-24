using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;
public class BaseEntity
{
    public Guid id { get; set; }
}
