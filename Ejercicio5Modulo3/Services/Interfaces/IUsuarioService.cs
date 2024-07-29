using Ejercicio5Modulo3.Domain.Entities;
using Ejercicio5Modulo3.Domain.Entities.GetUsuarios;

namespace Ejercicio5Modulo3.Services.Interfaces
{
    public interface IUsuarioService
    {

        public Task<List<Usuario>> GetUsuariosAsync(GetUsuariosQueryParameters parameters);
     
        public Task AddUsuariosAsync();

    }
}
