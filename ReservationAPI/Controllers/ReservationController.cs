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
    public class ReservationController : ControllerBase
    {
        private AppDbContext _dbContext;
        public ReservationController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        // GET: api/<ReservationController>
        [HttpGet]
        public IEnumerable<Reservation> Get()
        {
             return _dbContext.Reservations;
        }

        // GET api/<ReservationController>/5
        [HttpGet("{id}")]
        public Reservation Get(int id)
        {
            var reservation = _dbContext.Reservations.Find(id);
            return reservation;
        }

        // POST api/<ReservationController>
        [HttpPost]
        public void Post([FromBody] Reservation reservation)
        {
            _dbContext.Reservations.Add(reservation);
            _dbContext.SaveChanges();
        }

        // PUT api/<ReservationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Reservation reserveObj)
        {
            var reservation = _dbContext.Reservations.Find(id);
            reservation.Date = reserveObj.Date;
            reservation.Name = reserveObj.Name;
            reservation.MenuItems = reservation.MenuItems;
        }

        // DELETE api/<ReservationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var reservation = _dbContext.MenuItems.Find(id);
            _dbContext.MenuItems.Remove(reservation);
            _dbContext.SaveChanges();
        }


    }
}
