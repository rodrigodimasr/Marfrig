using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Marfrig.Data
{
    public class CompraGadoItem
    {
        private readonly IDbConnection _connection;
        public CompraGadoItem(string sqlConnection) => (_connection) = (new SqlConnection(sqlConnection));
        public IEnumerable<Model.data_model.CompraGadoItem> ByCompraId(int id) =>
            _connection.Query<Model.data_model.CompraGadoItem, Model.data_model.Animal, Model.data_model.CompraGadoItem>("SELECT CI.*,AN.* FROM COMPRAGADOITEM AS CI  JOIN ANIMAL AS AN ON CI.IDANIMAL = AN.ID  WHERE CI.IDCOMPRAGADO = @IDCOMPRAGADO", (compraGadoItem, animal) =>
            {
                compraGadoItem.Animal = animal;
                return compraGadoItem;
            }, splitOn: "ID", param: new { IDCOMPRAGADO = id});
    }
}