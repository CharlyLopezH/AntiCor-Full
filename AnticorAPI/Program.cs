using AnticorAPI;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Globalization;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Crear variable para la cadena de conexión
var connectionString = builder.Configuration.GetConnectionString("Connection");

//registrar servicio para la conexion
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(connectionString)
);

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllers();

//cors
builder.Services.AddCors(options =>
{

    options.AddDefaultPolicy(builder =>
    {
        builder
            .WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .WithExposedHeaders(new string[] { "cantidadTotalRegistros" })
            .AllowAnyMethod();
    });

}

);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();



//Swagger
builder.Services.AddSwaggerGen();

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
app.UseCors();
app.MapGet("/", () => "Hello Anticorrupción!");
app.Run();
