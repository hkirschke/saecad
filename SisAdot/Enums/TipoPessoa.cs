using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SisAdot.Enums
{
    public enum TipoPessoa
    {
        [Description("Física")]
        Fisica =1,
        [Description("Jurídica")]
        Juridica =2 
    }
}