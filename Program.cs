using Microsoft.EntityFrameworkCore;
using projectApi.Data;

using System.Text;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Configuramos la conexión a SQLServer local
var connectionString = builder.Configuration.GetConnectionString("ConnectionSQL") ??
throw new InvalidOperationException("Error de conexión con la base de datos");
builder.Services.AddDbContext<Context>(options=>options.UseSqlServer(connectionString));

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "ToDo API",
            Description = "An ASP.NET Core Web API for mapping ToDo items",
            TermsOfService = new Uri("https://japdp.es"),
            Contact = new OpenApiContact
            {
                Name = "Example Contact",
                Url = new Uri("https://japdp.es")
            },
            License = new OpenApiLicense
            {
                Name = "Example License",
                Url = new Uri("https://japdp.es")
            }
        });
    }
);

builder.Services.AddControllers();
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.MapControllers();
app.Run();
