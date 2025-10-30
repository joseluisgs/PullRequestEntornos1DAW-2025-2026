using Math;

// constantes para el control del menú
const int OPCION_MENU_VER_SALA = 1;
const int OPCION_MENU_COMPRAR_ENTRADA = 2;
const int OPCION_MENU_DEVOLVER_ENTRADA = 3;
const int OPCION_MENU_VER_RECAUDACION = 4;
const int OPCION_MENU_VER_INFORME = 5;
const int OPCION_MENU_SALIR = 6;

// control de los asientos
const int BUTACA_VACIA = 0;
const int BUTACA_LIBRE = 1;
const int BUTACA_FUERA_SERVICIO = 2;

// precio por butaca
const decimal PRECIO_BUTACA = 6.50;

// dimensiones límite de la sala
const int FILAS_MINIMAS = 4;
const int FILAS_MAXIMAS = 7;
const int COLUMNAS_MINIMAS = 5;
const int COLUMNAS_MAXIMAS = 9;




Main {
    writeLine("* Bienvenido a CINEMAD 🤗");
    writeLine("Para comenzar la simulación se requieren las dimensiones de la sala. ");
    validarDimensiones("Filas " + FILAS_MINIMAS + "-" + FILAS_MAXIMAS". Columnas " + COLUMNAS_MINIMAS + "-" + COLUMNAS_MAXIMAS + " (F:C): ");
}


procedure validarDimensiones(string message) {

    bool isFormatoOk = false;
    bool isFilaOk:
    bool isColumnaOk;

    var patron = @"^[" + FILAS_MINIMAS + "-" + FILAS_MAXIMAS + "]:[" + COLUMNAS_MINIMAS + "-" + COLUMNAS_MAXIMAS + "]$";
    // var patron = @"^[4-7]:[5-9]$";

    var regexDimensiones = Regex(patron);

    do {
        writeLine(message);

        var input = readLine();

        isFormatoOk = regexDimensiones.isMatch(input);

        if (isFormatoOk) {

            isFilaOk = comprobarFila(input);
            isColumnaOk = comprobarColumna(input);

            if ((isFilaOk) && (isColumnaOk)) {
                writeLine("Iniciando simulación...");
            } else {
                isFormatoOk = false;
            }
            
        } else {
            writeLine("❌ Formato inválido. Use F:C (Ej 6:9).");
        }
    } while (!isFormatoOk);
}