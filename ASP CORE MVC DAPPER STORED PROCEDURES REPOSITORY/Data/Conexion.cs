using System.Data.SqlClient;

namespace ASP_CORE_MVC_DAPPER_STORED_PROCEDURES_REPOSITORY.Data
{
    public class Conexion
    {
        private readonly string _connectionString;

        public Conexion(string valor)
        {
            _connectionString = valor;
        }

        public SqlConnection ObtenerConexion()
        {
            var conexion = new SqlConnection(_connectionString);
            conexion.Open();
            return conexion;
        }
    }
}
