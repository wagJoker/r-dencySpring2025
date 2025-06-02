using Microsoft.EntityFrameworkCore;
using CoworkingBooking.API.Data;
using FluentValidation.AspNetCore;
using CoworkingBooking.API.Validators;
using CoworkingBooking.API.Services; // Add this

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// builder.Services.AddControllers(); // This line is moved and combined with FluentValidation registration

// Configure DbContext
// Ensure you have a connection string named "DefaultConnection" in your appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

// Add AutoMapper
builder.Services.AddAutoMapper(typeof(Program)); // Assumes MappingProfile is in the same assembly as Program.cs

// Add FluentValidation
// Ensure you have the FluentValidation.AspNetCore package installed
builder.Services.AddControllers()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<BookingDtoValidator>()); // Assumes BookingDtoValidator is in the same assembly

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register custom services
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<IWorkspaceService, WorkspaceService>();
builder.Services.AddScoped<IZoneService, ZoneService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IWorkspaceService, WorkspaceService>();
builder.Services.AddScoped<IZoneService, ZoneService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<IWorkspaceService, WorkspaceService>();
builder.Services.AddScoped<IZoneService, ZoneService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserService, UserService>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();