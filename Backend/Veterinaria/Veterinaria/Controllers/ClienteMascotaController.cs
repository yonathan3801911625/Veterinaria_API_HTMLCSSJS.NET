using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Veterinaria.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Veterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteMascotaController : ControllerBase
    {
        // GET: api/<ClienteMascotaController>
        /*
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        */

        // GET api/<ClienteMascotaController>/5
        [HttpGet]
        public string Get()
        {
            //Creo objeto
            ClienteMascota climas = new ClienteMascota("", "", "", "", "");
            climas.conectar();
            String mensaje = climas.listClienteMascota();
            return mensaje;
        }

        // POST api/<ClienteMascotaController>
        [HttpPost]
        public String Post([FromBody] JsonElement datosI)
        {
            String codigo = datosI.GetProperty("cod").ToString();
            String cedulaCliente = datosI.GetProperty("cedcli").ToString();
            String nombreCliente = datosI.GetProperty("nomcli").ToString();
            String codigoMascota = datosI.GetProperty("codmas").ToString();
            String nombreMascota = datosI.GetProperty("nommas").ToString();

            //Creo objeto
            ClienteMascota climas = new ClienteMascota(codigo,cedulaCliente, nombreCliente, codigoMascota, nombreMascota);
            climas.conectar();
            String mensaje = climas.ingresarClienteMascota();
            return mensaje;
        }

        // PUT api/<ClienteMascotaController>/5
        [HttpPut]
        public String Put([FromBody] JsonElement datosI)
        {
            String codigo = datosI.GetProperty("cod").ToString();
            String cedulaCliente = datosI.GetProperty("cedcli").ToString();
            String nombreCliente = datosI.GetProperty("nomcli").ToString();
            String codigoMascota = datosI.GetProperty("codmas").ToString();
            String nombreMascota = datosI.GetProperty("nommas").ToString();

            //Creo objeto
            ClienteMascota climas = new ClienteMascota(codigo, cedulaCliente, nombreCliente, codigoMascota, nombreMascota);
            climas.conectar();
            String mensaje = climas.updateClienteMascota();
            return mensaje;
        }

        // DELETE api/<ClienteMascotaController>/5
        [HttpDelete]
        public String Delete([FromBody] JsonElement datosI)
        {
            String codigo = datosI.GetProperty("cod").ToString();

            //Creo objeto
            ClienteMascota climas = new ClienteMascota(codigo, "", "", "", "");
            climas.conectar();
            String mensaje = climas.deleteClienteMascota();
            return mensaje;
        }
    }
}
