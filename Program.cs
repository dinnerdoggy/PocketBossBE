using Microsoft.EntityFrameworkCore;
using PocketBoss.Data;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration["PocketBossDbConnectionString"];

builder.Services.AddDbContext<PocketBossDbContext>(options =>
    options.UseNpgsql(connectionString));
builder.Services.AddTransient<GameDataSeeder>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Run GameDataSeeder
using (var scope = app.Services.CreateScope())
{
    var seeder = scope.ServiceProvider.GetRequiredService<GameDataSeeder>();
    await seeder.SeedAsync();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.Run();
