using Marfrig.Biz;
using Marfrig.Model.infra;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Marfrig.Api.Controllers;

[Produces("application/json")]
[ApiController]
[Route("api/[controller]")]
public class AnimalController : ControllerBase
{
    private readonly Animal _core;
    private readonly ILogger<AnimalController> _logger;

    public AnimalController(ILogger<AnimalController> logger, IConfiguration configuration)
    {
        _logger = logger;
        _core =
            new Animal(
                JsonConvert.DeserializeObject<Settings>(configuration.GetSection("ProviderSettings").Value));
    }
    
    [HttpGet("Get")]
    public async Task<IActionResult> Get()
    {
        try
        {
            return Ok(await _core.Get());
        }
        catch (Exception ex)
        {
            _logger.LogInformation($"Erro: {ex.Message}");
            return BadRequest("Desculpas, Ocorreu um erro interno ! ");
        }
    }

    
}