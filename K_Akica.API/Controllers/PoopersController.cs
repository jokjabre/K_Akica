using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using K_Akica.API.Contracts.Communication;
using K_Akica.API.Contracts.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public IEnumerable<PooperRequest> Get()
        {
            return m_context.Poopers.Select(p => p.AsResponce());
        }

        // GET: api/Poopers/5
        [HttpGet("{id}", Name = "Get")]
        public Pooper Get(int id)
        {
            return m_context.Poopers.Find(id);
        }

        // POST: api/Poopers
        [HttpPost]
        public void Post([FromBody] PooperRequest value)
        {
            m_context.Poopers.Add(value.AsPooper());
            m_context.SaveChanges();
        }

        // PUT: api/Poopers/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] PooperRequest value)
        {
            var existing = m_context.Poopers.Find(id);
            existing.UpdateFromRequest(value);

            m_context.Poopers.Update(existing);
            m_context.SaveChanges();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            m_context.Poopers.Remove(m_context.Poopers.Find(id));
            m_context.SaveChanges();
        }
    }
}
