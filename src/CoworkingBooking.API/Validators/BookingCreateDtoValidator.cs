using FluentValidation;
using CoworkingBooking.API.Models.Dto;

namespace CoworkingBooking.API.Validators
{
    public class BookingCreateDtoValidator : AbstractValidator<BookingDto>
    {
        public BookingCreateDtoValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.WorkplaceId).GreaterThan(0);
            RuleFor(x => x.StartTime).LessThan(x => x.EndTime);
            RuleFor(x => x.StartTime).GreaterThan(DateTime.Now).WithMessage("StartTime must be in the future");
        }
    }
}