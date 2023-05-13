using BackEnd;
using BackEnd.Model;
using BackEnd.Parseur;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Python.Runtime;
using System.Diagnostics;
using System.Text.Json;
using BackEnd.Context;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddCors(); // ajouter cette ligne

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDBContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("sqlServerConnStr"));
});

/*builder.Services.AddDbContext<ConnectionDB>(options =>options.UseSqlServer(connectionString));


using (var db = new ConnectionDB())
{
    var customers = db.users.ToList();
    // Utilisez les donn�es de la table Customers ici...


    foreach (Users user in customers)
    {
        Console.WriteLine(user.username);
    }
} */
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

// ajouter cette section
app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.MapControllers();

app.Run();

