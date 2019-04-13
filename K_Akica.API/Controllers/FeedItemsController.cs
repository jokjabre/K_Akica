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
    public class FeedItemsController : ControllerBase
    {
        private K_AkicaContext m_context;

        public FeedItemsController(K_AkicaContext context)
        {
            m_context = context;
        }

        // GET: api/FeedItems
        [HttpGet]
        public IEnumerable<FeedItem> Get()
        {
            return m_context.FeedItems;
        }

        // GET: api/FeedItems/5
        [HttpGet("{id}")]
        public FeedItem Get(int id)
        {
            return m_context.FeedItems.Find(id);
        }

        // POST: api/FeedItems
        [HttpPost]
        public void Post([FromBody] FeedItemRequest value)
        {
            var pooper = m_context.Poopers.Find(value.PooperId);
            m_context.FeedItems.Add(value.AsFeedItem(pooper));

            m_context.SaveChanges();
        }

        // PUT: api/FeedItems/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] FeedItemRequest value)
        {
            var existing = m_context.FeedItems.Find(id);
            var pooper = m_context.Poopers.Find(value.PooperId);

            existing.UpdateFromRequest(value, pooper);

            m_context.FeedItems.Update(existing);
            m_context.SaveChanges();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            m_context.FeedItems.Remove(m_context.FeedItems.Find(id));
            m_context.SaveChanges();
        }
    }
}
