using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProyectoExamenU2.Database;
using ProyectoExamenU2.Database.Entities;
using ProyectoExamenU2.Dtos.Clients;
using ProyectoExamenU2.Dtos.Common;
using ProyectoExamenU2.Services.Interfaces;

namespace ProyectoExamenU2.Services;

public class ClientsService : IClientsService
{
    private readonly ProyectoExamenU2Context _context;
    private readonly IMapper _mapper;

    public ClientsService(ProyectoExamenU2Context context, IMapper mapper)
    {
        this._context = context;
        this._mapper = mapper;
    }

    public async Task<ResponseDto<ClientDto>> CreateClientAsync(ClientCreateDto dto)
    {
        var allClients = await _context.Clients.ToListAsync();

        foreach (var client in allClients)
        {
            if(client.Identity == dto.Identity)
            {
                return new ResponseDto<ClientDto>
                {
                    StatusCode = 409,
                    Status = false,
                    Message = "Ya existe cliente con la misma identidad"
                };
            }
        }

        var clientEntity = _mapper.Map<ClientEntity>(dto);

        _context.Clients.Add(clientEntity);

        await _context.SaveChangesAsync();

        var clientDto = _mapper.Map<ClientDto>(clientEntity);

        return new ResponseDto<ClientDto>
        {
            StatusCode = 201,
            Status = true,
            Message = "Cliente creado existosamente",
            Data = clientDto
        };

    }
}
