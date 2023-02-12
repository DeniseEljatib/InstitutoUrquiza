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
        //TODO: CHECK SI NECESITO INCLUIR VALIDACIONES ACÁ 

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime horario { get; set; }

        //TODO: VALIDAR NUMEROS DE SALON 
        public int NumSalon { get; set; }

        public Profesor Profesor { get; set; }

        [EnumDataType(typeof(TipoActividad))] 
        public TipoActividad Actividad { get; set; }

        public List<Estudiante> Estudiantes { get; set; }

    }
}
