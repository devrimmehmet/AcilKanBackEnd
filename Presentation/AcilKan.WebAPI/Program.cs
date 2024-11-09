using AcilKan.Application.Interfaces;
using AcilKan.Domain.Entities;
using AcilKan.Persistence.Context;
using AcilKan.Persistence.Repositories;
using AcilKan.WebAPI.Extensions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AcilKanContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("sqlcon"));
});

builder.Services.AddIdentity<AppUser, IdentityRole<int>>(options => 
{
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 1;

    options.User.RequireUniqueEmail = true;

    options.SignIn.RequireConfirmedEmail = true;
    options.Lockout.MaxFailedAccessAttempts = 3;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(30);

}).AddEntityFrameworkStores<AcilKanContext>();

builder.Services.AddServiceExtentions();



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

app.UseMiddleware<FluentValidationExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();

app.Run();
