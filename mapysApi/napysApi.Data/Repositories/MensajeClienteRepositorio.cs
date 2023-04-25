using Dapper;
using mapysApi.Model;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mapysApi.Data.Repositories
{
    public class MensajeClienteRepositorio : IMensajeClienteRepositorio
    {
        private readonly MySQLConfiguration _connectionString;
        public MensajeClienteRepositorio(MySQLConfiguration ConnectionString)
        {
            _connectionString = ConnectionString;
        }

        // La clase MySqlConnection esta en el paquete de MySql.Data.MySqlClient
        protected MySqlConnection dbConnection()
        {
            // Aqui le estamos pasando el string de cadena conexion.
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<bool> InsertMensajeCliente(MensajeCliente mensajeCliente)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO mensaje_cliente (nombre, email, telefono, ciudad, mensaje, created_at) VALUES (@Nombre, @email, @Telefono, @Ciudad, @Mensaje, @CreatedAt);";
            var result = await db.ExecuteAsync(sql, mensajeCliente);

            return result > 0;
        }

    }
}
