using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SisAdot.Enums
{
    public enum PorteAnimal
    {
        Pequeno = 1,
        [Description("Médio")]
        Medio = 2,
        Grande = 3,
    }
}