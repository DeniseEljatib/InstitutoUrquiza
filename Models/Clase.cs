using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace InstitutoUrquiza.Models
{
    public class Clase

    {
      
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [EnumDataType(typeof(TipoActividad))]
        public TipoActividad Actividad { get; set; }

        [Required(ErrorMessage = "Indique el día y el horario deseados para la clase.")]
        [Display(Name = "Día y horario")]
        public DateTime horario { get; set; }

        //[Required(ErrorMessage = "Indique el profesor asignado.")]
        [Display(Name = "Profe")]
        public Profesor Profesor { get; set; }

        [Display(Name = "Profe")]
        public int ProfesorId { get; set; }


        //[Required(ErrorMessage = "Indique el/la alumno/a que solicita la clase.")]
        [Display(Name = "Alumno/a")]
        public Estudiante Estudiante { get; set; }

        [Display(Name = "Alumno/a")]
        public int EstudianteId { get; set; }


        //public List<Estudiante> Estudiantes { get; set; }

       
        [Display(Name = "Salón")]
        [EnumDataType(typeof(NumeroSalon))]
        public NumeroSalon Salon { get; set; }



    }
}
