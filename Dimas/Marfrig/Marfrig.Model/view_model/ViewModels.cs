namespace Marfrig.Model.view_model
{
    public class VmRelatorioCompra
    {
        public string Animal { get; set; }

        public long Quantidade { get; set; }

        public double Preco { get; set; }

        public double ValorTotal { get; set; }
    }

    public class VmGridCompra
    {
        public int Id { get; set; }

        public string Pecuarista { get; set; }

        public string DataEntrega { get; set; }

        public double ValorTotal { get; set; }
    }

    public class VmGridCompraItem
    {
        public int Id { get; set; }
        public string Animal { get; set; }

        public int Quantidade { get; set; }

        public double Preco { get; set; }

        public double ValorTotal { get; set; }
    }
}