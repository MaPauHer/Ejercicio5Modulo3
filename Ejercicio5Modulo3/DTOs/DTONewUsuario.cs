using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Ejercicio5Modulo3.Domain.DTOs
{
    public class DTONewUsuario
    {


        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string Genero { get; set; }
        public string Email { get; set; }
        public string NombreUsuario { get; set; }
        public string Password { get; set; }
        public string Ciudad { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }

        //--id	
        //--nombre	
        //--apellido	
        //--edad	
        //--genero	
        //--email	
        //--nombre_usuario	
        //--password	
        //--ciudad	
        //--estado	
        //--pais

    }
}