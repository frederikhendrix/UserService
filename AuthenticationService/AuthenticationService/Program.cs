using AuthenticationService.Data;
using AuthenticationService.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//add authentication

builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);

//Add Authentication
builder.Services.AddAuthorizationBuilder();

// Configure DbContext
builder.Services.AddDbContext<AuthDbContext>(opt => opt.UseSqlite("DataSource=appdata.db"));

builder.Services.AddIdentityCore<AppUser>().AddEntityFrameworkStores<AuthDbContext>().AddApiEndpoints();

var app = builder.Build();

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
