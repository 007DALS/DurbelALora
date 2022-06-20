using DurbelALora.Utils;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DurbelALora.Model
{
    public class Persona
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "El campo Nombre está vacío")]
        [StringLength(30, ErrorMessage = "El Nombre es muy largo")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo Fecha Nacimiento está vacío")]
        [MyDateAttribute(ErrorMessage = "La Fecha de nacimiento no es correcta")]
        public DateTime FechaDeNacimiento { get; set; } = DateTime.Now;

       
    }
}
