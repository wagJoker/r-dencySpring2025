using AutoMapper;
using CoworkingBooking.API.Data;
using CoworkingBooking.API.Models;
using CoworkingBooking.API.Models.Dto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoworkingBooking.API.Services
{
    public interface IBookingService
    {
        IEnumerable<BookingDto> GetAll();
        BookingDto GetById(int id);
        BookingDto Create(BookingDto dto);
        void Update(int id, BookingDto dto);
        void Delete(int id);
    }

    public class BookingService : IBookingService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public BookingService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookingDto>> GetAllBookingsAsync()
        {
            var bookings = await _context.Bookings.ToListAsync();
            return _mapper.Map<IEnumerable<BookingDto>>(bookings);
        }

        public async Task<BookingDto> GetBookingByIdAsync(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            return _mapper.Map<BookingDto>(booking);
        }

        public async Task<BookingDto> CreateBookingAsync(BookingCreateDto bookingDto)
        {
            // Validate EndTime > StartTime (already in DTO, but good to double check or have service-level validation)
            if (bookingDto.EndTime <= bookingDto.StartTime)
            {
                // Consider throwing a custom exception or returning a specific result
                return null; 
            }

            // Time Overlap Check
            var existingBooking = await _context.Bookings
                .FirstOrDefaultAsync(b =>
                    b.WorkspaceId == bookingDto.WorkspaceId &&
                    b.EndTime > bookingDto.StartTime &&
                    b.StartTime < bookingDto.EndTime);

            if (existingBooking != null)
            {
                // Booking overlap detected
                return null; // Indicate failure, controller can translate this to a 409 Conflict or 400 Bad Request
            }

            var booking = _mapper.Map<Booking>(bookingDto);
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
            return _mapper.Map<BookingDto>(booking);
        }

        public async Task<bool> UpdateBookingAsync(int id, BookingUpdateDto bookingDto)
        {
            if (id != bookingDto.Id)
            {
                return false; // ID mismatch
            }

            if (bookingDto.EndTime <= bookingDto.StartTime)
            {
                return false; // Invalid time range
            }

            var bookingToUpdate = await _context.Bookings.FindAsync(id);
            if (bookingToUpdate == null)
            {
                return false; // Not found
            }

            // Time Overlap Check (excluding the current booking being updated)
            var existingBooking = await _context.Bookings
                .FirstOrDefaultAsync(b =>
                    b.Id != id && // Exclude the current booking
                    b.WorkspaceId == bookingDto.WorkspaceId &&
                    b.EndTime > bookingDto.StartTime &&
                    b.StartTime < bookingDto.EndTime);

            if (existingBooking != null)
            {
                // Booking overlap detected
                return false; // Indicate failure
            }

            _mapper.Map(bookingDto, bookingToUpdate);
            _context.Entry(bookingToUpdate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
            return true;
        }

        public async Task<bool> DeleteBookingAsync(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
            {
                return false;
            }

            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();
            return true;
        }

        private bool BookingExists(int id)
        {
            return _context.Bookings.Any(e => e.Id == id);
        }
    }
}