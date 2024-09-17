using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;


namespace login_isaias.Controllers;


[ApiController]

public class AuthController : ControllerBase
{

    [HttpPost("auth")]
    public ActionResult<ResponseDto> Login(UserDto user)
    {

        if (user.name.Equals("isaias") && user.clave.Equals("isaias"))
        {
            var token = CreateToken(user.name);
            Response.Headers.Add("url", "3002/df");
            return Ok(new ResponseDto
            {
                status = 200,
                result = new
                {
                    id_usuario = 403,
                    token_acceso = token,
                    token_refresh = ""
                }
            });

        }

        return BadRequest("Usuario no encontrado");
    }

    private string CreateToken(string user)
    {
        var tokenHangler = new JwtSecurityTokenHandler();
        var byteKey = Encoding.UTF8.GetBytes("kn5ln23nm4jn5kj43n1kn43325nkj6543");
        var tokerDes = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, user),
            }),
            Expires = DateTime.UtcNow.AddDays(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(byteKey),
                                                            SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHangler.CreateToken(tokerDes);
        return tokenHangler.WriteToken(token);
    }

    [Authorize]
    [HttpGet("listado")]
    public ActionResult<List<string>> getAllUser()
    {

        var listado = new List<string>(){
            "isaias","ramon","pedro"
        };
        return listado;
    }
}

