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

        public int GuardarProducto(Producto producto, int id = 0, bool esActualizacion = false)
        {
            _productoDAL = new ProductoDAL();

            return _productoDAL.Guardar(producto, id, esActualizacion);
        }

        public List<Producto> ObtenerProductos()
        {
            _productoDAL = new ProductoDAL();

            return _productoDAL.Leer();
        }
    }
}
