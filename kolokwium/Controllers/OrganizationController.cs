using kolokwium.Services;
using Microsoft.AspNetCore.Mvc;

namespace kolokwium.Controllers;

[ApiController]
[Route("api")]
public class OrganizationController : ControllerBase
{
    private readonly IOrganizationService _service;

    public OrganizationController(IOrganizationService svc) { _service = svc; }

    [HttpGet]
    [Route("team/{id}")]
    public async Task<IActionResult> GetTeam(int id)
    {
        return Ok(await _service.GetTeam(id));
    }
    
    [HttpPost]
    [Route("member")]
    public async Task<IActionResult> AddMember(int idMember, int idTeam)
    {
        await _service.AddMember(idMember, idTeam);
        return Ok();
    }
}
