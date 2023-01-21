using Company.Data.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Company.Data.Entities;

public class CompanyTable : IEntity
{
    public int Id { get; set; }

    [MaxLength(50), Required]
    public string Name { get; set; }

    [MaxLength(50), Required]
    public string OrgNumber { get; set; }
}
