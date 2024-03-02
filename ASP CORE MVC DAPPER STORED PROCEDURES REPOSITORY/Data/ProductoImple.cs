using System.Data;
using ASP_CORE_MVC_DAPPER_STORED_PROCEDURES_REPOSITORY.Models;
using Dapper;

namespace ASP_CORE_MVC_DAPPER_STORED_PROCEDURES_REPOSITORY.Data
{
    public class ProductoImple : IProducto
    {
        private readonly Conexion _conexion;

        public ProductoImple(Conexion conexion)
        {
            _conexion = conexion;
        }
        public void ActualizarProducto(Producto producto)
        {
            using (var conexion = _conexion.ObtenerConexion())
            {
                var parametros = new DynamicParameters();
                parametros.Add("@Id", producto.Id, DbType.Int32);
                parametros.Add("@Nombre", producto.Nombre, DbType.String);
                parametros.Add("@Precio", producto.Precio, DbType.Decimal);
                conexion.Execute("SP_ActualizarProducto", parametros, commandType: CommandType.StoredProcedure);
            }
        }

        public void EliminarProducto(int id)
        {
            using (var conexion = _conexion.ObtenerConexion())
            {
                var parametros = new DynamicParameters();
                parametros.Add("@Id", id, DbType.Int32);
                conexion.Execute("SP_EliminarProducto", parametros, commandType: CommandType.StoredProcedure);
            }
        }

        public void InsertarProducto(Producto producto)
        {
            using (var conexion = _conexion.ObtenerConexion())
            {
                var parametros = new DynamicParameters();
                parametros.Add("@Nombre", producto.Nombre, DbType.String);
                parametros.Add("@Precio", producto.Precio, DbType.Decimal);
                conexion.Execute("SP_InsertarProducto", parametros, commandType: CommandType.StoredProcedure);
            }
        }

        public Producto ObtenerProductoPorId(int id)
        {
            using (var conexion = _conexion.ObtenerConexion())
            {
                var parametros = new DynamicParameters();
                parametros.Add("@Id", id, DbType.Int32);
                return conexion.QueryFirstOrDefault<Producto>("SP_ObtenerProductoPorId", parametros, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<IProducto> ObtenerProductos()
        {
            using (var conexion = _conexion.ObtenerConexion())
            {
                return (IEnumerable<IProducto>)conexion.Query<Producto>("SP_ObtenerProductos", commandType: CommandType.StoredProcedure).ToList();
            }
    
        }
    }
}
