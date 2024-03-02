using ASP_CORE_MVC_DAPPER_STORED_PROCEDURES_REPOSITORY.Models;

namespace ASP_CORE_MVC_DAPPER_STORED_PROCEDURES_REPOSITORY.Data
{
    public interface IProducto
    {
        IEnumerable<IProducto> ObtenerProductos();
        Producto ObtenerProductoPorId(int id);
        void InsertarProducto(Producto producto);
        void ActualizarProducto(Producto producto);
        void EliminarProducto(int id);
    }
}
