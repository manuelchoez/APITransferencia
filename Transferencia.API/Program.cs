using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Configuration;
using System.Text;
using Transferencia.API.Middleware;
using Transferencia.Aplicacion.Services;
using Transferencia.Aplicacion.Services.Interfaces;
using Transferencia.Dominio.Repository;
using Transferencia.Infraestructura.Data;
using Transferencia.Infraestructura.SeriLog;
using Transferencia.Infraestructura.Token;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    {
        var key = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]);
        opt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };
    });

// Add services to the container.
builder.Services.AddControllers();


builder.Services.AddDbContext<BddtransfContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IBilleteraRepository, BilleteraRepository>();
builder.Services.AddScoped<IBilleteraService, BilleteraService>();
builder.Services.AddScoped<ITokenRepository, TokenRepository>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IMovimientoRepository, MovimientoRepository>();
builder.Services.AddScoped<IMovimientoService, MovimientoService>();
Log.Logger = new SerilogHelper(builder.Configuration)
    .SerilogConfiguracion("Transferencia.API", builder.Configuration.GetConnectionString("DefaultConnection"))
    .CreateLogger();
builder.Host.UseSerilog();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ErrorLoggingMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
