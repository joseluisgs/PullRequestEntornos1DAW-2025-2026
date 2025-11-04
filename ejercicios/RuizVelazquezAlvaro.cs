/*
    Importamos la librería Math para poder realizaaar operaciones matemáticas complejas
*/
using Math;

/*
    Declaramos las constantes que usaremos en diferentes partes del programa
*/
const int OPCION_MENU_SUMAR = 1;
const int OPCION_MENU_RESTAR = 2;
const int OPCION_MENU_MULTIPLICAR = 3;
const int OPCION_MENU_DIVIDIR = 4;
const int OPCION_MENU_RAIZ_CUADRADA = 5;
const int OPCION_MENU_SALIR = 6;

/*
    Creamos el Main
*/
Main{    
    menu("----Calculadora----");
    writeLine("Hasta pronto!!!!");
}

/*
    Creamos procedimiento para el Menu de la calculadora
*/
procedure menu(string msgMenu){
    int opcion;
    writeLine(msgMenu);
    do{
        writeLine("Elija una opción:");
        writeLine(OPCION_MENU_SUMAR + ".- Sumar.");
        writeLine(OPCION_MENU_RESTAR + ".- Restar.");
        writeLine(OPCION_MENU_MULTIPLICAR + ".- Multiplicar.");
        writeLine(OPCION_MENU_DIVIDIR + ".- Dividir.");
        writeLine(OPCION_MENU_RAIZ_CUADRADA + ".- Raíz Cuadrada.");
        writeLine(OPCION_MENU_SALIR + ".- Salir.");
        
        opcion=leerEntero("Opción elegida: ");

        switch (opcionElegida) {
            case OPCION_MENU_SUMAR:
                sumar("Opción elegida: Sumar");
                break;
            case OPCION_MENU_RESTAR:
                restar("Opción elegida: Restar");
                break;
            case OPCION_MENU_MULTIPLICAR:
                multiplicar("Opción elegida: Multiplicar");
                break;
            case OPCION_MENU_DIVIDIR:
                dividir("Opción elegida: Dividir");
                break;
            case OPCION_MENU_RAIZ_CUADRADA:
                raiz("Opción elegida: Raíz Cuadrada");
                break;
            case OPCION_MENU_SALIR:
                writeLine("Saliendo de la calculadora...");
                break;
            default:
                writeLine("Opción no válida.");
                break;
        }
    }while(opcionElegida != OPCION_MENU_SALIR)
}

/*
    Creamos las funciones que nos comprobarán que los parámetros indtroducidos son correctos
*/
function int leerEntero(string mensaje) {
    int valorLeido = 0;
    bool formatoCorrecto = false;

    do {
        writeLine(mensaje);
        try {
            valorLeido = (int)readLine(); 
            formatoCorrecto = true;
        } catch (Exception e) {
            writeLine("Error... Se debe introducir un número entero.");
        }
    } while (!formatoCorrecto);

    return valorLeido;
}

function decimal leerDecimal(string mensaje) {
    decimal valorLeido = 0.0;
    bool formatoCorrecto = false;

    do {
        writeLine(mensaje);
        try {
            valorLeido = (decimal)readLine(); 
            formatoCorrecto = true;
        } catch (Exception e) {
            writeLine("Error... Se debe introducir un número decimal.");
        }
    } while (!formatoCorrecto);

    return valorLeido;
}

function decimal leerDecimalDivisor(string mensaje) {
    decimal valorLeido = 0.0;
    bool formatoCorrecto = false;

    do {
        writeLine(mensaje);
        try {
            valorLeido = (decimal)readLine(); 
            if(valorLeido==0.0){
                writeLine("Error... No se puede dividir entre 0");
            }else{
                formatoCorrecto = true;
            }
        } catch (Exception e) {
            writeLine("Error... Se debe introducir un número distinto de cero.");
        }
    } while (!formatoCorrecto);

    return valorLeido;
}

function decimal leerDecimalRaiz(string mensaje) {
    decimal valorLeido = 0.0;
    bool formatoCorrecto = false;

    do {
        writeLine(mensaje);
        try {
            valorLeido = (decimal)readLine(); 
            if(valorLeido<0.0){
                writeLine("Error... No se puede hacer la raíz de un numero negativo.");
            }else{
                formatoCorrecto = true;
            }
        } catch (Exception e) {
            writeLine("Error... Se debe introducir un número positivo.");
        }
    } while (!formatoCorrecto);

    return valorLeido;
}

/*
    Creamos las funciones que nos realizarán las operaciones
*/
function decimal sumar(string msgSuma){
    writeLine(msgSuma);
    decimal numUno = leerDecimal("Introduce el primer nº:");
    decimal numDos = leerDecimal("Introduce el segundo nº:");
    return numUno+numDos;
}

function decimal restar(string msgResta){
    writeLine(msgResta);
    decimal numUno = leerDecimal("Introduce el primer nº:");
    decimal numDos = leerDecimal("Introduce el segundo nº:");
    return numUno-numDos;
}

function decimal multiplicar(string msgMulti){
    writeLine(msgMulti);
    decimal numUno = leerDecimal("Introduce el primer nº:");
    decimal numDos = leerDecimal("Introduce el segundo nº:");
    return numUno*numDos;
}

function decimal dividir(string msgDividir){
    writeLine(msgDividir);
    decimal numUno = leerDecimal("Introduce el primer nº:");
    decimal numDos = leerDecimalDivisor("Introduce el segundo nº:");
    return numUno/numDos;
}

function decimal raiz(string msgRaiz){
    writeLine(msgRaiz);
    decimal num = leerDecimalRaiz("Introduce un nº:");
    return Math.sqrt(num);
}