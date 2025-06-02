using CoworkingBooking.API.Models.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoworkingBooking.API.Services
{
    public interface IBookingService
    {
        Task<IEnumerable<BookingDto>> GetAllBookingsAsync();
        Task<BookingDto> GetBookingByIdAsync(int id);
        Task<BookingDto> CreateBookingAsync(BookingCreateDto bookingDto);
        Task<bool> UpdateBookingAsync(int id, BookingUpdateDto bookingDto);
        Task<bool> DeleteBookingAsync(int id);
    }
}