using System;

namespace CoworkingBooking.API.Models.Domain
{
    public class Booking
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int WorkplaceId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Status { get; set; } // e.g., "Pending", "Confirmed", "Cancelled"
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}