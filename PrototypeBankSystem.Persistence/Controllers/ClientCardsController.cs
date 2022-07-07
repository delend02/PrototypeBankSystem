namespace PrototypeBankSystem.Persistence.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientCardsController : ControllerBase
    {
        private readonly IRepository<ClientCard> _repository;

        public ClientCardsController(IRepository<ClientCard> repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ClientCard card)
        {
            await _repository.Create(card);
            return Ok(card);
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
        public async Task<IActionResult> Update([FromBody] ClientCard card)
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
