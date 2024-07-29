using Ejercicio5Modulo3.Middlewares;
using Ejercicio5Modulo3.Repository;
using Ejercicio5Modulo3.Services;
using Ejercicio5Modulo3.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ejercicio5Modulo3
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

            // Inyección Dependencias
            var connection = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<Ejercicio5Modulo3Context>(opt =>
                    opt.UseSqlServer(connection));

            //Contenedor de dependencias
            builder.Services.AddScoped<IUsuarioService, UsuarioService>();

            builder.Services.AddScoped<CargarTUsuarios>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();


            app.MapControllers();

            app.UseMiddleware<CargarTUsuarios>();

            app.Run();
        }
    }
}