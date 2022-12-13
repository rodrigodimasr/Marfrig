using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Marfrig.Data
{
    public class Pecuarista
    {
        private readonly IDbConnection _connection;
       public Pecuarista(string sqlConnection) =>
            (_connection) = (new SqlConnection(sqlConnection));
        
        public IEnumerable<Model.data_model.Pecuarista> Get() =>
            _connection.Query<Model.data_model.Pecuarista>("SELECT * FROM PECUARISTA (NOLOCK)");
    }
}