using static master_API.Controllers.UsuarioController;
using System.Data.SqlClient;
using System.Data;
using master_API.Models;

namespace master_API.Repository
{
    public class ADO_Usuario
    {

        public static List<Usuario> TraerUsuarios()
        {
            var listaUsuario = new List<Usuario>();

            using (SqlConnection con = new SqlConnection(General.connetcionString()))

            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM Usuario;";

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var us = new Usuario();

                    us.Id = Convert.ToInt32(reader.GetValue(0));
                    us.Nombre = reader.GetValue(1).ToString();
                    us.Apellido = reader.GetValue(2).ToString();
                    us.NombreUsuario = reader.GetValue(3).ToString();
                    us.Contraseña = reader.GetValue(4).ToString();
                    us.Mail = reader.GetValue(5).ToString();

                    listaUsuario.Add(us);
                }
                reader.Close();

            }
            return listaUsuario;
        }

        public static Usuario TraerUsuariosPorId(string NombreUsuario)
        {
            var listaUsuario = new Usuario();

            using (SqlConnection con = new SqlConnection(General.connetcionString()))

            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM Usuario WHERE NombreUsuario = @nomUsu;";

                var param = new SqlParameter();
                param.ParameterName = "nomUsu";
                param.SqlDbType = SqlDbType.VarChar;
                param.Value = NombreUsuario;
                cmd.Parameters.Add(param);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    listaUsuario.Id = Convert.ToInt32(reader.GetValue(0));
                    listaUsuario.Nombre = reader.GetValue(1).ToString();
                    listaUsuario.Apellido = reader.GetValue(2).ToString();
                    listaUsuario.NombreUsuario = reader.GetValue(3).ToString();
                    listaUsuario.Contraseña = reader.GetValue(4).ToString();
                    listaUsuario.Mail = reader.GetValue(5).ToString();
                }
                reader.Close();

            }
            return listaUsuario;
        }

        internal static void ModificarUsuario(Usuario us, int id)
        {
            using (SqlConnection con = new SqlConnection(General.connetcionString()))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE Usuario " +
                    "SET Nombre = @paramNom, Apellido = @paramApe, NombreUsuario = @paramNomUs, Contraseña = @paramCon, Mail = @paramMail " +
                    "WHERE Id = @paramIdUs;";

                var paramNombre = new SqlParameter();
                paramNombre.ParameterName = "paramNom";
                paramNombre.SqlDbType = SqlDbType.VarChar;
                paramNombre.Value = us.Nombre;

                var paramApellido = new SqlParameter();
                paramApellido.ParameterName = "paramApe";
                paramApellido.SqlDbType = SqlDbType.VarChar;
                paramApellido.Value = us.Apellido;

                var paramNombreUsuario = new SqlParameter();
                paramNombreUsuario.ParameterName = "paramNomUs";
                paramNombreUsuario.SqlDbType = SqlDbType.VarChar;
                paramNombreUsuario.Value = us.NombreUsuario;

                var paramContras = new SqlParameter();
                paramContras.ParameterName = "paramCon";
                paramContras.SqlDbType = SqlDbType.VarChar;
                paramContras.Value = us.Contraseña;

                var paramMail = new SqlParameter();
                paramMail.ParameterName = "paramMail";
                paramMail.SqlDbType = SqlDbType.VarChar;
                paramMail.Value = us.Mail;


                var paramIdUsuario = new SqlParameter();
                paramIdUsuario.ParameterName = "paramIdUs";
                paramIdUsuario.SqlDbType = SqlDbType.BigInt;
                paramIdUsuario.Value = id;

                cmd.Parameters.Add(paramNombre);
                cmd.Parameters.Add(paramApellido);
                cmd.Parameters.Add(paramNombreUsuario);
                cmd.Parameters.Add(paramContras);
                cmd.Parameters.Add(paramMail);
                cmd.Parameters.Add(paramIdUsuario);

                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
