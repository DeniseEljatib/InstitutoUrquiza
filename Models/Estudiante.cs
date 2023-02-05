using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InstitutoUrquiza.Models
{
    public class Estudiante
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(20), MinLength(1)] //Pongo 1 como MinLenght para permitir iniciales como nombre
        [Required(ErrorMessage = "Ingrese su nombre")] //DUDA - ESTO LO TENGO QUE PONER, SI VOY A INGRESAR AUTOMÁTICAMENTE TODOS LOS REGISTROS MEDIANTE UNA SEED???
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "El nombre ingresado no es válido. Por favor, intente nuevamente.")]
        [Display(Name = "Nombre")]
        public String Nombre { get; set; }

        [MaxLength(20), MinLength(2)] 
        [Required(ErrorMessage = "Ingrese su apellido")] //Permito apellidos de dos letras porque son habituales en países asiáticos. 
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "El apellido ingresado no es válido. Por favor, intente nuevamente.")]
        [Display(Name = "Apellido")]
        public String Apellido { get; set; }

        [MaxLength(8), MinLength(7)] //DUDA - ESTO NO ES NECESARIO ACÁ PORQUE LE PUSIMOS LA MIN/MAX LENGTH MÁS ABAJO? CHECK SI HAY QUE SACARLO
        [Required(ErrorMessage = "Ingrese su número de DNI.")]
        [RegularExpression("^[\\s\\S]{7,8}", ErrorMessage = "El DNI ingresado no es válido. Por favor, intente nuevamente.")] //DUDA - ESTÁ BIEN ESTA REGEX PARA UNA STRING QUE SÓLO ACEPTE NÚMEROS???
        [Display(Name = "DNI")]
        public String Dni { get; set; }

        [MaxLength(2), MinLength(7)] //DUDA - ES NECESARIO ESTO ACÁ? 
        [Required(ErrorMessage = "Ingrese su edad.")]
        [RegularExpression("^[\\s\\S]{1,2}", ErrorMessage = "La edad ingresada no es válida. Por favor, intente nuevamente.")] //DUDA - ESTÁ BIEN? 
        [Display(Name = "Edad")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "Ingrese su e-mail.")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "El e-mail ingresado no es válido. Por favor, intente nuevamente.")] //DUDA - cómo está armada esta Regex???
        [Display(Name = "e-mail")]
        public String Email { get; set; }

        [MaxLength(8), MinLength(8)] //DUDA - ESTO NO ES NECESARIO ACÁ PORQUE LE PUSIMOS LA MIN/MAX LENGTH MÁS ABAJO? CHECK SI HAY QUE SACARLO
        [Required(ErrorMessage = "Ingrese su número de celular.")]
        [RegularExpression("^[\\s\\S]{8,8}", ErrorMessage = "El celular ingresado no es válido. Por favor, intente nuevamente.")] //DUDA - ESTÁ BIEN ESTA REGEX PARA UNA STRING QUE SÓLO ACEPTE NÚMEROS???
        //Podemos validar el código de área o el 15 de alguna manera?
        [Display(Name = "Teléfono celular")]
        public String Celular { get; set; }

        public DateTime FechaIngreso { get; set; } //DUDA - CÓMO VALIDAMOS FECHA???


        public Boolean cuotaAlDia { get; set; }
    }
}
