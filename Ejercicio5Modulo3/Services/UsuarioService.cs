using Ejercicio5Modulo3.Domain.Entities;
using Ejercicio5Modulo3.Domain.Entities.GetUsuarios;
using Ejercicio5Modulo3.Repository;
using Ejercicio5Modulo3.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Ejercicio5Modulo3.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly Ejercicio5Modulo3Context _context;
        private readonly IConfiguration _configuration;

        public UsuarioService(Ejercicio5Modulo3Context context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task AddUsuariosAsync()
        {
            await Task.CompletedTask;
        }

        public async Task<List<Usuario>> GetUsuariosAsync(GetUsuariosQueryParameters parameters)
        {

            var query = _context.Usuario.AsQueryable();

            if (!string.IsNullOrEmpty(parameters.Genero) &&
                !string.IsNullOrEmpty(parameters.Pais))
            {
                query = query.Where(u => u.Genero.Equals(parameters.Genero) &&
                                         u.Pais.Equals(parameters.Pais));
            }
            else 
            {
                if (!string.IsNullOrEmpty(parameters.Pais))
                {
                    query = query.Where(u => u.Pais.Equals(parameters.Pais));
                }
                else
                {
                    if (!string.IsNullOrEmpty(parameters.Genero))
                    {
                        query = query.Where(u => u.Genero.Equals(parameters.Genero));
                    }
                }
            }

            var usuarios = await query.ToListAsync();

            return usuarios;
        }
    }
}
