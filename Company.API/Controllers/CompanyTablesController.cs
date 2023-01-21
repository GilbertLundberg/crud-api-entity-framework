// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Company.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompanyTablesController : ControllerBase
{

    private readonly IDbService _db;
    public CompanyTablesController(IDbService db) => _db = db;

    // GET: api/<CompanyTableController>
    [HttpGet]
    public async Task<IResult> Get() =>
    await _db.HttpGetAsync<CompanyTable, CompanyTableDTO>();


    // GET api/<CompanyTableController>/5
    [HttpGet("{id}")]
    public async Task<IResult> Get(int id) =>
    await _db.HttpSingleAsync<CompanyTable, CompanyTableDTO>(id);


    // POST api/<CompanyTableController>
    [HttpPost]
    public async Task<IResult> Post([FromBody] CompanyTableDTO dto) =>
        await _db.HttpPostAsync<CompanyTable, CompanyTableDTO>(dto);
   
    // PUT api/<CompanyTableController>/5
    [HttpPut("{id}")]
    public async Task<IResult> Put(int id, [FromBody] CompanyTableDTO dto) =>
        await _db.HttpPutAsync<CompanyTable, CompanyTableDTO>(dto, id);


    // DELETE api/<CompanyTableController>/5
    [HttpDelete("{id}")]
    public async Task<IResult> Delete(int id) =>
        await _db.HttpDeleteAsync<CompanyTable>(id);

}




