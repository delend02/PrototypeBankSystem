#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PrototypeBankSystem.Domain.Entities;
using PrototypeBankSystem.Persistence.DataBase.Repository;

namespace PrototypeBankSystem.Persistence.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClientsController : Controller
    {
        private static readonly ClientRepository _repository = new();

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
        public async Task<IActionResult> GetClient(string id)
        {
            return Ok(await _repository.GetByID(id));
        }
        
    }
}
