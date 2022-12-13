using Marfrig.Biz;
using Marfrig.Model.infra;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Marfrig.Api.Controllers;

[Produces("application/json")]
[ApiController]
[Route("api/[controller]")]
public class CompraGadoController : ControllerBase
{
    private readonly CompraGado _core;
    private readonly ILogger<CompraGadoController> _logger;

    public CompraGadoController(ILogger<CompraGadoController> logger, IConfiguration configuration)
    {
        _logger = logger;
        _core =
            new CompraGado(
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
     
    [HttpPut("Put/{id}")]
    public async Task<IActionResult> Put(int id)
    {
        try
        {
            await _core.AtualizaIndicaImpresso(id);
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogInformation($"Erro: {ex.Message}");
            return BadRequest("Desculpas, Ocorreu um erro interno ! ");
        }
    }

    [HttpDelete("DeleteItem/{idItem}")]
    public async Task<IActionResult> DeleteItem(int idItem)
    {
        try
        {
            await _core.DeleteItem(idItem);
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogInformation($"Erro: {ex.Message}");
            return BadRequest("Desculpas, Ocorreu um erro interno ! ");
        }
    }

    [HttpDelete("Delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _core.Delete(id);
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogInformation($"Erro: {ex.Message}");
            return BadRequest("Desculpas, Ocorreu um erro interno ! ");
        }
    }


    [HttpPost("Post")]
    public async Task<IActionResult> Post(Model.data_model.CompraGado compraGado)
    {
        try
        {
            await _core.Salvar(compraGado);
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogInformation($"Erro: {ex.Message}");
            return BadRequest("Desculpas, Ocorreu um erro interno ! ");
        }
    }
}