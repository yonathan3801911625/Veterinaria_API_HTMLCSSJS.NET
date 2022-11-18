using Newtonsoft.Json;
using Npgsql;
using System.Dynamic;

namespace Veterinaria.Models
{
    public class Mascota
    {

        String codigo { set; get; }

        String nombre { set; get; }

        int edad { set; get; }
        String tipo { set; get; }


        NpgsqlConnection cone;
        public void conectar()
        {

            this.cone = new NpgsqlConnection("Server=127.0.0.1;User Id=empresariales;Password=12345678;Database=veterinaria");
            this.cone.Open();
        }

        public String ingresarMascota()
        {

            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand();
                String Sql = "INSERT INTO mascota VALUES('" + this.codigo + "', '" + this.nombre + "', " + this.edad + ", '" + this.tipo + "')";
                new NpgsqlCommand(Sql, this.cone).ExecuteNonQuery();
                return "Datos Guardados :)";
            }
            catch (Exception E)
            {

                return "Error al guardar";
            }
        }

        public String deleteMascota()
        {

            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand();
                String Sql = "DELETE from mascota where codigo = '" + this.codigo + "'";
                new NpgsqlCommand(Sql, this.cone).ExecuteNonQuery();
                return "Dato Eliminado :)";
            }
            catch (Exception E)
            {

                return "Error al eliminar";
            }
        }


        public String updateMascota()
        {

            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand();
                String Sql = "UPDATE mascota set nombre = '" + this.nombre + "', edad = " + this.edad + ", tipo = '" + this.tipo + "' where codigo = '" + this.codigo + "' ";
                cmd = new NpgsqlCommand(Sql, this.cone);
                cmd.ExecuteNonQuery();
                return "Dato Actualizado :)";
            }
            catch (Exception E)
            {

                return "Error al actualizar";
            }
        }



        public String listMascota()
        {

            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand();
                String Sql = "SELECT * from mascota";
                var reader = new NpgsqlCommand(Sql, this.cone).ExecuteReader();
                var todo = new List<dynamic>();
                while (reader.Read())
                {
                    dynamic dynamic = new ExpandoObject();

                    dynamic.codigo = reader.GetString(0);
                    dynamic.nombre = reader.GetString(1);
                    dynamic.edad = reader.GetInt16(2);
                    dynamic.tipo = reader.GetString(3);
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



        public Mascota(string cod, string nom, int eda, string tip)
        {
            this.codigo = cod;
            this.nombre = nom;
            this.edad = eda;
            this.tipo = tip;
        }

    }
}
