using mapysApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mapysApi.Data.Repositories
{
    public interface IProductoRepositorio
    {
        Task<IEnumerable<ProductoCategoria>> GetAllProductos(string tipoProducto);
        Task<Producto> GetProductoById(int codigo);
        Task<IEnumerable<Producto>> GetProductosDescuento();
        Task<bool> InsertProducto(Producto producto);
        Task<bool> Update(Producto producto);
        Task<bool> DeleteProducto(Producto producto);
    }
}
