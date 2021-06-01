using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationAPI.Model
{
    public class Reservation
    {
        [Key]
        [Required]
        public int ReservationID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime Date { get; set; }
     
        public List<MenuItem> MenuItems { get; internal set; }
    }
}
