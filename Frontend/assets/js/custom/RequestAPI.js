



//read
function  consultarCliente()
{
    // var cedula = 111;

    var request = new Request('https://localhost:7178/api/Cliente/', {
        method: 'get',
    });

    fetch(request)
    .then(function(response) {
        return response.text();
    })
    .then(function(data) {
        // alert(data);
generarTabla(data);



   
    })
    .catch(function(err) {
        console.error(err);
    });
}

function generarTabla(data){

    json1=JSON.parse(data);

    
    tabla=document.getElementById("tablaListar");
    for (var clientes in json1) {
        tr=document.createElement("tr");

        
        texto = document.createTextNode(json1[clientes].cedula);
        td=document.createElement("td");
        td.setAttribute("class", "azulVerdePastel text-center text-xs font-weight-semibold");
        td.appendChild(texto);
        tr.appendChild(td);
        tabla.appendChild(tr);

        texto = document.createTextNode(json1[clientes].nombre);
        td=document.createElement("td");
        td.setAttribute("class", "azulVerdePastel text-center text-xs font-weight-semibold");
        td.appendChild(texto);
        tr.appendChild(td);
        tabla.appendChild(tr);

        
        texto = document.createTextNode(json1[clientes].apellido);
        td=document.createElement("td");
        td.setAttribute("class", "azulVerdePastel text-center text-xs font-weight-semibold");
        td.appendChild(texto);
        tr.appendChild(td);
        tabla.appendChild(tr);

        
        texto = document.createTextNode(json1[clientes].edad);
        td=document.createElement("td");
        td.setAttribute("class", "azulVerdePastel text-center text-xs font-weight-semibold");
        td.appendChild(texto);
        tr.appendChild(td);
        tabla.appendChild(tr);

        
        texto = document.createTextNode(json1[clientes].direccion);
        td=document.createElement("td");
        td.setAttribute("class", "azulVerdePastel text-center text-xs font-weight-semibold");
        td.appendChild(texto);
        tr.appendChild(td);
        tabla.appendChild(tr);

        
        texto = document.createTextNode(json1[clientes].telefono);
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
        aEdit.setAttribute("onclick", "pasarDatos('"+json1[clientes].cedula+"')")
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
        aDelete.setAttribute("onclick", "eliminarCliente('"+json1[clientes].cedula+"')")
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



function pasarDatos(cedula){
$('#cedulaUpdate').val(cedula)

       
}


function abrirVentana(cedula, nombre, apellido, edad, direccion, telefono){
    // window.open('clienteEdit.html?cedula='+cedula+"&&nombre="+nombre+"&&apellido="+apellido+"&&edad="+edad+"&&direccion="+direccion+"&&telefono="+telefono,'popup','width=1024,height=768')

    var w = 1024;
    var h = 500;
    var left = Number((screen.width/2)-(w/2));
    var tops = Number((screen.height/2)-(h/2));

window.open("clienteEdit.html?"+cedula+"&&nombre="+nombre+"&&apellido="+apellido+"&&edad="+edad+"&&direccion="+direccion+"&&telefono="+telefono,'', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width='+w+', height='+h+', top='+tops+', left='+left);

}


//create
function guardarCliente()
{
    
var cedula=document.getElementById("cedula").value;
var nombre=document.getElementById("nombre").value;
var apellido=document.getElementById("apellido").value;
var edad=document.getElementById("edad").value;
var direccion=document.getElementById("direccion").value;
var telefono=document.getElementById("telefono").value;
// var id = Integer.parseInt(jsonObj.get("id"));

// var cedula="1053";
// var nombre="yon";
// var edad=23;

var request = new Request('https://localhost:7178/api/Cliente/', {
        method: 'Post',
        headers: {
            'Content-Type': 'application/json'
          },
            body: JSON.stringify({
              ced: cedula,
              nom: nombre,
              ape: apellido,
              eda: parseInt(edad),
              dir: direccion,
              tel:telefono
          })
       
    });

    fetch(request)
    .then(function(response) {
        return response.text();
    })
   
    .then(function(data) {
        alert(data);
        limpiarGuardar()

      
    })
    .catch(function(err) {
        console.error(err);
    });
}


//delete
function eliminarCliente(cedula)
{
    // var cedula=document.getElementById("idDelete").value;
    // var cedula="1053";

var request = new Request('https://localhost:7178/api/Cliente/', {
        method: 'delete',
        headers: {
            'Content-Type': 'application/json'
          },
            body: JSON.stringify({
              ced: cedula
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
function actualizarCliente()
{

    var cedula=document.getElementById("cedulaUpdate").value;
    var nombre=document.getElementById("nombreUpdate").value;
    var apellido=document.getElementById("apellidoUpdate").value;
    var edad=document.getElementById("edadUpdate").value;
    var direccion=document.getElementById("direccionUpdate").value;
    var telefono=document.getElementById("telefonoUpdate").value;

// var id="1";
// var cedula="1053";
// var titulo="la hoja";
// var descripcion="la hoja cayo del arbol";

const contenedor = document.querySelector('tbody')
let resultados = ''
var request = new Request('https://localhost:7178/api/Cliente/', {
        method: 'Put',
        headers: {
            'Content-Type': 'application/json'
          },
            body: JSON.stringify({
                ced: cedula,
                nom: nombre,
                ape: apellido,
                eda: parseInt(edad),
                dir: direccion,
                tel:telefono
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




function limpiarGuardar() {
    var cedula=document.getElementById("cedula");
    var nombre=document.getElementById("nombre");
    var apellido=document.getElementById("apellido");
    var edad=document.getElementById("edad");
    var direccion=document.getElementById("direccion");
    var telefono=document.getElementById("telefono");
if (cedula.value !="") {
    cedula.value="";
    nombre.value="";
    apellido.value="";
    edad.value="";
    direccion.value="";
    telefono.value="";
}

}