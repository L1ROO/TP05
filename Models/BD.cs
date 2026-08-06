using Microsoft.Data.SqlClient;
using Dapper;
using TP05_LoginRegistro.Models;

namespace TP05_LoginRegistro.Models
{
    public class BD
    {
        private string _connectionString = @"Server=localhost;DataBase=tp05BD;Integrated Security=True;TrustServerCertificate=True;";
        public void AgregarUsuario(Usuario usuario)
        {
            string query = "INSERT INTO Usuario (NombreUsuario, Contrasenia, Nombre, Apellido, TipoUsuario) " +
                           "VALUES (@pNombreUsuario, @pContrasenia, @pNombre, @pApellido, @pTipoUsuario)";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Execute(query, new
                {
                    pNombreUsuario = usuario.NombreUsuario,
                    pContrasenia = usuario.Contrasenia,
                    pNombre = usuario.Nombre,
                    pApellido = usuario.Apellido,
                    pTipoUsuario = usuario.TipoUsuario
                });
            }
        }

        public Usuario BuscarUsuarioPorNombre(string nombreUsuario)
        {
            Usuario miUsuario = null;

            string query = "SELECT * FROM Usuario WHERE NombreUsuario = @pNombreUsuario";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                miUsuario = connection.QueryFirstOrDefault<Usuario>(query, new { pNombreUsuario = nombreUsuario });
            }

            return miUsuario;
        }

        public Usuario ValidarLogin(string nombreUsuario, string contrasenia)
        {
            Usuario miUsuario = null;

            string query = "SELECT * FROM Usuario WHERE NombreUsuario = @pNombreUsuario AND Contrasenia = @pContrasenia";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                miUsuario = connection.QueryFirstOrDefault<Usuario>(query, new
                {
                    pNombreUsuario = nombreUsuario,
                    pContrasenia = contrasenia
                });
            }

            return miUsuario;
        }
    }
}