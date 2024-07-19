

using Microsoft.Data.SqlClient;

namespace ApiCriminalidade.Application.Helpers
{
    public interface IQuery
    {
        List<Dictionary<string, string>> ExecuteReader(string sql, string[] campos, SqlParameter[]? parametros);

        void ExecuteNonQuery(string sql, SqlParameter[]? parametros);
    }
}
