using master_API.Models;
using System.Data;
using System.Data.SqlClient;

namespace master_API.Repository
{
    public class ADO_ProductoVendido
    {

        public static List<DescripProducto> TraerProductoVendido(string nomDeUsuario)
        {
            var listaProductoVendido = new List<DescripProducto>();

            using (SqlConnection con = new SqlConnection(General.connetcionString()))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT pr.Descripciones FROM Producto pr INNER JOIN ProductoVendido pv ON pr.Id = pv.IdProducto INNER JOIN Venta vnt ON vnt.Id = pv.IdVenta INNER JOIN Usuario us ON Us.Id = vnt.IdUsuario WHERE Us.NombreUsuario = @param;";

                var param = new SqlParameter();
                param.ParameterName = "param";
                param.SqlDbType = SqlDbType.VarChar;
                param.Value = nomDeUsuario;
                cmd.Parameters.Add(param);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var pv = new DescripProducto();

                    pv.Descripciones = reader.GetValue(0).ToString();

                    listaProductoVendido.Add(pv);

                }

                reader.Close();
            }
            
            return listaProductoVendido;
        }

    }
}
