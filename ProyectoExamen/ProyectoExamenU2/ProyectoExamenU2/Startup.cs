using Microsoft.EntityFrameworkCore;
using ProyectoExamenU2.Database;
using ProyectoExamenU2.Helpers;

namespace ProyectoExamenU2;

public class Startup
{
    private IConfiguration Configuration;

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services) 
    {
        //Mas o menos aqui se aplican las Data Annotations
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        //Add DbContext (comienza configuracion de base de datos)
        services.AddDbContext<ProyectoExamenU2Context>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

        // Add custom services
        ////services.AddTransient<ICategoriesService, CategoriesService>();
        //services.AddTransient<ICategoriesService, CategoriesSQLService>();
        //services.AddTransient<IAuthService, AuthService>();
        //services.AddTransient<IPostsService, PostsService>();

        // Add AutoMapper
        services.AddAutoMapper(typeof(AutoMapperProfile));

    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
