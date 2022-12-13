using System;
using System.Collections.Generic;

namespace Marfrig.Model.data_model
{
    public class CompraGado : Base
    {
        public Marfrig.Model.data_model.Pecuarista Pecuarista { get; set; }

        public List<CompraGadoItem> CompraGadoItems { get; set; } = new List<CompraGadoItem>();

        public DateTime  DataEntrega { get; set; }

        public bool IndicaImpresso { get; set; }
    }
}