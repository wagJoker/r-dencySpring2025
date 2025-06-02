using CoworkingBooking.API.Models.Dtos;
using FluentValidation;
using System;

namespace CoworkingBooking.API.Validators
{
    public class BookingDtoValidator : AbstractValidator<BookingDto>
    {
        public BookingDtoValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("UserId is required.");

            RuleFor(x => x.WorkplaceId)
                .GreaterThan(0).WithMessage("WorkplaceId must be greater than 0.");

            RuleFor(x => x.StartTime)
                .NotEmpty().WithMessage("Start time is required.")
                .GreaterThanOrEqualTo(DateTime.UtcNow).WithMessage("Start time cannot be in the past.");

            RuleFor(x => x.EndTime)
                .NotEmpty().WithMessage("End time is required.")
                .GreaterThan(x => x.StartTime).WithMessage("End time must be after start time.");

            RuleFor(x => x.Status)
                .NotEmpty().WithMessage("Status is required.")
                .Must(status => status == "Pending" || status == "Confirmed" || status == "Cancelled")
                .WithMessage("Status must be one of 'Pending', 'Confirmed', or 'Cancelled'.");
        }
    }
}