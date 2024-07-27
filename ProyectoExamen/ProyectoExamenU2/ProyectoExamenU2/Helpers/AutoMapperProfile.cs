using AutoMapper;
using ProyectoExamenU2.Database.Entities;
using ProyectoExamenU2.Dtos.Clients;

namespace ProyectoExamenU2.Helpers;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        MapsForClients();
    }

    private void MapsForClients()
    {
        CreateMap<ClientCreateDto, ClientEntity>();
    }
} 
