using Microsoft.EntityFrameworkCore;

namespace ProyectoExamenU2.Database;

public class ProyectoExamenU2Context : DbContext
{
    public ProyectoExamenU2Context(DbContextOptions options) : base(options)
    {
        //posiblemente agregar el IAuthService
    }
}

//aqui irian las tablas, modificacion del savechangesaync....
