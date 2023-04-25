using Dapper;
using mapysApi.Data.Repositories;
using mapysApi.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace napysApi.Data.Repositories
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        private readonly MySQLConfiguration _connectionString;
        public CategoriaRepositorio(MySQLConfiguration ConnectionString)
        {
            _connectionString = ConnectionString;
        }

        // La clase MySqlConnection esta en el paquete de MySql.Data.MySqlClient
        protected MySqlConnection dbConnection()
        {
            // Aqui le estamos pasando el string de cadena conexion.
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public Task<IEnumerable<Categoria>> GetAllCategorias()
        {
            var db = dbConnection();
            var sql = @"SELECT codigo, nombre FROM categorias";
            return db.QueryAsync<Categoria>(sql, new { });
        }
    }
}
