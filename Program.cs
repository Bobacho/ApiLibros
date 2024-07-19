using Microsoft.EntityFrameworkCore;
using ApiLibros.Models;
using ApiLibros.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<ProyectosLibrosContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LibrosConnection")));

builder.Services.AddScoped<LibroRepository>();
builder.Services.AddScoped<UsuarioRepository>();
builder.Services.AddScoped<ComprobantePagoRepository>();
builder.Services.AddScoped<CarritoRepository>();
builder.Services.AddScoped<ClienteRepository>();
builder.Services.AddHttpContextAccessor()
    .AddAuthorization()
    .AddAuthentication()
    .AddJwtBearer(
        options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidAudience = builder.Configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
            };
        }
    );



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();

