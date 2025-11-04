function dateValidator(string mensaje) {
    bool isOk = false;
    bool isDiaOk = false;
    var inputFecha = "";
    var regex = "^([0-2][0-9]|3[0-1])\/(0[1-9]|1[0-2])\/\d{4}$"

    do {
        writeline(mensaje);
        inputFecha = readLine();
        isOk = regex.IsMatch(inputFecha);

        if(isOk){

            //Hago subcadenas de dias/mes/año
            var cadDias = inputFecha.Substring(0, 2); 
            int dias = (int)cadDias;

            var cadMes = inputFecha.Substring(3, 2); 
            
            var cadAño = inputFecha.Substring(6, 4);

            //Compruebo si es o no bisiesto
            bool isAñoBisiesto = esBisiesto(cadAño);
            //Comrpuebo los dias maximos de cada mes
            int maxDiasPermitidos = diaValidator(isAñoBisiesto, cadMes);

            //Condicion que nos devuelve un boleano 
            if(dias >= 1 && dias <= maxDiasPermitidos) {
                writeline("La fecha es completamente válida. ✅");
                isDiaOk = true;
            } else {
                 writeline("Error: La fecha es imposible (días fuera de rango para ese mes y año).");
            }
        }
    //No sale del bucle hasta que isDiaOk es valido
    //isOk no es necesario ya q si la regex esta mal significa q no puede entrar en el if
    //para comprobar los valores dentro de los rangos
    }while(!isDiaOk)

}
function bool esBisiesto(string cadAño) {
    int año = (int)cadAño;
    bool isValido = false;
    if((año % 4 == 0 && año % 100 != 0) || (año % 400 == 0)) {
        isValido = true;
    }
    return isValido;
}

function int diaValidator(bool isAñoBisiesto, string cadMes) {
    int diasMaximo;
    int mes = (int)cadMes;
    if(mes == 2){
        diasMaximo = isAñoBisiesto? 29 : 28;
    } else if(mes == 4 || mes == 6 || mes == 9 || mes == 11) {
        diasMaximo = 30;
    } else {
        diasMaximo = 31;
    }
    return diasMaximo;
} 
Main {
    dateValidator("Ingreseme una fecha con formato: dd/mm/aaaa")
}