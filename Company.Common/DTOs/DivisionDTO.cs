namespace Company.Common.DTOs;

public record DivisionDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CompanyId { get; set; }

}
