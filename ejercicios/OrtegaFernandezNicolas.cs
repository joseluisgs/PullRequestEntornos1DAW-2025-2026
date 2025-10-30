using Math;

// constantes para el control del menú
const int OPCION_MENU_VER_SALA = 1;
const int OPCION_MENU_COMPRAR_ENTRADA = 2;
const int OPCION_MENU_DEVOLVER_ENTRADA = 3;
const int OPCION_MENU_VER_RECAUDACION = 4;
const int OPCION_MENU_VER_INFORME = 5;
const int OPCION_MENU_SALIR = 6;

// control de los asientos
const int BUTACA_LIBRE = 0;
const int BUTACA_OCUPADA = 1;
const int BUTACA_FUERA_SERVICIO = 2;

// precio por butaca
const decimal PRECIO_BUTACA = 6.50; 

// dimensiones límite de la sala
const int FILAS_MINIMAS = 4;
const int FILAS_MAXIMAS = 7;
const int COLUMNAS_MINIMAS = 5;
const int COLUMNAS_MAXIMAS = 9;

const int NUM_BUTACAS_ROTAS = 3;


Main {
    readonly int filas;
    readonly int columnas;

    writeLine("* Bienvenido a CINEMAD 🤗");
    writeLine("Para comenzar la simulación se requieren las dimensiones de la sala. ");
    validarDimensiones("Filas " + FILAS_MINIMAS + "-" + FILAS_MAXIMAS + ". Columnas " + COLUMNAS_MINIMAS + "-" + COLUMNAS_MAXIMAS + " (F:C): ", out filas, out columnas);

    ejecutarMenu(filas, columnas);
}

procedure ejecutarMenu(int filas, int columnas) {

    int opcionElegida = 0;
    bool isOpcionOk = false;

    // variables para el informe
    decimal recaudacion = 0.0;
    int numEntradasVendidas = 0;
    int numButacasLibres = filas * columnas - NUM_BUTACAS_ROTAS;
    int numButacasOcupadas = 0;

    // creación de la sala (matriz)
    int[][] sala = int[filas][columnas];
    configurarSala(sala, filas, columnas);

    do {

        writeLine("--🍿 Sala 1 de CINEMAD 🍿--");
        writeLine("---------------------------");
        writeLine(OPCION_MENU_VER_SALA + ".- 💺 Ver asientos.");
        writeLine(OPCION_MENU_COMPRAR_ENTRADA + ".- 🎟 Comprar entrada.");
        writeLine(OPCION_MENU_DEVOLVER_ENTRADA + ".- 😣 Devolver entrada.");
        writeLine(OPCION_MENU_VER_RECAUDACION + ".- 💰 Recaudación sala.");
        writeLine(OPCION_MENU_VER_INFORME + ".- 📊 Informe de sala.");
        writeLine(OPCION_MENU_SALIR + ".- 💨 Salir.");
        writeLine("---------------------------");
        opcionElegida = validarOpcion("Opción elegida: ");

        asignarAccion(sala, opcionElegida, filas, columnas, ref recaudacion, ref numEntradasVendidas, ref numButacasLibres, ref numButacasOcupadas);

    } while (opcionElegida != OPCION_MENU_SALIR); // no sale hasta que se le indica
}

procedure asignarAccion(int[][] sala, int opcionElegida, int filas, int columnas, ref decimal recaudacion, ref int numEntradasVendidas, ref numButacasLibres, ref int numButacasOcupadas) {

    switch (opcionElegida) {

        case OPCION_MENU_VER_SALA:
            imprimirSala(sala, filas, columnas);
            break;

        case OPCION_MENU_COMPRAR_ENTRADA:
            comprarEntrada(sala, filas, columnas, ref recaudacion, ref numEntradasVendidas, ref numButacasLibres, ref numButacasOcupadas);
            break;

        case OPCION_MENU_DEVOLVER_ENTRADA:
            devolverEntrada(sala, filas, columnas, ref recaudacion, ref numEntradasVendidas, ref numButacasLibres, ref numButacasOcupadas);
            break;

        case OPCION_MENU_VER_RECAUDACION:
            mostrarRecaudacion(recaudacion);
            break;

        case OPCION_MENU_VER_INFORME:
            mostrarInforme(filas, columnas, numEntradasVendidas, numButacasLibres, recaudacion);
            break;

        case OPCION_MENU_SALIR:
            writeLine("Ha sido un placer, ¡vuelve pronto! 😋");
            break;

        // aquí no debería entrar nunca ya que la expresion regular no permite otros valores
        default:
            writeLine("❌ Opción no válida. Por favor, introduzca una de las " + OPCION_MENU_SALIR + " opciones posibles.");
            break;
    }
}

procedure configurarSala(int[][] sala, int filas, int columnas) {

    int butacasRotas = NUM_BUTACAS_ROTAS;

    // bucle para cambiar los 0 por 2 donde la butaca este fuera de servicio
    while (butacasRotas > 0) {

        int filaButacaRota = Math.random(0, filas - 1);
        int columnaButacaRota = Math.random(0, columnas - 1);

        if (sala[filaButacaRota][columnaButacaRota] == BUTACA_LIBRE) {
        
            sala[filaButacaRota][columnaButacaRota] = BUTACA_FUERA_SERVICIO;
            butacasRotas -= 1;
        }
    }
}


procedure imprimirSala(int[][] sala, int filas, int columnas) {

    writeLine("-- SALA 1 CINEMAD --");
    writeLine("");

    // 3 espacios necesarios para compensar las letras
    write("   "); 

    // --------------------------------------------------------------------------
    // escritura de los numeros de columna
    for (int j = 0; j < columnas; j += 1) {
        write(" " + (j + 1) + "  ");
    }
    writeLine("");

    string letras = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ";

    // recorremos la sala
    for (int i = 0; i < sala.Length; i += 1) {
        for (int j = 0; j < sala[i].Length; j += 1) {

            // si estas al inicio de una fila lo primero la letra de esa fila
            if (j == 0) {
                write(letras[i] + " ");
            }

            if (sala[i][j] == BUTACA_LIBRE) {
                write("[🟢] ");

            } else if (sala[i][j] == BUTACA_OCUPADA) {
                write("[🔴] ");

            } else if (sala[i][j] == BUTACA_FUERA_SERVICIO) {
                write("[🚫] ");
            }
        }
        writeLine(""); // salto de línea 
    }
    // --------------------------------------------------------------------------

    writeLine("--------------------------");
}

procedure comprarEntrada(int[][] sala, int filas, int columnas, ref decimal recaudacion, ref int numEntradasVendidas, ref int numButacasLibres, ref int numButacasOcupadas) {

    int filaEntrada;
    int columnaEntrada;

    bool isButacaValida = false;

    writeLine("---------------------");
    writeLine("El precio por entrada es de " + PRECIO_BUTACA + "€");
    do {

        validarPosicionEntrada("Introduzca la cordenada de la butaca que desee (Ej: B:3): ", out filaEntrada, out columnaEntrada, filas, columnas);

        if (sala[filaEntrada][columnaEntrada] == BUTACA_LIBRE) {
            // marcamos como ocupada
            sala[filaEntrada][columnaEntrada] = BUTACA_OCUPADA;
            isButacaValida = true;

            recaudacion += PRECIO_BUTACA;
            numEntradasVendidas += 1;
            numButacasOcupadas += 1;
            numButacasLibres -= 1;

        } else if (sala[filaEntrada][columnaEntrada] == BUTACA_OCUPADA) {
            writeLine("⚠ La butaca que ha seleccionado está ocupada.");

        } else if (sala[filaEntrada]columnaEntrada[] == BUTACA_FUERA_SERVICIO) {
            writeLine("⚠ La butaca que ha seleccionado está fuera de servicio.");
        }
        
    } while (!isButacaValida);
}

procedure devolverEntrada(int[][]sala, int filas, int columnas, ref decimal recaudacion, ref int numEntradasVendidas, ref int numButacasLibres, ref int numButacasOcupadas) {

    int filaEntrada;
    int columnaEntrada;

    bool isButacaValida = false;

    writeLine("---------------------");
    do {

        validarPosicionEntrada("Introduzca la cordenada de la butaca que desee (Ej: B:3): ", out filaEntrada, out columnaEntrada, filas, columnas);

        if (sala[filaEntrada]columnaEntrada[] == BUTACA_LIBRE) {
            writeLine("⚠ La butaca que ha seleccionado está libre.");

        } else if (sala[filaEntrada][columnaEntrada] == BUTACA_OCUPADA) {
            // marcamos como libre
            sala[filaEntrada][columnaEntrada] = BUTACA_LIBRE;
            isButacaValida = true;

            recaudacion -= PRECIO_BUTACA;
            numEntradasVendidas -= 1;
            numButacasOcupadas -= 1;
            numButacasLibres += 1;

        } else if (sala[filaEntrada]columnaEntrada[] == BUTACA_FUERA_SERVICIO) {
            writeLine("⚠ La butaca que ha seleccionado está fuera de servicio.");
        }
        
    } while (!isButacaValida);
}


procedure mostrarRecaudacion(decimal recaudacion) {

    decimal numEntradas = recaudacion / PRECIO_BUTACA;

    writeLine("-------------------");
    writeLine("Entradas vendidas: " + (int)numEntradas + "🎟 || Total recaudado: " + recaudacion + "€");
    writeLine("-------------------");
}

procedure mostrarInforme(int filas, int columnas, int numEntradasVendidas, int numButacasLibres, decimal recaudacion) {

    int numButacas = filas * columnas;

    decimal ocupacion = (decimal)numEntradasVendidas / (numButacas - NUM_BUTACAS_ROTAS) * 100;

    writeLine("---🎬 INFORME CINEMAD 🎬---");
    writeLine("Entradas vendidas: " + numEntradasVendidas + "🎟");
    writeLine("Butacas libres: " + numButacasLibres + "🟢");
    writeLine("Butacas no disponibles: " + NUM_BUTACAS_ROTAS + "🚫");
    writeLine("Ocupación: " + ocupacion);
    writeLine("Recaudación total: " + recaudacion + "€");
    writeLine("----------------------------");

}


procedure validarDimensiones(string message, out int filas, out int columnas) {

    bool isFormatoOk = false;

    var patron = @"^[" + FILAS_MINIMAS + "-" + FILAS_MAXIMAS + "]:[" + COLUMNAS_MINIMAS + "-" + COLUMNAS_MAXIMAS + "]$";
    // var patron = @"^[4-7]:[5-9]$";
    var regexDimensiones = Regex(patron);

    do {
        writeLine(message);
        var input = readLine().Trim();

        // comprobacion de que lo introducido cumple el regex
        isFormatoOk = regexDimensiones.isMatch(input);

        // si pasa la expresion regular, guarda los datos en variables y saldrá del bucle
        if (isFormatoOk) {

            extraerDatos(input, out filas, out columnas);
            writeLine("Comenzando con la simulación....");
            
        } else {
            writeLine("❌ Formato inválido. Use F:C (Ej 6:9).");
        }
    } while (!isFormatoOk); // no sale hasta que el formato no sea el correcto
}

procedure extraerDatos(string input, out int filas, out int columnas) {

    string[] dimensiones = input.split(":"); // ["Fila", "Columna"]

    filas = (int)dimensiones[0]; // extraemos la fila y la casteamos 
    columnas = (int)dimensiones[1]; // extraemos columna y la casteamos 
}


function int validarOpcion(string message) {

    bool isOk = false;
    int numero = 0;

    // creamos la expresion regular
    var patron = @"^[" + OPCION_MENU_VER_SALA + "-" + OPCION_MENU_SALIR + "]$";
    var regexEntero = Regex(patron);

    do {
        writeLine(message);
        var input = readLine().Trim();

        // comprobacion de que lo introducido cumple el regex
        isOk = regexEntero.isMatch(input);

        if (isOk) {
            numero = (int)input;
        } else {
            writeLine("❌ Opción no reconocida. Por favor, introduzca una de las " + OPCION_MENU_SALIR + " opciones posibles.");
        }
    } while(!isOk); // no sale hasta que el formato no sea el correcto

    return numero;
}


procedure validarPosicionEntrada(string message, out int filaEntrada, out int columnaEntrada, int filas, int columnas) {

    bool isOk = false;

    string letras = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ";
    string letraMaxima = letras[filas - 1];


    var patron = @"^[A-" + letraMaxima + "]:[1-" + columnas + "]$";
    var regex = Regex(patron);

    // Inicialización de los parámetros de salida
    filaEntrada = -1;
    columnaEntrada = -1;

    do {
        writeLine(message);
        var input = readLine().Trim();

        isOk = regex.isMatch(input);

        if (!isOk) {
            writeLine("❌ Error en la entrada de datos. Por favor, introduza la letra y la columna correspondiente (Fila:Columna)");
        } else {

            // leemos la fila
            string letraEscogida = input[0];
            filaEntrada = letras.IndexOf(letraEscogida);
            // leemos la columna
            columnaEntrada = (int)input[2] - 1;

            writeLine("✅ Butaca leída con éxito.");
        }

    } while(!isOk);
}


