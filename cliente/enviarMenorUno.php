<script src="https://code.jquery.com/jquery-3.4.1.slim.min.js" integrity="sha384-J6qa4849blE2+poT4WnyKhv5vZF5SrPo0iEjwBvKU7imGFAV0wwj1yYfoRSJoZ+n" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js" integrity="sha384-wfSDF2E50Y2D1uUdj0O3uMBJnjuUD4Ih7YwaYd1iqfktj0Uod8GCExl3Og8ifwB6" crossorigin="anonymous"></script>
<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh" crossorigin="anonymous">
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js" integrity="sha384-wfSDF2E50Y2D1uUdj0O3uMBJnjuUD4Ih7YwaYd1iqfktj0Uod8GCExl3Og8ifwB6" crossorigin="anonymous"></script> 
<?php
    //conectamos Con el servidor
    //35.203.64.16
    //HlHNEvdvxPfrC9fK 
    $host ="35.203.64.16";
    $user ="root";
    $pass ="HlHNEvdvxPfrC9fK";
    $db="migracion";

    //funcion llamada conexion con (dominio,usuarios,contraseña,base_de_datos)
    $con = mysqli_connect($host,$user,$pass,$db)or die("Problemas al Conectar con Servidor");
    mysqli_select_db($con,$db)or die("Problemas al Conectar con la Base de Datos");

    //recuperar las variables y definimos la hora
    $CUI=$_POST['CUI'];
    $Referencia_Boleto=$_POST['Referencia_Boleto'];
    $Correlativo_Ornato=$_POST['Correlativo_Ornato'];
    $CUI_Padre=$_POST['CUI_Padre'];
    $CUI_Madre=$_POST['CUI_Madre'];
    $Correo = $_POST['Correo'];
    $No_Colegiado=$_POST['No_Colegiado'];
    date_default_timezone_set('America/Guatemala'); 
    $FechaHora = date("Y-m-d H:i:s");
    $FechaHoraAux = date("d-m-Y");

    //hacemos la sentencia de sql    
    $sqlS="INSERT INTO solicitudes (`cui`, `tipo_solicitud`, `fecha_solicitud`, `correo`, `estado`) VALUES('$CUI', 'Menor de Edad', '$FechaHora', '$Correo', '1')";
    $sqlIdS="SELECT MAX(id_solicitud)id FROM solicitudes";    
    
    //ejecutamos la sentencia de sql
    $ejecutarS=mysqli_query($con,$sqlS);
    $ejecutarIdS=mysqli_query($con,$sqlIdS);
    while ($row = $ejecutarIdS->fetch_assoc()) {
        $idSolicitud = $row['id'];
    }       
    $sqlD1="INSERT INTO documentos (`nombre_documento`, `no_documento`, `id_solicitud`, `estado`) VALUES('Boleto de Ornato', '$Correlativo_Ornato', '$idSolicitud', '1')";    
    $sqlD2="INSERT INTO documentos (`nombre_documento`, `no_documento`, `id_solicitud`, `estado`) VALUES('Boleta de Pago', '$Referencia_Boleto', '$idSolicitud', '1')"; 
    $sqlD3="INSERT INTO documentos (`nombre_documento`, `no_documento`, `id_solicitud`, `estado`) VALUES('CUI Padre', '$CUI_Padre', '$idSolicitud', '1')"; 
    $sqlD4="INSERT INTO documentos (`nombre_documento`, `no_documento`, `id_solicitud`, `estado`) VALUES('CUI Madre', '$CUI_Madre', '$idSolicitud', '1')"; 
    $sqlD5="INSERT INTO documentos (`nombre_documento`, `no_documento`, `id_solicitud`, `estado`) VALUES('No. de Colegiado', '$No_Colegiado', '$idSolicitud', '1')"; 
    $ejecutarD1=mysqli_query($con,$sqlD1);    
    $ejecutarD2=mysqli_query($con,$sqlD2);    
    $ejecutarD3=mysqli_query($con,$sqlD3);  
    $ejecutarD4=mysqli_query($con,$sqlD4);  
    $ejecutarD5=mysqli_query($con,$sqlD5);  

    //verificamos la ejecucion
    if(!$ejecutarS){
        echo "Hubo Algun Error al Insertar Solicitud";
    }
    else{
        if (!$ejecutarIdS) {
            echo "Hubo Algun Error al Obtener Id de Solicitud";
        } else {                                     
            if (!$ejecutarD1) {
                echo "Hubo Algun Error al Insertar 1er Documento";
            } else {
                if (!$ejecutarD2) {
                    echo "Hubo Algun Error al Insertar 2do Documento";
                } else {
                    if (!$ejecutarD3) {
                        echo "Hubo Algun Error al Insertar 3er Documento";
                    } else {
                        if (!$ejecutarD4) {
                            echo "Hubo Algun Error al Insertar 4to Documento";
                        } else {
                            if (!$ejecutarD5) {
                                echo "Hubo Algun Error al Insertar 5to Documento";
                            }
                            else
                            {
                                echo "<br><br><div class='container'>
                                    <div class='row'>
                                        <div class='col-12'>
                                            <div class='container text-center'>
                                                <h2> Datos Guardados Correctamente </h2> 
                                                <br>
                                                <p> En un plazo de 24 horas recibirá su cita al correo ($Correo). </p>
                                                <p> Fecha de Solicitud: $FechaHoraAux </p>                                       
                                                <br>
                                            </div>        
                                        </div>                    
                                    </div>
                                </div>";
                            }
                        }                        
                    }                    
                }                
            }                
        }            
    }    
?>
<div class='container'>
    <div class='row'>
        <div class='col-12'>
            <div class='container'>                            
                <input class='btn btn-primary btn-lg btn-block' type='submit' value='Volver a INICIO' onclick="location.href='index';">                
            </div>        
        </div>          
    </div>
</div>