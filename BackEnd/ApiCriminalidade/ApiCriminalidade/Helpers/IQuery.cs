using Microsoft.Data.SqlClient;

namespace ApiCriminalidade.Helpers
{
    public interface IQuery
    {
        List<Dictionary<string, string>> Execute(string sql, string[] campos, SqlParameter[]? parametros);

        void ExecuteInsert(string sql, SqlParameter[]? parametros);
    }
}
