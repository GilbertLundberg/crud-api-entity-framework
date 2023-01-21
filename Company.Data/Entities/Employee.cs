using Company.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Company.Data.Entities;

public class Employee : IEntity
{
    public int Id { get; set; }

    [MaxLength(50), Required]
    public string FirstName { get; set; }

    [MaxLength(50), Required]
    public string LastName { get; set; }

    [Required]
    public int DivisionId { get; set; }
    public virtual Division? Division { get; set; }

    [Precision(18,2), Required]
    public decimal Salary { get; set; }

    [Required]
    public bool TradeUnion { get; set; }

    public virtual ICollection<Position>? Positions { get; set; }




    


}
