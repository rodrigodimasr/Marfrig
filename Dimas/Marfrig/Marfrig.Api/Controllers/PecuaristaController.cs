using Marfrig.Model.data_model;
using Marfrig.Model.infra;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Animal = Marfrig.Biz.Animal;

namespace Marfrig.Api.Controllers;

[Produces("application/json")]
[ApiController]
[Route("api/[controller]")]
public class PecuaristaController : ControllerBase
{
    private readonly Marfrig.Biz.Pecuarista _core;
    private readonly ILogger<PecuaristaController> _logger;

    public PecuaristaController(ILogger<PecuaristaController> logger, IConfiguration configuration)
    {
        _logger = logger;
        _core =
            new Marfrig.Biz.Pecuarista(
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