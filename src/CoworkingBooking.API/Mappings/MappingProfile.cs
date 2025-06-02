using AutoMapper;
using CoworkingBooking.API.Models.Dtos;
using CoworkingBooking.API.Models.Domain; // Используем доменную модель из ее нового расположения
using System;

namespace CoworkingBooking.API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Карта из Booking (доменная модель) в BookingDto (DTO)
            CreateMap<Booking, BookingDto>();

            // Карта из BookingDto (DTO) в Booking (доменная модель)
            // При создании новой записи из DTO, некоторые поля могут требовать специальной обработки
            CreateMap<BookingDto, Booking>()
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore()) // Обычно устанавливается сервером
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore()); // Обычно устанавливается сервером
        }
    }
}