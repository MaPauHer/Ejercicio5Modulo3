using Ejercicio5Modulo3.Domain.Entities;
using Ejercicio5Modulo3.Domain.Entities.RandomUser.Response;
using Ejercicio5Modulo3.Repository;
using System.Text.Json;

namespace Ejercicio5Modulo3.Middlewares
{
    public class CargarTUsuarios : IMiddleware
    {
        private readonly Ejercicio5Modulo3Context _dbcontext;
        private readonly IConfiguration _configuration;

        public CargarTUsuarios(Ejercicio5Modulo3Context dbcontext, IConfiguration configuration)
        {
            _dbcontext = dbcontext;
            _configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext httpcontext, RequestDelegate next)
        {

            await next(httpcontext);

            HttpClient httpClient = new HttpClient();

            if (httpcontext.Request.Method == "POST" &&
                httpcontext.Request.Path == "/api/V1/Usuario/AddUsuarios" &&
                _dbcontext.Usuario.ToList().Count() == 0)
            {

                //url a consultar --> "https://randomuser.me/api/?results=3"

                var Address = new UriBuilder("https://randomuser.me/api");
                var query = System.Web.HttpUtility.ParseQueryString(string.Empty);
                query["results"] = _configuration.GetValue<int>("SEED_RESULT_NUMBER").ToString();
                Address.Query = query.ToString();
                var url = Address.ToString();

                //Console.WriteLine($"URL: {url}");

                var resultService = await httpClient.GetAsync(url);

                var responseRandomUsers = await resultService.Content.ReadAsStringAsync();

                //Console.WriteLine($"USUARIOS RESPUESTA: {responseRandomUsers}");

                var RamdomUsersResponse = JsonSerializer.Deserialize<GetRandomUserResponse>(responseRandomUsers);

                var resultados = RamdomUsersResponse.Results;

                foreach (Result resultado in resultados)
                {

                    Usuario NewUsuario = new Usuario()
                    {
                        Nombre = resultado.Name.First,
                        Apellido = resultado.Name.Last,
                        Edad = resultado.Dob.Age,
                        Genero = resultado.Gender,
                        Email = resultado.Email,
                        NombreUsuario = resultado.Login.Username,
                        Password = resultado.Login.Password,
                        Ciudad = resultado.Location.City,
                        Estado = resultado.Location.State,
                        Pais = resultado.Location.Country
                    };

                    await _dbcontext.Usuario.AddAsync(NewUsuario);

                }

                await _dbcontext.SaveChangesAsync();

            }

        }
    }
}