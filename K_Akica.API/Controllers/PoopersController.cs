using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using K_Akica.API.Contracts.Communication;
using K_Akica.API.Contracts.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace K_Akica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoopersController : ControllerBase
    {
        private K_AkicaContext m_context;

        public PoopersController(K_AkicaContext context)
        {
            m_context = context;
        }

        // GET: api/Poopers
        [HttpGet]
        public async Task<IEnumerable<Pooper>> Get()
        {
            return await m_context.Poopers.ToListAsync();//.Select(p => p.AsResponce());
        }

        // GET: api/Poopers/5
        [HttpGet("{id}")]
        public async Task<Pooper> Get(int id)
        {
            return await m_context.Poopers.FindAsync(id);
        }

        // POST: api/Poopers
        [HttpPost]
        public async Task Post([FromBody] PooperRequest value)
        {
            await m_context.Poopers.AddAsync(value.AsPooper());
            await m_context.SaveChangesAsync();
        }

        // PUT: api/Poopers/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] PooperRequest value)
        {
            var existing = m_context.Poopers.Find(id);
            existing.UpdateFromRequest(value);

            m_context.Poopers.Update(existing);
            await m_context.SaveChangesAsync();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            m_context.Poopers.Remove(m_context.Poopers.Find(id));
            await m_context.SaveChangesAsync();
        }
    }
}
