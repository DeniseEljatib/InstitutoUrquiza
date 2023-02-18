using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace InstitutoUrquiza.Models
{
    public enum NumeroSalon
    {
        [Display(Name = "Aro PB")]
        ARO_PB,

        [Display(Name = "Tela PB")]
        TELA_PB,

        [Display(Name = "Trapecio PB")]
        TRAPECIO_PB,

        [Display(Name = "Integral PB")]
        INTEGRAL_PB,

        [Display(Name = "Integral Primer Piso")]
        INTEGRAL_PRIMER_PISO

    }
}

