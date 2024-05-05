using System.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Microsoft.Identity.Abstractions;
using Microsoft.Identity.Web.Resource;
using RaceApi.Persistence;
using RaceApi.Seeders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAdB2C"));
builder.Services.AddAuthorization();

builder.Services.AddDbContext<RaceProjectContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RaceDatabase")));

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
    var scope = app.Services.CreateAsyncScope();

    // Resove the DB Connection Service
    var dbConnection = scope.ServiceProvider.GetRequiredService<RaceProjectContext>();

    dbConnection.Database.Migrate();
    
    // Create a data seeder
    var dataSeeder = new DataSeeder(dbConnection);

    // Seed the test data
    await dataSeeder.SeedTestDataAsync();
}

if (app.Environment.IsProduction())
{
    app.UseHttpsRedirection();
}

app.Run();
