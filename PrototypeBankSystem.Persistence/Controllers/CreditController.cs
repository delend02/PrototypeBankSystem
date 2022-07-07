namespace PrototypeBankSystem.Persistence.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditController : Controller
    {
        private readonly IRepository<Credit> _repository;

        public CreditController(IRepository<Credit> repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Credit credit)
        {
            return Ok(await _repository.Create(credit));
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
        public async Task<IActionResult> Update([FromBody] Credit card)
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
