using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Users.Api.Entities;
using Users.Api.Repository.Interface;

namespace Users.Api.Controllers;
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[Route("api/[controller]")]
[ApiController]
public class UsersController(IUserRepository repository) : ControllerBase
{
    [AllowAnonymous]
    [HttpGet]
    public IActionResult Get() => Ok(repository.Get());

    [Authorize]
    [HttpGet("some")]
    public IActionResult Take() => Ok(repository.Get());

    [AllowAnonymous]
    [HttpGet("login")]
    public async ValueTask<IActionResult> Get(Guid id)
    {
        var user = (User)(await repository.GetByIdAsync<User>(id));
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("7587899a-f712-4a92-852c-8ff5f3dc1f6d"));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
        new Claim(ClaimTypes.Email,user.EmailAddress)
        };
        var token = new JwtSecurityTokenHandler().WriteToken(  new JwtSecurityToken(
            issuer: "your_issuer",
            audience: "your_audience",
            claims: claims,
            expires: DateTime.Now.AddSeconds(30),
            signingCredentials: credentials
        ));
        var cookie = new CookieOptions
        {
            HttpOnly = true,
            Expires = DateTime.Now.AddMinutes(1),
        };
        Response.Cookies.Append("token", token,cookie);

        return Ok();
    }
}
