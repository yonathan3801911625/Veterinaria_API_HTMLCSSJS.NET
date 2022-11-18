using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Veterinaria.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Veterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MascotaController : ControllerBase
    {
        // GET: api/<MascotaController>
        /*
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        */

        // GET api/<MascotaController>/5
        [HttpGet]
        public string Get()
        {
            //Creo objeto
            Mascota ma = new Mascota("", "", 0,"");
            ma.conectar();
            String mensaje = ma.listMascota();
            return mensaje;
        }

        // POST api/<MascotaController>
        [HttpPost]
        public String Post([FromBody] JsonElement datosI)
        {

            String codigo = datosI.GetProperty("cod").ToString();
            String nombre = datosI.GetProperty("nom").ToString();
            int edad = datosI.GetProperty("eda").GetInt16();
            String tipo = datosI.GetProperty("tip").ToString();

            //Creo objeto
            Mascota ma = new Mascota(codigo, nombre, edad, tipo);
            ma.conectar();
            String mensaje = ma.ingresarMascota();
            return mensaje;
        }

        // PUT api/<MascotaController>/5
        [HttpPut]
        public String Put([FromBody] JsonElement datosI)
        {

            String codigo = datosI.GetProperty("cod").ToString();
            String nombre = datosI.GetProperty("nom").ToString();
            int edad = int.Parse(datosI.GetProperty("eda").ToString());
            String tipo = datosI.GetProperty("tip").ToString();

            //Creo objeto
            Mascota ma = new Mascota(codigo, nombre, edad, tipo);
            ma.conectar();
            String mensaje = ma.updateMascota();
            return mensaje;

        }

        // DELETE api/<MascotaController>/5
        [HttpDelete]
        public String Delete([FromBody] JsonElement datosI)
        {
            String codigo = datosI.GetProperty("cod").ToString();

            //Creo objeto
            Mascota ma = new Mascota(codigo, "", 0, "");
            ma.conectar();
            String mensaje = ma.deleteMascota();
            return mensaje;
        }
    }
}
