using Microsoft.EntityFrameworkCore;
using Users.Api.DataAccess;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(o => o.UseNpgsql("Host=localhost;Port=5432;Database=UnityPractise;Username=postgres;password=boburjon6767"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
