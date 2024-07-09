using ApiCriminalidade.Models;
using Microsoft.Data.SqlClient;
using System.Configuration;

namespace ApiCriminalidade.Helpers
{
    public class Query :IQuery
    {

        private readonly IConfiguration _connection;

        public Query(IConfiguration connection)
        {
            _connection = connection;
        }

        
        public List<Dictionary<string, string>> ExecuteReader(string sql, string[] campos, SqlParameter[]? parametros)
        {        
            List<Dictionary<string, string>> resultados = new List<Dictionary<string, string>>();

            var stringConn = _connection.GetConnectionString("DefaultConnection");
            using (SqlConnection connection = new SqlConnection(stringConn))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                if (parametros != null)
                {
                    foreach (var parametro in parametros)
                    {
                        command.Parameters.AddWithValue(parametro.ParameterName,parametro.Value);
                    }
                }
                


                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                        foreach (var campo in campos)
                        {                           
                            keyValuePairs.Add(campo, dataReader[campo].ToString());
                        }
                        resultados.Add(keyValuePairs);
                    }
                        
                    
                }
                connection.Close();
            }

            return resultados;


        }

        public void ExecuteNonQuery(string sql, SqlParameter[]? parametros)
        {
            var stringConn = _connection.GetConnectionString("DefaultConnection");
            using (SqlConnection connection = new SqlConnection(stringConn))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                if (parametros != null)
                {
                    foreach (var parametro in parametros)
                    {
                        command.Parameters.AddWithValue(parametro.ParameterName, parametro.Value);
                    }
                }

                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    
                }
                finally
                {
                    connection.Close();
                }
            }
        }

    }
}
