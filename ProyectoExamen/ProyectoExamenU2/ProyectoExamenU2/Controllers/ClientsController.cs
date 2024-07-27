using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using ProyectoExamenU2.Dtos.Clients;
using ProyectoExamenU2.Dtos.Common;
using ProyectoExamenU2.Services.Interfaces;

namespace ProyectoExamenU2.Controllers;

//[Route("api/clients")]
[Microsoft.AspNetCore.Mvc.Route("api/clients")]
[ApiController]

public class ClientsController : ControllerBase
{
    private readonly IClientsService _clientsService;

    public ClientsController(IClientsService clientsService)
    {
        this._clientsService = clientsService;
    }

    [HttpPost]
    public async Task<ActionResult<ResponseDto<ClientDto>>> Create (ClientCreateDto dto)
    {
        var response = await _clientsService.CreateClientAsync (dto);

        return StatusCode(response.StatusCode, response);
    }
}
