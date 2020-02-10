<!DOCTYPE html>
<html lang="es">
<head>    
    <meta charset="UTF-8"> 
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">        
    <title>Form. Mayor de Edad</title>
    <!-- 
    <link rel="stylesheet" type="text/css" href="estiloFormulario.css"> -->
    <script src="https://code.jquery.com/jquery-3.4.1.slim.min.js" integrity="sha384-J6qa4849blE2+poT4WnyKhv5vZF5SrPo0iEjwBvKU7imGFAV0wwj1yYfoRSJoZ+n" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js" integrity="sha384-wfSDF2E50Y2D1uUdj0O3uMBJnjuUD4Ih7YwaYd1iqfktj0Uod8GCExl3Og8ifwB6" crossorigin="anonymous"></script>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh" crossorigin="anonymous">
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js" integrity="sha384-wfSDF2E50Y2D1uUdj0O3uMBJnjuUD4Ih7YwaYd1iqfktj0Uod8GCExl3Og8ifwB6" crossorigin="anonymous"></script>
</head>
<body oncontextmenu="return false">
    <header>
        <br>
        <div class="container">
            <img class="rounded mx-auto d-block img-fluid" src="migracionLogo.jpg" alt="Migracion Guatemala">
        </div>
    </header>

    <div class="container">
        <br>
        <div class="container text-center">
            <h2>Formulario para Menores de Edad</h2>
            <h3>***AMBOS PADRES PRESENTES***</h3>
        </div> 
        <br>
        <div class="row">
            <div class="col-1">
            </div>
            <div class="col-10 bg-white text-dark border">
                <br>
                <div class="container">
                    <form class="" action="enviarMenorAmbos" method="POST">
                        <div class="form-group row">
                            <h4>CUI del Menor</h4>                
                            <input class="form-control" type="number" name="CUI" placeholder="Ingrese CUI del Menor" required>
                            <small class="form-text text-muted">*CUI - Código Único de Identificación del Menor</small>
                        </div>          
                        <br>          
                        <div class="form-group row">
                            <h4>No. Boleto de Pago (Banrural)</h4>                
                            <input class="form-control" type="number" name="Referencia_Boleto" placeholder="Ingrese No. de Referencia" required>
                            <small class="form-text text-muted">*En la boleta de pago (Banrural) busque el número de referencia</small>
                        </div>
                        <br>
                        <div class="form-group row">
                            <h4>No. Boleto de Ornato (Municipalidad)</h4>                
                            <input class="form-control" type="number" name="Correlativo_Ornato" placeholder="Ingrese No. de Control Interno" required>
                            <small class="form-text text-muted">*En el boleto de ornato busque el número de Control Interno</small>
                        </div>
                        <br>
                        <div class="form-group row">
                            <h4>CUI del Padre</h4>                
                            <input class="form-control" type="number" name="CUI_Padre" placeholder="Ingrese CUI del Padre" required>
                            <small class="form-text text-muted">*CUI - Código Único de Identificación del Padre</small>
                        </div>          
                        <br>
                        <div class="form-group row">
                            <h4>CUI de la Madre</h4>                
                            <input class="form-control" type="number" name="CUI_Madre" placeholder="Ingrese CUI de la Madre" required>
                            <small class="form-text text-muted">*CUI - Código Único de Identificación de la Madre</small>
                        </div>          
                        <br>
                        <div class="form-group row">
                            <h4>Correo Electrónico de uno de los Padres</h4>
                            <input type="email" class="form-control"  name= "Correo" id="exampleFormControlInput1" placeholder="nombre@ejemplo.com" required>
                            <small class="form-text text-muted">*Se necesita correo de uno de los Padres para enviarle Fecha y Hora de la Cita</small>
                        </div>
                        <br>
                        <div class="form-group row">
                            <input class="btn btn-primary btn-lg btn-block" type="submit" value="Enviar">
                        </div>                    
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