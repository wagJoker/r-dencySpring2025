using System.Collections.Generic;

namespace CoworkingBooking.API.Models
{
    public class Workspace
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ZoneId { get; set; }
        public int Capacity { get; set; }
        public string Description { get; set; }
        // public Zone Zone { get; set; } // Навигационное свойство
        // public ICollection<Booking> Bookings { get; set; }
    }
}