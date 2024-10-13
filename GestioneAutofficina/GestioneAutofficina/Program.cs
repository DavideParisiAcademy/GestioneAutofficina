
using GestioneAutofficina.Models;
using GestioneAutofficina.Repository;
using GestioneAutofficina.Service;
using Microsoft.EntityFrameworkCore;

namespace GestioneAutofficina
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            #region
#if DEBUG
            builder.Services.AddDbContext<AutofficinaContext>(
                option => option.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseTest"))
                );

            builder.Services.AddScoped<RepoCliente>();
            builder.Services.AddScoped<RepoVeicolo>();
            builder.Services.AddScoped<ServiceVeicolo>();
            builder.Services.AddScoped<ServiceCliente>();
            builder.Services.AddScoped<ServiceClienteVeicolo>();


#else      
                builder.Services.AddDbContext<AutofficinaContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseProd"))
                );

#endif
            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
