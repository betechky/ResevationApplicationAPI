using Microsoft.EntityFrameworkCore;
using ReservationAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<MenuItem> MenuItems { set; get; }
        public DbSet<Reservation> Reservations { set; get; }
        public DbSet<ReservationMenuItems> ReservationMenuItems { set; get; }
        
    }
}   
