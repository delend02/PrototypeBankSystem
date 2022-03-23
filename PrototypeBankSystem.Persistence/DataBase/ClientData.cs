using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace PrototypeBankSystem.Persistence.DataBase
{
    public class ClientData
    {
        private const string ConnectionString = @"Server=.\SQLExpress;Database=PrototypeBankSystemDB;Trusted_Connection=True;MultipleActiveResultSets=true;User ID=root;pwd=root";

        public async Task<IEnumerable<T>> LoadData<T>(string sql, object parameters, CancellationToken cancellationToken = default)
        {
            using IDbConnection connection = new SqlConnection(ConnectionString);
           
            var rows = await connection.QueryAsync<T>(new CommandDefinition(sql, parameters, cancellationToken: cancellationToken));

            return rows;
        }

        public async Task<T> LoadSingle<T>(string sql, object parameters, CancellationToken cancellationToken = default)
        {
            using IDbConnection connection = new SqlConnection(ConnectionString);

            var row = await connection.QuerySingleAsync<T>(new CommandDefinition(sql, parameters, cancellationToken: cancellationToken));

            return row;
        }

        public async Task<bool> SaveData(string sql, object parameters = default)
        {
            using IDbConnection connection = new SqlConnection(ConnectionString);

            await connection.ExecuteAsync(sql, parameters);
            return true;
            
        }

        //public async Task<TReturn> LoadDataMultipleSingle<T1, T2, TReturn>(string sql, object parameters,
        //    Func<T1, T2, TReturn> dataBound, CancellationToken cancellationToken = default)
        //{
        //    using IDbConnection connection = new SqlConnection(ConnectionString);

        //    var rows = await connection.QueryAsync(new CommandDefinition(sql, parameters, cancellationToken: cancellationToken));

        //    return rows;
        //}

    }
}
