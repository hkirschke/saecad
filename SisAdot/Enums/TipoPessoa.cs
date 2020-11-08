using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SisAdot.Enums
{
    public enum TipoPessoa
    {
        [Display(Name = "Física")]
        Fisica = 1,
        [Display(Name = "Jurídica")]
        Juridica = 2
    }
}