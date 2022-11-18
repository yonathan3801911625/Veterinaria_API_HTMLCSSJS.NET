using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Veterinaria.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Veterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        // GET: api/<ClienteController>
        /*
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        */

        // GET api/<ClienteController>/5
        [HttpGet]
        public string Get()
        {
            //Creo objeto
            Cliente cli = new Cliente("","","",0,"","");
            cli.conectar();
            String mensaje = cli.listCliente();
            return mensaje;
        }

        // POST api/<ClienteController>
        [HttpPost]
        public String Post([FromBody] JsonElement datosI)
        {

            String cedula = datosI.GetProperty("ced").ToString();
            String nombre = datosI.GetProperty("nom").ToString();
            String apellido = datosI.GetProperty("ape").ToString();
            int edad = datosI.GetProperty("eda").GetInt16();
            String direccion = datosI.GetProperty("dir").ToString();
            String telefono = datosI.GetProperty("tel").ToString();

            //Creo objeto
            Cliente cli = new Cliente(cedula, nombre, apellido, edad, direccion, telefono);
            cli.conectar();
            String mensaje = cli.ingresarCliente();
            return mensaje;

        }

        // PUT api/<ClienteController>/5
        [HttpPut]
        public String Put([FromBody] JsonElement datosI)
        {

            String cedula = datosI.GetProperty("ced").ToString();
            String nombre = datosI.GetProperty("nom").ToString();
            String apellido = datosI.GetProperty("ape").ToString();
            int edad = int.Parse(datosI.GetProperty("eda").ToString());
            String direccion = datosI.GetProperty("dir").ToString();
            String telefono = datosI.GetProperty("tel").ToString();

            //Creo objeto
            Cliente cli = new Cliente(cedula, nombre, apellido, edad, direccion, telefono);
            cli.conectar();
            String mensaje = cli.updateCliente();
            return mensaje;

        }

        // DELETE api/<ClienteController>/5
        [HttpDelete]
        public String Delete([FromBody] JsonElement datosI)
        {

            String cedula = datosI.GetProperty("ced").ToString();

            //Creo objeto
            Cliente cli = new Cliente(cedula, "", "", 0, "", "");
            cli.conectar();
            String mensaje = cli.deleteCliente();
            return mensaje;

        }
    }
}
