using Marfrig.Model.data_model;
using Marfrig.Model.view_model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Newtonsoft.Json;

namespace Marfrig.Model.infra
{
    public static class Extensions
    {
        public static DataTable ToDataTable<T>(this IEnumerable<T> self)
        {
            var properties = typeof(T).GetProperties();

            var dataTable = new DataTable();
            foreach (var info in properties)
                dataTable.Columns.Add(info.Name, Nullable.GetUnderlyingType(info.PropertyType)
                                                 ?? info.PropertyType);

            foreach (var entity in self)
                dataTable.Rows.Add(properties.Select(p => p.GetValue(entity)).ToArray());

            return dataTable;
        }

         public static IEnumerable<VmGridCompra> ToCompraGadoVm<T>(this IEnumerable<Model.data_model.CompraGado> self) => self.Select(compraGado => new VmGridCompra() { DataEntrega = compraGado.DataEntrega.ToString("d"), Id = compraGado.Id, Pecuarista = compraGado.Pecuarista.Nome, ValorTotal = compraGado.CompraGadoItems.Sum(o => (o.Quantidade * o.Animal.Preco)) }).ToList();

         public static IEnumerable<VmGridCompraItem> ToCompraGadoItemVm<T>(this IEnumerable<Model.data_model.CompraGadoItem> self) => self.Select(compraGado => new VmGridCompraItem() { Id = compraGado.Id,Animal = compraGado.Animal.Descricao, Preco = compraGado.Animal.Preco, Quantidade = compraGado.Quantidade, ValorTotal = compraGado.Quantidade * compraGado.Animal.Preco }).ToList();

        public static IEnumerable<VmRelatorioCompra> ToVmRelatorioCompramVm<T>(this IEnumerable<Model.data_model.CompraGadoItem> self) => self.Select(compraGado => new VmRelatorioCompra() {  Animal = compraGado.Animal.Descricao,Preco = compraGado.Animal.Preco, Quantidade = compraGado.Quantidade, ValorTotal = compraGado.Quantidade * compraGado.Animal.Preco }).ToList();



        public static T Clone<T>(this T self)
         {
             var json = JsonConvert.SerializeObject(self);
             var newInstance = JsonConvert.DeserializeObject<T>(json);
             return newInstance;
         }
    }
}