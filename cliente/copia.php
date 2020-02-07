<link rel="stylesheet" type="text/css" href="estiloFormulario.css">
<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh" crossorigin="anonymous">
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js" integrity="sha384-wfSDF2E50Y2D1uUdj0O3uMBJnjuUD4Ih7YwaYd1iqfktj0Uod8GCExl3Og8ifwB6" crossorigin="anonymous"></script> 
<?php
    //conectamos Con el servidor
    $host ="localhost";
    $user ="root";
    $pass ="";
    $db="migracion";

    //funcion llamada conexion con (dominio,usuarios,contraseña,base_de_datos)
    $con = mysqli_connect($host,$user,$pass,$db)or die("Problemas al Conectar con Servidor");
    mysqli_select_db($con,$db)or die("Problemas al Conectar con la Base de Datos");

    //recuperar las variables y definimos la hora
    $CUI=$_POST['CUI'];
    $Referencia_Boleto=$_POST['Referencia_Boleto'];
    $Correlativo_Ornato=$_POST['Correlativo_Ornato'];
    $Correo = $_POST['Correo'];
    date_default_timezone_set('America/Guatemala'); 
    $FechaHora = date("Y-m-d H:i:s");

    //hacemos la sentencia de sql
    $sqlIdS="SELECT MAX(id_solicitud) FROM solicitudes";
    $sqlS="INSERT INTO solicitudes VALUES('$CUI', '$FechaHora', '$Correo', '1')";
    $sqlD1="INSERT INTO documentos VALUES('Boleto de Ornato', '$Correlativo_Ornato', '$sqlIdS', '1')";    
    $sqlD2="INSERT INTO documentos VALUES('Boleta Banrural', '$Referencia_Boleto', '$sqlIdS', '1')"; 

    //ejecutamos la sentencia de sql
    $ejecutar=mysqli_query($con,$sqlS);

    //verificamos la ejecucion
    if(!$ejecutar){
    echo "Hubo Algun Error al Insertar";
    }else{
    echo "<br> <br> <h2> Datos Guardados Correctamente </h2>";
    }    
?>
<br> <br>
<input class="btn btn-primary" type="submit" value="Volver a Inicio" onclick="location.href='formularioMayor.html';">