// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Company.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DivisionsController : ControllerBase
{

    private readonly IDbService _db;
    public DivisionsController(IDbService db) => _db = db;

    // GET: api/<DivisionsController>
    [HttpGet]
    public async Task<IResult> Get() =>
    await _db.HttpGetAsync<Division, DivisionDTO>();


    // GET api/<DivisionsController>/5
    [HttpGet("{id}")]
    public async Task<IResult> Get(int id) =>
    await _db.HttpSingleAsync<Division, DivisionDTO>(id);

    // POST api/<DivisionsController>
    [HttpPost]
    public async Task<IResult> Post([FromBody] DivisionDTO dto) =>
        await _db.HttpPostAsync<Division, DivisionDTO>(dto);

    // PUT api/<DivisionsController>/5
    [HttpPut("{id}")]
    public async Task<IResult> Put(int id, [FromBody] DivisionDTO dto) =>
        await _db.HttpPutAsync<Division, DivisionDTO>(dto, id);

    // DELETE api/<DivisionsController>/5
    [HttpDelete("{id}")]
    public async Task<IResult> Delete(int id) =>
        await _db.HttpDeleteAsync<Division>(id);
}
