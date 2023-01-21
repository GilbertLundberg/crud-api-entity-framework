using Company.Data.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Company.Data.Entities;

public class Division : IEntity
{
    public int Id { get; set; }

    [MaxLength(50), Required]
    public string Name { get; set; }

    [Required]
    public int CompanyId { get; set; }

    public virtual CompanyTable? Company { get; set; }

   
}
