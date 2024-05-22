using System.Text.Json.Serialization;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RaceApi.Features.ApiMaps.Tracks;
using RaceApi.Features.Endpoints.Game;
using RaceApi.Features.Endpoints.Identity;
using RaceApi.Features.Endpoints.Profiles;
using RaceApi.Features.Endpoints.Races;
using RaceApi.Models.Mappers;
using RaceApi.Persistence;
using RaceApi.Repositories.Games;
using RaceApi.Repositories.Games.Interfaces;
using RaceApi.Repositories.Identity;
using RaceApi.Repositories.Identity.Interface;
using RaceApi.Repositories.Profiles;
using RaceApi.Repositories.Profiles.Interfaces;
using RaceApi.Repositories.Races;
using RaceApi.Repositories.Races.Interfaces;
using RaceApi.Repositories.Tracks;
using RaceApi.Repositories.Tracks.Interfaces;
using RaceApi.Seeders;
using Profile = RaceApi.Persistence.Models.Profile;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost",
        b =>
        {
            b.WithOrigins("http://localhost:5173") // Replace 'yourPort' with the port your client is running on
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials();
        });
});


builder.Services.AddDbContext<RaceProjectContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RaceDatabase")));

builder.Services.AddIdentityApiEndpoints<Profile>()
    .AddEntityFrameworkStores<RaceProjectContext>()
    .AddDefaultTokenProviders();;


// Add services to the container.

builder.Services.AddAuthorization();

builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IRaceRepository, RaceRepository>();
builder.Services.AddScoped<ITrackRepository, TrackRepository>();
builder.Services.AddScoped<IGameRepository, GameRepository>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
    );

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

app.MapIdentityApi<Profile>();

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

if (app.Environment.IsProduction())
{
    app.UseHttpsRedirection();
}

AuthEndpoints.Map(app);
GameEndpoint.Map(app);
RaceEndpoints.Map(app);
TrackEndpoints.Map(app);
ProfileEndpoints.Map(app);

app.Run();
