using AcilKan.Application.Interfaces;
using AcilKan.Domain.Entities;
using AcilKan.Persistence.Context;
using AcilKan.Persistence.Repositories;
using AcilKan.Persistence.Services;
using AcilKan.Persistence.Utilities;
using AcilKan.WebAPI.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AcilKanContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("sqlcon"));
});


// JWT Bearer Authentication i�in yap?land?rma
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,  // Issuer (Token'? veren)
            ValidateAudience = true,  // Audience (Token'? alacak)
            ValidateLifetime = true,  // Token'?n s�resi dolmu? mu
            ClockSkew = TimeSpan.Zero,  // Token'?n ge�erlilik s�resi i�in tolerans (iste?e ba?l?)

            ValidIssuer = builder.Configuration["Jwt:Issuer"],  // appsettings.json'dan al?yoruz
            ValidAudience = builder.Configuration["Jwt:Audience"],  // appsettings.json'dan al?yoruz
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"])) // Secret key'i kullanarak imzalama
        };
    });

builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));

builder.Services.AddSingleton<IConfiguration>(builder.Configuration);


builder.Services.AddIdentity<AppUser, AppRole>(options => 
{
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 1;

    options.User.RequireUniqueEmail = true;

    //options.SignIn.RequireConfirmedEmail = true;
    //options.Lockout.MaxFailedAccessAttempts = 3;
    //options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(30);

}).AddEntityFrameworkStores<AcilKanContext>().AddDefaultTokenProviders();

builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();

builder.Services.AddScoped<JwtTokenService>();
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
