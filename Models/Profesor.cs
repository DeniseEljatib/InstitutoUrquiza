using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InstitutoUrquiza.Models
{
    public class Profesor
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(20), MinLength(1)] //Pongo 1 como MinLenght para permitir iniciales como nombre
        [Required(ErrorMessage = "Ingrese su nombre")] //TODO: check si tengo que poner esto (idem Estudiante)
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "El nombre ingresado no es válido. Por favor, intente nuevamente.")]
        [Display(Name = "Nombre")]
        public String Nombre { get; set; }

        [MaxLength(20), MinLength(2)]
        [Required(ErrorMessage = "Ingrese su apellido")] //Permito apellidos de dos letras porque son habituales en países asiáticos. 
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "El apellido ingresado no es válido. Por favor, intente nuevamente.")]
        [Display(Name = "Apellido")]
        public String Apellido { get; set; }


        [Required(ErrorMessage = "Ingrese su número de DNI.")]
        [RegularExpression("^[\\s\\S]{7,8}", ErrorMessage = "El DNI ingresado no es válido. Por favor, intente nuevamente.")] //TODO: CHECK SI ESTÁ BIEN ESTA REGEX PARA UNA STRING QUE SÓLO ACEPTE NÚMEROS
        [Display(Name = "DNI")]
        public String Dni { get; set; }


        [Required(ErrorMessage = "Ingrese su e-mail.")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "El e-mail ingresado no es válido. Por favor, intente nuevamente.")] 
        public String Email { get; set; }

        [Required(ErrorMessage = "Ingrese su número de celular.")]
        [RegularExpression("^[\\s\\S]{8,8}", ErrorMessage = "El celular ingresado no es válido. Por favor, intente nuevamente.")] //TODO: CHECK SI ESTÁ BIEN ESTA REGEX PARA UNA STRING QUE SÓLO ACEPTE NÚMEROS
        [Display(Name = "Teléfono celular")]
        public String Celular { get; set; }

        public DateTime FechaIngreso { get; set; }

        public String _esActivo; 
        public String esActivo  
        {
            get { return _esActivo; }
            set
            {
                    if (value.ToLower() == "si" || value.ToLower() == "no")
                    {
                        _esActivo = value.ToLower(); //TODO: VERIFICAR SI HAY QUE AGREGAR THROW EXCEPTION
                    }
                }

            }

        }
}
