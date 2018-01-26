using System.ComponentModel.DataAnnotations;

namespace empleados.Models
{
    

    public class RegisterEmployeeViewModel
    {

        [Display(Name = "Id")]
        public int id { get; set; }

        [Required]
        [StringLength(8, ErrorMessage = "La cantidad de caracteres de {0} debe ser al menos {2}.", MinimumLength = 4)]
        [DataType(DataType.Text)]
        [Display(Name = "Cedula")]
        public string cedula { get; set; }

        [Required]
        [Display(Name = "Nombre de usuario")]
        public string nombres { get; set; }


        [Display(Name = "Apellidos")]
        public string apellidos { get; set; }


        [Display(Name = "Telefono")]
        public string telefono { get; set; }
      

    }
}
