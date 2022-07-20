using Microsoft.AspNetCore.Mvc;
using PrototypeBankSystem.BLL.Entities;
using PrototypeBankSystem.DAL.DataBase;

namespace PrototypeBankSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        private readonly IRepository<History> _repository;

        public HistoryController(IRepository<History> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _repository.GetAll());
        }
    }
}
