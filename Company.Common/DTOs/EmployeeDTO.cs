namespace Company.Common.DTOs;

public record EmployeeDTO
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int DivisionId { get; set; }
    public decimal Salary { get; set; }
    public bool TradeUnion { get; set; }

}
