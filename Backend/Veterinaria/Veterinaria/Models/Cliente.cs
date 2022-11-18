using Newtonsoft.Json;
using Npgsql;
using System.Dynamic;

namespace Veterinaria.Models
{
    public class Cliente
    {

        

        String cedula { set; get; }
        String nombre { set; get; }
        String apellido { set; get; }

        int edad { set; get; }
        String direccion { set; get; }
        String telefono { set; get; }


        NpgsqlConnection cone;
        public void conectar()
        {

            this.cone = new NpgsqlConnection("Server=127.0.0.1;User Id=empresariales;Password=12345678;Database=veterinaria");
            this.cone.Open();
        }

        public String ingresarCliente()
        {

            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand();
                String Sql = "INSERT INTO cliente VALUES('" + this.cedula + "', '" + this.nombre + "', '" + this.apellido + "', " + this.edad + ", '" + this.direccion + "', '" + this.telefono + "')";
                new NpgsqlCommand(Sql, this.cone).ExecuteNonQuery();
                return "Datos Guardados :)";
            }
            catch (Exception E)
            {

                return "Error al guardar";
            }
        }

        public String deleteCliente()
        {

            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand();
                String Sql = "DELETE from cliente where cedula = '" + this.cedula + "'";
                new NpgsqlCommand(Sql, this.cone).ExecuteNonQuery();
                return "Dato Eliminado :)";
            }
            catch (Exception E)
            {

                return "Error al eliminar";
            }
        }


        public String updateCliente()
        {

            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand();
                String Sql = "UPDATE cliente set nombre = '" + this.nombre + "', apellido = '" + this.apellido + "', edad = " + this.edad + ", direccion = '" + this.direccion + "', telefono = '" + this.telefono + "' where cedula = '" + this.cedula + "'";
                cmd = new NpgsqlCommand(Sql, this.cone);
                cmd.ExecuteNonQuery();
                return "Dato Actualizado :)";
            }
            catch (Exception E)
            {

                return "Error al actualizar";
            }
        }



        public String listCliente()
        {

            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand();
                String Sql = "SELECT * from cliente";
                var reader = new NpgsqlCommand(Sql, this.cone).ExecuteReader();
                var todo = new List<dynamic>();
                while (reader.Read())
                {
                    dynamic dynamic = new ExpandoObject();

                    dynamic.cedula = reader.GetString(0);
                    dynamic.nombre = reader.GetString(1);
                    dynamic.apellido = reader.GetString(2);
                    dynamic.edad = reader.GetInt16(3);
                    dynamic.direccion = reader.GetString(4);
                    dynamic.telefono = reader.GetString(5);
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



        public Cliente(string ced, string nom, string ape, int eda, string dir, string tel)
        {
            this.cedula = ced;
            this.nombre = nom;
            this.apellido = ape;
            this.edad = eda;
            this.direccion = dir;
            this.telefono = tel;
        }

    }
}
