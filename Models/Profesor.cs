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
        [Required(ErrorMessage = "Ingrese el nombre.")] //TODO: check si tengo que poner esto (idem Estudiante)
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "El nombre ingresado no es válido. Por favor, intente nuevamente.")]
        [Display(Name = "Nombre")]
        public String Nombre { get; set; }

        [MaxLength(20), MinLength(2)]
        [Required(ErrorMessage = "Ingrese el apellido.")] //Permito apellidos de dos letras porque son habituales en países asiáticos. 
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "El apellido ingresado no es válido. Por favor, intente nuevamente.")]
        [Display(Name = "Apellido")]
        public String Apellido { get; set; }


        [Required(ErrorMessage = "Ingrese el número de DNI.")] //TODO: Esto lo puedo sacar, no? 
        [RegularExpression("^[\\s\\S]{7,8}", ErrorMessage = "El DNI ingresado no es válido. Por favor, intente nuevamente.")] //TODO: CHECK SI ESTÁ BIEN ESTA REGEX PARA UNA STRING QUE SÓLO ACEPTE NÚMEROS
        [Display(Name = "DNI")]
        public String Dni { get; set; }


        [Required(ErrorMessage = "Ingrese el e-mail.")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "El e-mail ingresado no es válido. Por favor, intente nuevamente.")] 
        public String Email { get; set; }

        [Required(ErrorMessage = "Ingrese el número de celular.")]
        [RegularExpression("^[\\s\\S]{10,10}", ErrorMessage = "El celular ingresado no es válido. Por favor, intente nuevamente.")] //TODO: CHECK SI ESTÁ BIEN ESTA REGEX PARA UNA STRING QUE SÓLO ACEPTE NÚMEROS
        [Display(Name = "Tel. celular")]
        public String Celular { get; set; }

        [Required(ErrorMessage = "Indique la fecha de ingreso.")]
        [Display(Name = "Fecha de Ingreso")]
        public DateTime FechaIngreso { get; set; }

        
        public String _esActivo;

        [Required(ErrorMessage = "Indique si el profesor está actualmente dando clases en el Instituto.")]
        [Display(Name = "¿Profe activo/a?")]
        public String esActivo
        {
            get { return _esActivo; }
            set
            {
                if (value.ToLower() == "si" || value.ToLower() == "no")    {
                    _esActivo = value.ToLower(); 
                   
                }
                else
                {
                    _esActivo = "no";

                }
            }

        }

    }
}

