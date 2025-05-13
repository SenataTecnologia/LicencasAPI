using Microsoft.AspNetCore.Mvc;
using LicensasApi.Data;
using System.Linq;

namespace LicensasApi.Controllers;

[ApiController]
[Route("api/licenca")]
public class LicencaController : ControllerBase
{
    private readonly AppDbContext _context;

    public LicencaController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("validar")]
    public IActionResult Validar(string cnpj)
    {
        try
        {

    
        var licenca = _context.Licencas
            .FirstOrDefault(l => l.CNPJ == cnpj && l.Ativa && l.DataExpiracao >= DateTime.Today);

        if (licenca == null)
            return Forbid();

        return Ok(new
        {
            licenca.Empresa,
            licenca.CNPJ,
            licenca.DataExpiracao
        });
        }
        catch (Exception ex)
        {

            throw;
        }
    }
    [HttpGet]
    public IActionResult ObterLicencas()
    {
        try
        {
            var licencas = _context.Licencas.ToList();
            return Ok(licencas);
        }
        catch (Exception ex)
        {
            //_logger.LogError(ex, "Erro ao buscar licenças.");
            return StatusCode(500, new { message = "Erro ao processar sua solicitação. Tente novamente mais tarde." });
        }
    }
}