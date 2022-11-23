using Newtonsoft.Json;
using Npgsql;
using System.Dynamic;

namespace Veterinaria.Models
{
    public class ClienteMascota
    {


        private String codigo { set; get; }
        private String cedulaCliente { set; get; }
        private String nombreCliente { set; get; }
        private String codigoMascota { set; get; }
        private String nombreMascota { set; get; }


        NpgsqlConnection cone;
        public void conectar()
        {

            this.cone = new NpgsqlConnection("Server=127.0.0.1;User Id=empresariales;Password=12345678;Database=veterinaria");
            this.cone.Open();
        }

        public String ingresarClienteMascota()
        {

            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand();
                String Sql = "INSERT INTO clientemascota VALUES('" + this.codigo + "', '" + this.cedulaCliente + "', '" + this.nombreCliente + "', '" + this.codigoMascota + "', '" + this.nombreMascota + "')";
                new NpgsqlCommand(Sql, this.cone).ExecuteNonQuery();
                return "Datos Guardados :)";
            }
            catch (Exception E)
            {

                return "Error al guardar";
            }
        }

        public String deleteClienteMascota()
        {

            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand();
                String Sql = "DELETE from clientemascota where codigo = '" + this.codigo + "'";
                new NpgsqlCommand(Sql, this.cone).ExecuteNonQuery();
                return "Dato Eliminado :)";
            }
            catch (Exception E)
            {

                return "Error al eliminar";
            }
        }


        public String updateClienteMascota()
        {

            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand();
                String Sql = "UPDATE clientemascota set cedulaCliente = '" + this.cedulaCliente + "', nombreCliente = '" + this.nombreCliente + "', codigoMascota = '" + this.codigoMascota + "', nombreMascota = '" + this.nombreMascota + "' where codigo = '" + this.codigo + "'";
                cmd = new NpgsqlCommand(Sql, this.cone);
                cmd.ExecuteNonQuery();
                return "Dato Actualizado :)";
            }
            catch (Exception E)
            {

                return "Error al actualizar";
            }
        }



        public String listClienteMascota()
        {

            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand();
                String Sql = "SELECT * from clientemascota";
                var reader = new NpgsqlCommand(Sql, this.cone).ExecuteReader();
                var todo = new List<dynamic>();
                while (reader.Read())
                {
                    dynamic dynamic = new ExpandoObject();

                    dynamic.codigo = reader.GetString(0);
                    dynamic.cedulaCliente = reader.GetString(1);
                    dynamic.nombreCliente = reader.GetString(2);
                    dynamic.codigoMascota = reader.GetInt16(3);
                    dynamic.nombreMascota = reader.GetString(4);
                    todo.Add(dynamic);

                }
                String variable = JsonConvert.SerializeObject(todo);
                reader.Close();

                return variable;
            }
            catch (Exception E)
            {

                return "Error al mostrar" + E;
            }
        }



        public ClienteMascota(string cod, string cedcli, string nomcli, string codmas, string nommas)
        {
            this.codigo = cod;
            this.cedulaCliente = cedcli;
            this.nombreCliente = nomcli;
            this.codigoMascota = codmas;
            this.nombreMascota = nommas;
        }


    }
}
