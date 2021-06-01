using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationAPI.Model
{
    public class ReservationMenuItems
    {
        public int Id { set; get; }
        public int MenuItemID { set; get; }
        public int ReservationID { set; get; }
        public Reservation Reservation { set; get; }
        public MenuItem MenuItem { set; get; }
    }
}
