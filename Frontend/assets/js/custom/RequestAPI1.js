



//read
function  consultarClienteMascota()
{
    // var cedula = 111;

    var request = new Request('https://localhost:7178/api/ClienteMascota/', {
        method: 'get',
    });

    fetch(request)
    .then(function(response) {
        return response.text();
    })
    .then(function(data) {
        // alert(data);
generarTablaClienteMascota(data);



   
    })
    .catch(function(err) {
        console.error(err);
    });
}





function generarTablaClienteMascota(data){

    json1=JSON.parse(data);

    
    tabla=document.getElementById("tablaListarClienteMascota");
    for (var clienteMascota in json1) {
        tr=document.createElement("tr");

        
        texto = document.createTextNode(json1[clienteMascota].codigo);
        td=document.createElement("td");
        td.setAttribute("class", "azulVerdePastel text-center text-xs font-weight-semibold");
        td.appendChild(texto);
        tr.appendChild(td);
        tabla.appendChild(tr);

        texto = document.createTextNode(json1[clienteMascota].cedulaCliente);
        td=document.createElement("td");
        td.setAttribute("class", "azulVerdePastel text-center text-xs font-weight-semibold");
        td.appendChild(texto);
        tr.appendChild(td);
        tabla.appendChild(tr);

        
        texto = document.createTextNode(json1[clienteMascota].nombreCliente);
        td=document.createElement("td");
        td.setAttribute("class", "azulVerdePastel text-center text-xs font-weight-semibold");
        td.appendChild(texto);
        tr.appendChild(td);
        tabla.appendChild(tr);

        
        texto = document.createTextNode(json1[clienteMascota].codigoMascota);
        td=document.createElement("td");
        td.setAttribute("class", "azulVerdePastel text-center text-xs font-weight-semibold");
        td.appendChild(texto);
        tr.appendChild(td);
        tabla.appendChild(tr);

        
        texto = document.createTextNode(json1[clienteMascota].nombreMascota);
        td=document.createElement("td");
        td.setAttribute("class", "azulVerdePastel text-center text-xs font-weight-semibold");
        td.appendChild(texto);
        tr.appendChild(td);
        tabla.appendChild(tr);


        td=document.createElement("td");
        td.setAttribute("class", "text-center text-xs font-weight-semibold");

        aEdit=document.createElement("a")
        aEdit.setAttribute("href", "#")
        //aEdit.setAttribute("onclick", "abrirVentana('"+json1[clientes].cedula+"','"+json1[clientes].nombre+"','"+json1[clientes].apellido+"','"+json1[clientes].edad+"','"+json1[clientes].direccion+"','"+json1[clientes].telefono+"')")
        aEdit.setAttribute("onclick", "pasarDatos('"+json1[clienteMascota].codigo+"')")
        aEdit.setAttribute("class", "text-primary font-weight-bold text-xs")
        aEdit.setAttribute("data-bs-toggle", "modal")
        aEdit.setAttribute("data-bs-target", "#modal-form")
        texto = document.createTextNode("Editar");
        aEdit.appendChild(texto)
        td.appendChild(aEdit);
        spanEdit=document.createElement("span")
        spanEdit.setAttribute("class", "text-primary material-symbols-outlined")
        texto1 = document.createTextNode("edit");
        spanEdit.appendChild(texto1)
        td.appendChild(spanEdit);

        aDelete=document.createElement("a")
        aDelete.setAttribute("href", "#")
        aDelete.setAttribute("onclick", "eliminarCliente('"+json1[clienteMascota].codigo+"')")
        aDelete.setAttribute("class", "text-danger font-weight-bold text-xs")
        aDelete.setAttribute("data-bs-toggle", "tooltip")
        aDelete.setAttribute("data-bs-title", "Delete")
        texto = document.createTextNode("Eliminar");
        aDelete.appendChild(texto)
        td.appendChild(aDelete);
        spanDelete=document.createElement("span")
        spanDelete.setAttribute("class", "text-danger material-symbols-outlined")
        texto2 = document.createTextNode("restore_from_trash");
        spanDelete.appendChild(texto2)
        td.appendChild(spanDelete);


        tr.appendChild(td);
        tabla.appendChild(tr);
        




  }

}




//create
function guardarClienteMascota()
{
    
var codigo=document.getElementById("codigo").value;
var cedulaCliente=document.getElementById("cedulaCliente").value;
var nombreCliente=document.getElementById("nombreCliente").value;
var codigoMascota=document.getElementById("codigoMascota").value;
var nombreMascota=document.getElementById("nombreMascota").value;
// var id = Integer.parseInt(jsonObj.get("id"));

// var cedula="1053";
// var nombre="yon";
// var edad=23;

var request = new Request('https://localhost:7178/api/ClienteMascota/', {
        method: 'Post',
        headers: {
            'Content-Type': 'application/json'
          },
            body: JSON.stringify({
              cod: codigo,
              cedcli: cedulaCliente,
              nomcli: nombreCliente,
              codmas: codigoMascota,
              nommas:nombreMascota
          })
       
    });

    fetch(request)
    .then(function(response) {
        return response.text();
    })
   
    .then(function(data) {
        alert(data);
        // limpiarGuardarCliente()
        window.location.reload()

      
    })
    .catch(function(err) {
        console.error(err);
    });
}




//delete
function eliminarClienteMascota(codigo)
{
    // var cedula=document.getElementById("idDelete").value;
    // var cedula="1053";

var request = new Request('https://localhost:7178/api/ClienteMascota/', {
        method: 'delete',
        headers: {
            'Content-Type': 'application/json'
          },
            body: JSON.stringify({
              cod: codigo
          })
       
    });

    fetch(request)
    .then(function(response) {
        return response.text();
    })
   
    .then(function(data) {
        alert(data);
        window.location.reload()
 
      
    })
    .catch(function(err) {
        console.error(err);
    });
}






//update
function actualizarClienteMascota()
{

    var codigo=document.getElementById("codigoACT").value;
    var cedulaCliente=document.getElementById("cedulaClienteACT").value;
    var nombreCliente=document.getElementById("nombreClienteACT").value;
    var codigoMascota=document.getElementById("codigoMascotaACT").value;
    var nombreMascota=document.getElementById("nombreMascotaACT").value;

// var id="1";
// var cedula="1053";
// var titulo="la hoja";
// var descripcion="la hoja cayo del arbol";

var request = new Request('https://localhost:7178/api/ClienteMascota/', {
        method: 'Put',
        headers: {
            'Content-Type': 'application/json'
          },
            body: JSON.stringify({
                cod: codigo,
                cedcli: cedulaCliente,
                nomcli: nombreCliente,
                codmas: codigoMascota,
                nommas:nombreMascota
          })
       
    });

    fetch(request)
    .then(function(response) {
        return response.text();
    })
   
    .then(function(data) {
        //alert(data);
        window.location.reload()
      
    })
    .catch(function(err) {
        console.error(err);
    });
}


