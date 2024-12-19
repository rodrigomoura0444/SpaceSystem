using Microsoft.EntityFrameworkCore;
using SpaceSystemv2.API.Mappings;
using SpaceSystemv2.Domain;
using SpaceSystemv2.Infraestrutura.Data;
using SpaceSystemv2.Infraestrutura.Repository;
using SpaceSystemv2.Infraestrutura.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Registering the Repository Services, inject the Interface into Repository
builder.Services.AddScoped<IGenericRepository<Astronaut, Guid>, SQLAstronautRepository>();

//AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));
//Adding DbContext
//Registering the DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SpaceSystemConnectionString")));

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