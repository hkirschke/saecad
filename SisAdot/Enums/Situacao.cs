using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SisAdot.Enums
{
    public enum Situacao
    {
        Adotado,
        Disponível,
        [Display(Name = "Dono Próprio")]
        DonoProprio
    }
}