using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using RaceApi.Persistence;
using RaceApi.Repositories.Profiles;
using RaceApi.Repositories.Profiles.Interfaces;
using RaceApi.Seeders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.HttpOnly = true;
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // Enable secure cookies in production
        options.Cookie.SameSite = SameSiteMode.Strict; // Set SameSite mode for cookies
        options.LoginPath = "/Account/Login"; // Set the login path
        options.LogoutPath = "/Account/Logout"; // Set the logout path
    });

builder.Services.AddAuthorization();

builder.Services.AddDbContext<RaceProjectContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RaceDatabase")));

builder.Services.AddScoped<IProfileRepository, ProfileRepository>();

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

app.UseRouting();
    
app.UseAuthentication(); // Add this line
app.UseAuthorization(); // Add this line
    
app.MapControllers();

if (app.Environment.IsProduction())
{
    app.UseHttpsRedirection();
}

app.Run();
