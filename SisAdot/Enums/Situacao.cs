using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SisAdot.Enums
{
    public enum Situacao
    {
        Adotado,
        Disponível,
        [Description("Dono Próprio")]
        DonoProprio
    }
}