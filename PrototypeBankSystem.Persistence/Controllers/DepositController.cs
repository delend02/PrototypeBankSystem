namespace PrototypeBankSystem.Persistence.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepositController : ControllerBase
    {
        private readonly IRepository<Deposit> _repository;

        public DepositController(IRepository<Deposit> repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Deposit client)
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
        public async Task<IActionResult> Update([FromBody] Deposit card)
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
