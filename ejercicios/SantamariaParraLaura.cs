
using Math;

Main{
    int hombresDario = 1800;
    int hombresAle = 1200;

    int[] ejerDario = [3];
    int[] ejerAle = [3];

    
    writeLine("Inserta el primer grupo de banderas: ")
    var temp = bandera();
    string bandera1 = "a" + temp;
    writeLine("Inserta el segundo grupo de banderas: ")
    var temp = bandera();
    string bandera2 = "v" + temp;
    writeLine("Inserta el tercer grupo de banderas: ")
    var temp = bandera();
    string bandera3 = "r" + temp;

    //asigno a cada posicion los hombres necesarios al array que representa el ejército de dario

    writeLine("----------------------------");
    writeLine("Banderas avistadas del ejército contrario: ");
    informeBanderas(banderas1, banderas2, banderas3);


    distribucionFinal(bandera1, ref hombresDario, ejerDario);
    distribucionFinal(bandera2, ref hombresDario, ejerDario);
    distribucionFinal(bandera3, ref hombresDario, ejerDario);
    writeLine("----------------------------");
    writeLine("Distribuición de Darío: ");
    //imprimo el resultado
    imprimirDistribuicion(ejerDario);
    
    int distribuicion1 = (int)preguntarleAle();
    temp = (int)preguntarAle2(); //aprovecho para reciclar temp
    array[temp] = distribuicion1;

    int distribuicion2 = (int)preguntarleAle();
    temp = (int)preguntarAle2();
    array[temp] = distribuicion2;

    int distribuicion3 = (int)preguntarleAle();
    temp = (int)preguntarAle2();
    array[temp] = distribuicion3;

    writeLine("----------------------------");
    writeLine("Distribuición de Alejandro: ");
    imprimirDistribuicion(ejerAle);

    //una vez tengo todos los valores necesarios puedo operar con ellos
    writeLine("----------------------------");
    writeLine("Comienza la batalla");

    batalla(); //no necesito poner los argumentos porque le puse valores por defecto a los parámetros

    writeLine("----------------------------");
    writeLine("Estado final del ejército de Dario:");
    estadoFinal(ejerDario);

    writeLine("----------------------------");
    writeLine("Estado final del ejército de Alejandro:");
    estadoFinal(ejerAle);


}

//............................................................. Funciones y procedimientos de la batalla

procedure estadoFinal(int[] array){
    string posicion;

    for(int i = 0; i<i.length; i++){
        posicion = variablesPosiciones(i);
        writeLine(posicion + "han quedado: " + array[i]);
    }

}

function string variablesPosiciones(int num){
    string posicion;
    if (num == 0){
        posicion = "En el flanco izquierdo "
    }
    if (num == 1){
        posicion = "En el flanco central "
    }
    if (num == 2){
        posicion = "En el flanco derecho "
    }
    return posicion;
}


procedure batalla(int[] array1=ejerDario, int[] array2=ejerDAle){
    int contador;
    int probVictoria;
    string posicion;

    for(int i = 0; i<i.length; i++){
        posicion = variablesPosicion(i);
        if (array1[i]> array2[i]){
            array1[i] *= 0.50;
            array2[i] *= 0.40;
            probVictoria = Math.random(1, 10);

            if (probVictoria >= 1 && probVictoria <= 5){
                contador += 1;
                writeLine(posicion + "La victoria es de Alejandro Magno");
            }else{
                writeLine(posicion + "Alejandro Magno ha perdido");
            }

        }

        if (array1[i]<= array2[i]){
            array1[i] *= 0.40;
            array2[i] *= 0.70;
            probVictoria = Math.random(1, 10);

            if (probVictoria >= 1 && probVictoria <= 7){
                contador += 1;
                writeLine(posicion + "La victoria es de Alejandro Magno");
            }else{
                writeLine(posicion + "Alejandro Magno ha perdido");
            }
        }
    }

    if(contador>1){
        writeLine("La batalla la ha ganado Alejandro Magno");
    }else{
        writeLine("Alejandro Magno ha perdido la batalla");
    }

}

//............................................................. Funciones y procedimientos de la organicación del ejército de Alejandro

function string preguntarAle2(){
    writeLine("¿A que flanco los quieres mandar?");
    string respuesta;
    bool isValid;
     do{
        var respuesta = readLine();
        isValid = leerNum(respuesta);
    }while(!isValid)
    return respuesta;
}

function bool leerIndice(string mensaje){
    var patron = @"^[0-2]$" ;
    var regex = Regex(patron);
    bool isValid = regex.IsMatch(mensaje);
    return isValid;
}

function string preguntarAle(){
    writeLine("¿Cuántos hombres quieres enviar?");
    string respuesta;
    bool isValid;
     do{
        var respuesta = readLine();
        isValid = leerNum(respuesta);
    }while(!isValid)
    return respuesta;
}

function bool leerNum(string mensaje){
    var patron = @"^[0-1200]$" ;
    var regex = Regex(patron);
    bool isValid = regex.IsMatch(mensaje);
    return isValid;
}
    
//............................................................. Funciones y procedimientos de la organicación del ejército de Dario

procedure distribuicionFinal (string bandera, ref int ejercito, int[] array){
    int indice = leerPosicion(bandera);
    int valor = asignarHombres(bandera, ref ejercito);

    array[indice] = valor;
}

procedure imprimirDistribuicion(int array){
    string posicion;
    for(int i = 0; i<i.length; i++){
        posicion = variablesPosiciones(i);
        writeLine(posicion + "hay: " + array[i] + " hombres");
    }
}

procedure asignarHombres(string bandera, ref int ejercito){
    string parte2 = bandera.Substring(1,1);

    int hombresDistribuidos;
    if (bandera1 == "a"){
        hombresDistribuidos = ejercito/3;
        ejercito = ejercito - hombresDistribuidos;
    }
    if (bandera1 == "v"){
        hombresDistribuidos = ejercito/2;
        ejercito = ejercito - hombresDistribuidos;
    }
    if (bandera1 == "r"){
        hombresDistribuidos = ejercito;
        ejercito = ejercito - hombresDistribuidos;
    }
}

function int leerPosicion(string bandera){
    string parte1 = bandera.Substring(0,1);

    int i;
    if (parte1 == "a"){
        i = 0;
    }
    if (parte1 == "v"){
        i = 1;
    }
    if (parte1 == "r"){
        i = 2;
    }

    return i;
}


//............................................................. Funciones y procedimientos del avistamiento de banderas
function bool verificarStr(string input){
    var patron = @"^[avr]$" ;
    var regex = Regex(patron);
    bool isValid = regex.IsMatch(input);
    return isValid;
}

function string bandera(){
    do{
        string bandera = readLine();
        isValid = verificarStr(temp);
        writeLine("Error, inserta la letra correcta");
    }while(isValid==false);
    return bandera;

}

procedure informeBanderas(string b1, string b2, string b3){
    writeLine("Banderas: " + b1);
    writeLine("Banderas: " + b2);
    writeLine("Banderas: " + b3);
}

