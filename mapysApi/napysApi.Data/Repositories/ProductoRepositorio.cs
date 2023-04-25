using Dapper;
using mapysApi.Data.Repositories;
using mapysApi.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace napysApi.Data.Repositories
{
    public class ProductoRepositorio : IProductoRepositorio
    {
        private readonly MySQLConfiguration _connectionString;
        public ProductoRepositorio(MySQLConfiguration ConnectionString)
        {
            _connectionString = ConnectionString;
        }

        // La clase MySqlConnection esta en el paquete de MySql.Data.MySqlClient
        protected MySqlConnection dbConnection()
        {
            // Aqui le estamos pasando el string de cadena conexion.
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<bool> DeleteProducto(Producto producto)
        {
            var db = dbConnection();
            var sql = @"DELETE FROM productos WHERE codigo = @Codigo";
            
            var result = await db.ExecuteAsync(sql,new { Codigo = producto.Codigo });
            return result > 0;
        }

        public Task<IEnumerable<ProductoCategoria>> GetAllProductos(string tipoProducto)
        {
            var db = dbConnection();
            // select categorias.nombre, productos.nombre, productos.precio from productos INNER JOIN categorias on productos.CATEGORIAS_codigo = categorias.codigo where categorias.nombre like "%aretes%"
            var sql = @"SELECT productos.codigo, categorias.nombre as NombreCategoria, productos.nombre, productos.precio, productos.imagen, productos.descuento FROM productos INNER JOIN categorias ON productos.CATEGORIAS_codigo = categorias.codigo WHERE categorias.nombre LIKE @TipoProducto";
            return db.QueryAsync<ProductoCategoria>(sql, new { TipoProducto = "%" + tipoProducto + "%" });

        }

        public Task<Producto> GetProductoById(int codigo)
        {
            var db = dbConnection();
            var sql = @"select codigo, nombre, precio, CATEGORIAS_codigo, imagen, fecha, descuento FROM productos 
                        WHERE  
                        codigo = @Codigo";
            return db.QueryFirstOrDefaultAsync<Producto>(sql, new { Codigo = codigo });
        }

        public Task<IEnumerable<Producto>> GetProductosDescuento()
        {
            var db = dbConnection();
            var sql = @"select codigo, nombre, precio, CATEGORIAS_codigo, imagen, fecha, descuento FROM productos WHERE descuento > 0";
            return db.QueryAsync<Producto>(sql, new { });
        }

        public async Task<bool> InsertProducto(Producto producto)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO productos (nombre, precio, CATEGORIAS_codigo, imagen, fecha, descuento) VALUES
                        (@Nombre, @Precio, @CATEGORIAS_CODIGO, @Imagen, @Fecha, @Descuento)";
            var result = await db.ExecuteAsync(sql, new 
            { producto.Nombre, producto.Precio, producto.CATEGORIAS_CODIGO, producto.Imagen, producto.Fecha, producto.Descuento });

            return result > 0;
        }

        public async Task<bool> Update(Producto producto)
        {
            var db = dbConnection();
            var sql = @"UPDATE productos SET
                        codigo = @Codigo,
                        nombre = @Nombre,
                        precio = @Precio,
                        CATEGORIAS_codigo = @CATEGORIAS_CODIGO,
                        imagen = @Imagen,
                        fecha = @Fecha,
                        descuento = @Descuento
                        WHERE codigo = @Codigo";
            var result = await db.ExecuteAsync(sql, new
            { producto.Codigo, producto.Nombre, producto.Precio, producto.CATEGORIAS_CODIGO, producto.Imagen, producto.Fecha, producto.Descuento });

            return result > 0;
        }
    }
}
