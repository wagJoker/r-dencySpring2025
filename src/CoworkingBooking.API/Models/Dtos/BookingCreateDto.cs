using System;
using System.ComponentModel.DataAnnotations;

namespace CoworkingBooking.API.Models.Dtos
{
    public class BookingCreateDto
    {
        [Required]
        public int WorkspaceId { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }
        // public string UserId { get; set; } // Assuming UserId is handled or comes from authenticated user
    }
}