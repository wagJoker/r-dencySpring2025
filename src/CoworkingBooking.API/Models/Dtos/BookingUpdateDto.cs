using System;
using System.ComponentModel.DataAnnotations;

namespace CoworkingBooking.API.Models.Dtos
{
    public class BookingUpdateDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int WorkspaceId { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        // Add other properties relevant for updating a booking

        // Custom validation: EndTime must be after StartTime
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (EndTime <= StartTime)
            {
                yield return new ValidationResult("End time must be after start time.", new[] { nameof(EndTime) });
            }
        }
    }
}