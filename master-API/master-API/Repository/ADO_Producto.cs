using master_API.Models;
using System.Data;
using System.Data.SqlClient;
namespace master_API.Repository
{
    public class ADO_Producto
    {
        public static List<DescripProducto> TraerProducto(int idUsuario)
        {
            var listaProducto = new List<DescripProducto>();

            using (SqlConnection con = new SqlConnection(General.connetcionString()))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT Descripciones FROM Producto WHERE IdUsuario = @idUs;";

                var param = new SqlParameter();
                param.ParameterName = "idUs";
                param.SqlDbType = SqlDbType.VarChar;
                param.Value = idUsuario;
                cmd.Parameters.Add(param);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var prod = new DescripProducto();

                    prod.Descripciones = reader.GetValue(0).ToString();

                    listaProducto.Add(prod);
                }
                reader.Close();
            }

            return listaProducto;
            
        }

        public static void AgregarProducto(Producto pr)
        {
            using (SqlConnection con = new SqlConnection(General.connetcionString()))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO Producto (Descripciones, Costo, PrecioVenta, Stock, IdUsuario) VALUES (@paramDesc, @paramCos, @paramPV, @paramSto, @paramIdusu);";

                var paramDes = new SqlParameter();
                paramDes.ParameterName = "paramDesc"; 
                paramDes.SqlDbType = SqlDbType.VarChar; 
                paramDes.Value = pr.Descripciones;

                var paramCos = new SqlParameter();
                paramCos.ParameterName = "paramCos"; 
                paramCos.SqlDbType = SqlDbType.Money; 
                paramCos.Value = pr.Costo;

                var paramPV = new SqlParameter();
                paramPV.ParameterName = "paramPV"; 
                paramPV.SqlDbType = SqlDbType.Money; 
                paramPV.Value = pr.PrecioVenta;

                var paramSto = new SqlParameter();
                paramSto.ParameterName = "paramSto"; 
                paramSto.SqlDbType = SqlDbType.Int; 
                paramSto.Value = pr.Stock;

                var paramIdUs = new SqlParameter();
                paramIdUs.ParameterName = "paramIdusu"; 
                paramIdUs.SqlDbType = SqlDbType.BigInt;
                paramIdUs.Value = pr.IdUsuario;

                cmd.Parameters.Add(paramDes);
                cmd.Parameters.Add(paramCos);
                cmd.Parameters.Add(paramPV);
                cmd.Parameters.Add(paramSto);
                cmd.Parameters.Add(paramIdUs);

                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public static void ModificarProducto(Producto Pr, int id)
        {
            using (SqlConnection con = new SqlConnection(General.connetcionString()))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE Producto " +
                    "SET Descripciones = @paramDesc, Costo = @paramCosto, PrecioVenta = @paramPV, Stock = @paramSto, IdUsuario = @paramIdUs " +
                    "WHERE Id = @paramIdProd;";

                var paramDes = new SqlParameter();
                paramDes.ParameterName = "paramDesc";
                paramDes.SqlDbType = SqlDbType.VarChar;
                paramDes.Value = Pr.Descripciones;

                var paramCos = new SqlParameter();
                paramCos.ParameterName = "paramCosto";
                paramCos.SqlDbType = SqlDbType.Money;
                paramCos.Value = Pr.Costo;

                var paramPV = new SqlParameter();
                paramPV.ParameterName = "paramPV";
                paramPV.SqlDbType = SqlDbType.Money;
                paramPV.Value = Pr.PrecioVenta;

                var paramSto = new SqlParameter();
                paramSto.ParameterName = "paramSto";
                paramSto.SqlDbType = SqlDbType.Int;
                paramSto.Value = Pr.Stock;

                var paramIdUs = new SqlParameter();
                paramIdUs.ParameterName = "paramIdUs";
                paramIdUs.SqlDbType = SqlDbType.BigInt;
                paramIdUs.Value = Pr.IdUsuario;

                var paramIdPro = new SqlParameter();
                paramIdPro.ParameterName = "paramIdProd";
                paramIdPro.SqlDbType = SqlDbType.BigInt;
                paramIdPro.Value = id;

                cmd.Parameters.Add(paramDes);
                cmd.Parameters.Add(paramCos);
                cmd.Parameters.Add(paramPV);
                cmd.Parameters.Add(paramSto);
                cmd.Parameters.Add(paramIdUs);
                cmd.Parameters.Add(paramIdPro);

                cmd.ExecuteNonQuery();
                con.Close();

            }

        }

        public static void EliminarProducto(int id)
        {
            using (SqlConnection con = new SqlConnection(General.connetcionString()))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "DELETE FROM Producto WHERE Id = @param1;";

                var param = new SqlParameter();
                param.ParameterName = "param1"; // le ponemos nombre al parametro
                param.SqlDbType = SqlDbType.BigInt; // le definimos el tipo de parametro
                param.Value = id;

                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

    }
}
