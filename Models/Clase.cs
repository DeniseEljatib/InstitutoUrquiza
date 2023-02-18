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

        [Display(Name = "Día y horario")]
        public DateTime horario { get; set; }


        [EnumDataType(typeof(TipoActividad))]
        public TipoActividad Actividad { get; set; }


        [Display(Name = "Profesor")]
        public Profesor Profesor { get; set; }

        [Display(Name = "Profesor")]
        public int ProfesorId { get; set; }

     

        [Display(Name = "Estudiante")]
        public Estudiante Estudiante { get; set; }

        [Display(Name = "Estudiante")]
        public int EstudianteId { get; set; }


        //public List<Estudiante> Estudiantes { get; set; }

        [Display(Name = "Salón")]
        [EnumDataType(typeof(NumeroSalon))]
        public NumeroSalon Salon { get; set; }



    }
}
