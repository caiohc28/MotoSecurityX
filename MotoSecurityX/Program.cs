using Microsoft.EntityFrameworkCore;
using MotoSecurityX.Data;
using MotoSecurityX.DTO;
using MotoSecurityX.Repositories;


var builder = WebApplication.CreateBuilder(args);

// Oracle + EF Core
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleDb")));

// Injeção de dependência
builder.Services.AddScoped<IMotoRepository, MotoRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MappingConfig));


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
