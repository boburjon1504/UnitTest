using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Users.Api.DataAccess;
using Users.Api.Entities;
using Users.Api.Repository;
using Users.Api.Repository.Interface;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddDbContext<AppDbContext>(o => o.UseNpgsql("Host=localhost;Port=5432;Database=UnityPractise;Username=postgres;password=boburjon6767"));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true, // This enables lifetime validation
                ValidateIssuerSigningKey = true,
                ValidIssuer = "your_issuer",
                ValidAudience = "your_audience",
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("7587899a-f712-4a92-852c-8ff5f3dc1f6d"))
            };
            options.Events = new JwtBearerEvents
            {
                OnMessageReceived = context =>
                {
                    context.Token = context.Request.Cookies["token"];
                    return Task.CompletedTask;
                }
            };
        });

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthentication().UseAuthorization();

app.MapGet("users", ([FromServices] IUserRepository repository) => {
    return repository.Get().ToList().Select(u =>
    {
        if(u is Admin b)
            return b;
        return u;
    });
});

app.MapGet("{id:guid}", async ([FromServices] IUserRepository repository, [FromRoute] Guid id) =>
{
    var user =(User)(await repository.GetByIdAsync<User>(id));
    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("7587899a-f712-4a92-852c-8ff5f3dc1f6d"));
    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

    var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Email,user.EmailAddress)
    };
    return new JwtSecurityToken(
        issuer: "your_issuer",
        audience: "your_audience",
        claims: claims,
        notBefore: DateTime.UtcNow,
        expires: DateTime.UtcNow.AddMinutes(1),
        signingCredentials: credentials
    );
    var cookie = new CookieOptions
    {
        HttpOnly = true,
        Expires = DateTime.UtcNow.AddMinutes(3),
    };

});

app.MapControllers();
app.Run();
