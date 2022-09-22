using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ToDoAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public AuthenticationController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public record AuthenticationData(string? UserName, string? Password);
    public record UserData(int Id, string FirstName, string LastName, string UserName);


    // POST api/<AuthenticationController>
    [HttpPost("token")]
    [AllowAnonymous]
    public ActionResult<string> Authenticate([FromBody] AuthenticationData query)
    {
        var user = ValidateCredentials(query);

        if (user == null)
        {
            return Unauthorized();
        }

        var token = GenerateToken(user);

        return Ok(token);
    }


    private string GenerateToken(UserData user)
    {
        var secretKey = new SymmetricSecurityKey(
            Encoding.ASCII.GetBytes(_configuration.GetValue<string>("Authentication:SecurityKey")));

        var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

        List<Claim> claims = new();
        claims.Add(new(JwtRegisteredClaimNames.Sub, user.Id.ToString()));
        claims.Add(new(JwtRegisteredClaimNames.UniqueName, user.UserName.ToString()));
        claims.Add(new(JwtRegisteredClaimNames.FamilyName, user.LastName.ToString()));
        claims.Add(new(JwtRegisteredClaimNames.GivenName, user.FirstName.ToString()));

        var token = new JwtSecurityToken(
            _configuration.GetValue<string>("Authentication:Issuer"),
            _configuration.GetValue<string>("Authentication:Audience"),
            claims,
            DateTime.UtcNow, // Time token is valid
            DateTime.UtcNow.AddMinutes(60*24), // When token expires
            signingCredentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private UserData? ValidateCredentials(AuthenticationData query)
    {
        // This is just a demo - don't do this for prod!

        if (CompareValues(query.UserName, "Luke") && CompareValues(query.Password, "test123"))
        {
            return new UserData(1, "Luke", "Foster", "fosternz");
        }
        if (CompareValues(query.UserName, "Rachel") && CompareValues(query.Password, "test123"))
        {
            return new UserData(1, "Rachel", "Foster", "RachieRae");
        }


        return null;
    }

    private bool CompareValues(string? actual, string expected)
    {
        if (actual != null)
        {
            if (actual.Equals(expected))
            {
                return true;
            }
        }

        return false;
    }
}
