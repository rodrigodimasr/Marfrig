using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Marfrig.Data
{
    public class Animal
    {
        private readonly IDbConnection _connection;
       public Animal(string sqlConnection) =>
            (_connection) = (new SqlConnection(sqlConnection));
        
        public IEnumerable<Model.data_model.Animal> Get() =>
            _connection.Query<Model.data_model.Animal>("SELECT * FROM ANIMAL (NOLOCK)");
    }
}