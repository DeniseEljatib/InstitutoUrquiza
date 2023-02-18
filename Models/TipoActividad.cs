using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace InstitutoUrquiza.Models
{
    public enum TipoActividad
    {
        Tela, 
        Aro,
        Trapecio,
        [Display(Name = "Integral aéreo")]
        INTEGRAL_AEREO

    }
}
