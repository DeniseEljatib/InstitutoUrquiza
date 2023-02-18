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
        [Required(ErrorMessage = "Ingrese su nombre")] //TODO: Check si tengo que poner esto, si voy a ingresar automáticamente los registros mediante una seed
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

        [Required(ErrorMessage = "Ingrese su edad.")]
        [RegularExpression("^[\\s\\S]{1,2}", ErrorMessage = "La edad ingresada no es válida. Por favor, intente nuevamente.")]
        [Display(Name = "Edad")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "Ingrese su e-mail.")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "El e-mail ingresado no es válido. Por favor, intente nuevamente.")] 
        //TODO: tratar de entender cómo está armada esta Regex???
        [Display(Name = "e-mail")]
        public String Email { get; set; }

        [Required(ErrorMessage = "Ingrese su número de celular.")]
        [RegularExpression("^[\\s\\S]{10,10}", ErrorMessage = "El celular ingresado no es válido. Por favor, intente nuevamente.")] 
        //TODO: CHECK SI ESTÁ BIEN ESTA REGEX PARA UNA STRING QUE SÓLO ACEPTE NÚMEROS
        //TODO: CHECK si puedo validar el código de área o el 15 de alguna manera
        [Display(Name = "Teléfono celular")]
        public String Celular { get; set; }

        [Required(ErrorMessage = "Ingrese la fecha de ingreso.")]
        [Display(Name = "Fecha de Ingreso")]
        public DateTime FechaIngreso { get; set; } 
        //TODO: Check si puedo validar la fecha? // POR AHORA VOY A DEJAR REQUIRED, pero no lo valido. 


        [Required(ErrorMessage = "Indique si el estudiante tiene la cuota al día.")]
        [Display(Name = "¿Cuota al día?")]
        // public Boolean cuotaAlDia { get; set { "Sí", "No"}; }
        public String _cuotaAlDia;


        [Display(Name = "Nivel")]
        [EnumDataType(typeof(Nivel))]
        public Nivel Nivel { get; set; }

        public String cuotaAlDia
        {
            get { return _cuotaAlDia; }
            set
            {
                if (value.ToLower() == "si" || value.ToLower() == "no") {
                    _cuotaAlDia = value.ToLower(); 
                   
                }
                else
                {
                    _cuotaAlDia = "no";

                }
            }

        }


    }
}
