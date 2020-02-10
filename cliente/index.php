<!DOCTYPE html>
<html lang="es">
<head>    
    <meta charset="UTF-8"> 
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">        
    <title>Solicitud de Pasaporte</title>
    <!-- 
    <link rel="stylesheet" type="text/css" href="estiloFormulario.css"> -->
    <script src="https://code.jquery.com/jquery-3.4.1.slim.min.js" integrity="sha384-J6qa4849blE2+poT4WnyKhv5vZF5SrPo0iEjwBvKU7imGFAV0wwj1yYfoRSJoZ+n" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js" integrity="sha384-wfSDF2E50Y2D1uUdj0O3uMBJnjuUD4Ih7YwaYd1iqfktj0Uod8GCExl3Og8ifwB6" crossorigin="anonymous"></script>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh" crossorigin="anonymous">
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js" integrity="sha384-wfSDF2E50Y2D1uUdj0O3uMBJnjuUD4Ih7YwaYd1iqfktj0Uod8GCExl3Og8ifwB6" crossorigin="anonymous"></script>
</head>
<body>
    <header>
        <br>
        <div class="container">
            <img class="rounded mx-auto d-block img-fluid" src="migracionLogo.jpg" alt="Migracion Guatemala">
        </div>
    </header>

    <div class="container">
        <br>
        <div class="container">
            <h2 class="display-4">Formularios para Solicitud de Pasaporte</h2>
        </div> 
        <br>
        <div class="row">
            <div class="col-1">
            </div>
            <div class="col-10 bg-primary text-white border">
                <br>
                <div class="container">
                    <form class="" action="" method="POST">
                        <div class="form-group row">                    
                            <label class="" for="">Seleccione Tipo de Formulario</label>                                
                            <select class="custom-select" name="Form" id="" onchange="location = this.value;" required>
                                <option value="" selected>Escoger...</option>
                                <option value="formularioMayor" href="">Mayor de Edad</option>
                                <option value="formularioMayor60">Mayor de 60 años</option>
                                <option value="formularioMenorAmbos">Menor de Edad (Ambos Padres presentes)</option>
                                <option value="formularioMenorUno">Menor de Edad (Un Padre de Familia presente)</option>
                            </select>
                        </div>
                        <br>
                        <!--
                        <div class="form-group row">
                            <input class="btn btn-primary btn-lg btn-block" type="submit" value="Siguiente">
                        </div> -->                    
                    </form>
                </div>                                
            </div> 
            <div class="col-1">            
            </div>            
        </div>           
    </div>
    <br><br>
    <div class="container">
        <div class="position-relative">               
            <div class="text-right">            
                <footer class="blockquote-footer">Proyecto Elaborado por Randy Choc y Juan Gámez (2020)</footer>                          
            </div>             
        </div>
    </div>    
    <br>
</body>
</html>