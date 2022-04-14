#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrototypeBankSystem.Domain.Entities;
using PrototypeBankSystem.Persistence.DataBase;
using PrototypeBankSystem.Persistence.DataBase.Repository;

namespace PrototypeBankSystem.Persistence.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepositController : ControllerBase
    {
        private readonly DepositRepository _repository;

        public DepositController(ApplicationContext db)
        {
            _repository = new DepositRepository(db);
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
        public async Task<IActionResult> GetClient(string id)
        {
            return Ok(await _repository.GetByID(id));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Deposit card)
        {
            return Ok(await _repository.Update(card));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromQuery] string id)
        {
            return Ok(await _repository.Delete(id));
        }
    }
}
