namespace PrototypeBankSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : Controller
    {
        private readonly IRepository<Client> _repository;

        public ClientsController(IRepository<Client> repository)
        {
            _repository = repository;
        }
        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Client client)
        {
            return Ok(await _repository.Create(client));
        }
        

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _repository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(string id)
        {
            return Ok(await _repository.GetByID(id));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Client card)
        {
            return Ok(await _repository.Update(card));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            return Ok(await _repository.Delete(id));
        }
    }
}
