using PracticeBackgroundService;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddHostedService<FirstBackground>()
    .AddHostedService<SecondBackground>();

var app = builder.Build();

app.Run();
