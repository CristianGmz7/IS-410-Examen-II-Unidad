using AutoMapper;
using ProyectoExamenU2.Database.Entities;
using ProyectoExamenU2.Dtos.Clients;
using ProyectoExamenU2.Dtos.Loans;

namespace ProyectoExamenU2.Helpers;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        MapsForClients();
    }

    private void MapsForClients()
    {
        CreateMap<ClientEntity, ClientDto>();
        CreateMap<ClientCreateDto, ClientEntity>();
    }

    private void MapsForLoans()
    {
        CreateMap<LoanCreateDto, LoanEntity>();
    }
} 
