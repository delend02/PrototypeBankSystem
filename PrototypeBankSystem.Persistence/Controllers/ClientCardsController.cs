using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrototypeBankSystem.Domain.Entities;
using PrototypeBankSystem.Persistence.DataBase.Repository;

namespace PrototypeBankSystem.Persistence.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClientCardsController : ControllerBase
    {
        private static readonly ClientCardRepository _repository = new();

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
    }
}
