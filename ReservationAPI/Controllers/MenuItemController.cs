using Microsoft.AspNetCore.Mvc;
using ReservationAPI.Data;
using ReservationAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReservationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        private AppDbContext _dbContext;
        public MenuItemController (AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        // GET: api/<MenuItemController>
        [HttpGet]
        public IEnumerable<MenuItem> Get()
        {
            return _dbContext.MenuItems;
        }

        // GET api/<MenuItemController>/5
        [HttpGet("{id}")]
        public MenuItem Get(int id)
        {
            var menuItem = _dbContext.MenuItems.Find(id);
            return menuItem;
        }

        // POST api/<MenuItemController>
        [HttpPost]
        public void Post([FromBody] MenuItem menuItem)
        {

            _dbContext.MenuItems.Add(menuItem);
            _dbContext.SaveChanges();
        }

        // PUT api/<MenuItemController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] MenuItem menuObj)
        {
            var menuItem = _dbContext.MenuItems.Find(id);
            menuItem.Name = menuObj.Name;
            menuItem.Price = menuObj.Price;
            _dbContext.SaveChanges();


        }

        // DELETE api/<MenuItemController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var menuItem = _dbContext.MenuItems.Find(id);
            _dbContext.MenuItems.Remove(menuItem);
            _dbContext.SaveChanges();


        }
    }
}
