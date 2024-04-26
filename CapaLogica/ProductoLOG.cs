using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class ProductoLOG
    {
        ProductoDAL _productoDAL;

        public int GuardarProducto(Producto producto)
        {
            _productoDAL = new ProductoDAL();

            return _productoDAL.Guardar(producto);
        }

        public Producto ObtenerProductoPorId(int codigo)
        {
            _productoDAL = new ProductoDAL();

            return _productoDAL.LeerPorId(codigo);
        }

        public int ActualizarProducto(Producto producto, int id)
        {
            _productoDAL = new ProductoDAL();

            return _productoDAL.Guardar(producto, id, true);
        }

        public List<Producto> ObtenerProductos()
        {
            _productoDAL = new ProductoDAL();

            return _productoDAL.Leer();
        }
    }
}
