using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using RaceApi.Persistence;
using RaceApi.Repositories.Identity;
using RaceApi.Repositories.Identity.Interface;
using RaceApi.Repositories.Profiles;
using RaceApi.Repositories.Profiles.Interfaces;
using RaceApi.Repositories.Races;
using RaceApi.Repositories.Races.Interfaces;
using RaceApi.Repositories.Tracks;
using RaceApi.Repositories.Tracks.Interfaces;
using RaceApi.Seeders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.HttpOnly = true;
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        options.Cookie.SameSite = SameSiteMode.Strict; 
        options.LoginPath = "/Account/Login"; 
        options.LogoutPath = "/Account/Logout"; 
    });

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost",
        b =>
        {
            b.WithOrigins("http://localhost:5173") // Replace 'yourPort' with the port your client is running on
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});


builder.Services.AddAuthorization();

builder.Services.AddDbContext<RaceProjectContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RaceDatabase")));

builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IRaceRepository, RaceRepository>();
builder.Services.AddScoped<ITrackRepository, TrackRepository>();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    var scope = app.Services.CreateAsyncScope();

    var dbConnection = scope.ServiceProvider.GetRequiredService<RaceProjectContext>();

    dbConnection.Database.Migrate();

    var dataSeeder = new DataSeeder(dbConnection);

    await dataSeeder.SeedTestDataAsync();

}

app.UseCors("AllowLocalhost");

app.UseRouting();
    
app.UseAuthentication();
app.UseAuthorization();
    
app.MapControllers();

if (app.Environment.IsProduction())
{
    app.UseHttpsRedirection();
}

app.Run();
