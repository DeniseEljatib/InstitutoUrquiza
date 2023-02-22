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
        [Required(ErrorMessage = "Ingrese el nombre.")] 
        [Display(Name = "Nombre")]
        public String Nombre { get; set; }

        [MaxLength(20), MinLength(2)]
        [Required(ErrorMessage = "Ingrese el apellido.")] //Permito apellidos de dos letras porque son habituales en países asiáticos. 
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "El apellido ingresado no es válido. Por favor, intente nuevamente.")]
        [Display(Name = "Apellido")]
        public String Apellido { get; set; }

        [Required(ErrorMessage = "Ingrese el número de DNI.")]
        [RegularExpression("^[\\s\\S]{7,8}", ErrorMessage = "El DNI ingresado no es válido. Por favor, intente nuevamente.")] //TODO: CHECK SI ESTÁ BIEN ESTA REGEX PARA UNA STRING QUE SÓLO ACEPTE NÚMEROS
        [Display(Name = "DNI")]
        public String Dni { get; set; }

        [Required(ErrorMessage = "Ingrese la edad.")]
        [RegularExpression("^[\\s\\S]{1,2}", ErrorMessage = "La edad ingresada no es válida. Por favor, intente nuevamente.")]
        [Display(Name = "Edad")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "Ingrese el e-mail.")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "El e-mail ingresado no es válido. Por favor, intente nuevamente.")] 
        //TODO: tratar de entender cómo está armada esta Regex???
        [Display(Name = "e-mail")]
        public String Email { get; set; }

        [Required(ErrorMessage = "Ingrese el número de celular.")]
        [RegularExpression("^[\\s\\S]{10,10}", ErrorMessage = "El celular ingresado no es válido. Por favor, intente nuevamente.")] 
        //TODO: CHECK SI ESTÁ BIEN ESTA REGEX PARA UNA STRING QUE SÓLO ACEPTE NÚMEROS
        //TODO: CHECK si puedo validar el código de área o el 15 de alguna manera
        [Display(Name = "Tel. celular")]
        public String Celular { get; set; }

        [Required(ErrorMessage = "Indique la fecha de ingreso.")]
        [Display(Name = "Fecha de Ingreso")]
        public DateTime FechaIngreso { get; set; } 
        


      
        // public Boolean cuotaAlDia { get; set { "Sí", "No"}; }
        public String _cuotaAlDia;


        [Display(Name = "Nivel")]
        [EnumDataType(typeof(Nivel))]
        public Nivel Nivel { get; set; }

        [Required(ErrorMessage = "Dato inválido. Por favor, indique si el estudiante tiene la cuota al día ingresando 'SI' o 'NO'.")]
        [Display(Name = "¿Cuota al día?")]
        public String cuotaAlDia

          {
            get { return _cuotaAlDia; }
            set
            {
                if (value.ToUpper() == "SI" || value.ToUpper() == "SÍ")
                {
                    _cuotaAlDia = "SI";

                }

                else if (value.ToUpper() == "NO" )
                {
                    _cuotaAlDia = "NO";

                }
            }

        }




    }
}
