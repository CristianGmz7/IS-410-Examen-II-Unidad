using AutoMapper;
using ProyectoExamenU2.Database;
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

    //Metodo crear 
}
