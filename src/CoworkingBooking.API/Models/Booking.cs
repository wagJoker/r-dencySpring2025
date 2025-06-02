using System;

namespace CoworkingBooking.API.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public string UserId { get; set; } // Может быть Guid или int в зависимости от системы аутентификации
        public int WorkplaceId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public BookingStatus Status { get; set; }
        // Можно добавить навигационные свойства, если есть связанные сущности Workplace, User и т.д.
        // public Workplace Workplace { get; set; }
        // public User User { get; set; }
    }

    public enum BookingStatus
    {
        Pending,
        Confirmed,
        Cancelled,
        Completed
    }
}