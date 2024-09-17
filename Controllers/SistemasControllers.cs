using Microsoft.AspNetCore.Mvc;


namespace login_isaias.Controllers;

[ApiController]

public class SistemasController : ControllerBase
{
    [HttpGet("sistemas/getAll")]
    public ActionResult<List<RoutesDto>> GetAll()
    {
        var sistemas = new List<RoutesDto>(){
            new RoutesDto{
                nombre_sistema ="Recuadacion",
                intencion ="006"
            },
            new RoutesDto {
                nombre_sistema= "Domicilio Fiscal",
                intencion="005"
            }
        };

        return Ok(sistemas);
    }

    
}