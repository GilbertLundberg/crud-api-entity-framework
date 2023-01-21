// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Company.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeePositionsController : ControllerBase
{

    private readonly IDbService _db;
    public EmployeePositionsController(IDbService db) => _db = db;

    // POST api/<EmployeePositionsController>
    [HttpPost]
    public async Task<IResult> Post([FromBody] EmployeePositionDTO dto) =>
        await _db.HttpAddAsync<EmployeePosition, EmployeePositionDTO>(dto);

    // DELETE api/<EmployeePositionsController>/5
    [HttpDelete("{id}")]
    
    public async Task<IResult> Delete([FromBody] EmployeePositionDTO dto) =>
       await _db.HttpDeleteAsync<EmployeePosition, EmployeePositionDTO>(dto);
}
