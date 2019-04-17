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
        [HttpGet(Name ="GetAllFeedItems")]
        public async Task<IEnumerable<FeedItem>> Get()
        {
            return await m_context.FeedItems.ToListAsync();
        }

        // GET: api/FeedItems/5
        [HttpGet("{id}", Name = "GetFeedItem")]
        public async Task<FeedItem> Get(int id)
        {
            return await m_context.FeedItems.FindAsync(id);
        }

        [HttpPost("pooper/{id}", Name = "GetFeedForPooper")]
        public async Task<IEnumerable<FeedItem>> GetForPooper(int id)
        {
            return (await m_context.Poopers.FindAsync(id))?.FeedItems;
        }

        // POST: api/FeedItems
        [HttpPost(Name = "PostFeedItem")]
        public async Task Post([FromBody] FeedItemRequest value)
        {
            var pooper = await m_context.Poopers.FindAsync(value.PooperId);
            await m_context.FeedItems.AddAsync(value.AsFeedItem(pooper));

            await m_context.SaveChangesAsync();
        }

        // PUT: api/FeedItems/5
        [HttpPut("{id}", Name = "PutFeedItem")]
        public async Task Put(int id, [FromBody] FeedItemRequest value)
        {
            var existing = await m_context.FeedItems.FindAsync(id);
            var pooper = await m_context.Poopers.FindAsync(value.PooperId);

            existing.UpdateFromRequest(value, pooper);

            m_context.FeedItems.Update(existing);
            await m_context.SaveChangesAsync();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}", Name = "DeleteFeedItem")]
        public async Task Delete(int id)
        {
            m_context.FeedItems.Remove(m_context.FeedItems.Find(id));
            await m_context.SaveChangesAsync();
        }
    }
}
