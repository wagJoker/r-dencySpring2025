using System;

namespace CoworkingBooking.API.Models.Dtos
{
    public class BookingDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int WorkplaceId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Status { get; set; }
    }
}