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
    public class ClientCardsController : ControllerBase
    {
        private readonly ClientCardRepository _repository;

        public ClientCardsController(ApplicationContext db)
        {
            _repository = new ClientCardRepository(db);
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
