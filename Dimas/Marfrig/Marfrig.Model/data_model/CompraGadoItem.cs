namespace Marfrig.Model.data_model
{
    public class CompraGadoItem : Base
    {
        public int IdCompraGado { get; set; } 
        public Animal Animal { get; set; } 
        public int Quantidade { get; set; }
    }
}