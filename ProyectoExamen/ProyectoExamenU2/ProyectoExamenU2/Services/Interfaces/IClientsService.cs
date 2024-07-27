using ProyectoExamenU2.Dtos.Clients;
using ProyectoExamenU2.Dtos.Common;

namespace ProyectoExamenU2.Services.Interfaces;

public interface IClientsService
{
    Task<ResponseDto<ClientDto>> CreateClientAsync(ClientCreateDto dto);
}
