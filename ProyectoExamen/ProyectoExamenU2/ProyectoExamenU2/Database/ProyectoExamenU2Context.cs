using Microsoft.EntityFrameworkCore;
using ProyectoExamenU2.Database.Entities;

namespace ProyectoExamenU2.Database;

public class ProyectoExamenU2Context : DbContext
{
    public ProyectoExamenU2Context(DbContextOptions options) : base(options)
    {
        //posiblemente agregar el IAuthService
    }

    //aqui irian las tablas, modificacion del savechangesaync...
    public DbSet<ClientEntity> Clients { get; set; }
    public DbSet<LoanEntity> Loans { get; set; }
    public DbSet<AmortizationPlanEntity> AmortizationPlans { get; set; }
}
