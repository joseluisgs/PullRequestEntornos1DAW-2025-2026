
// Hundir la flotaa
using Math
// 1. CONSTANTES GLOBALES
const int ENTRAR_JUEGO = 1
const int SALIR_JUEGO = 2
const int TAMAÑO_MATRIZ = 10
const int NUM_SUBMARINOS = 4 // Submarinos de 1 casilla

// Estados del Tablero
const int AGUA = 0      // Casilla vacía / agua no atacada
const int SUBMARINO = 1 // Submarino sin hundir (solo en panel de flota)
const int FALLO = 2     // Tiro al agua (en panel de tiros)
const int ACIERTO = 3   // Submarino impactado/hundido (en ambos paneles)

Main {
    writeLine("Bienvenidos al juego de hundir la flota, ¿estas listo para ser el rey de los mares?")

    int[][]tablero = int[TAMAÑO_MATRIZ][TAMAÑO_MATRIZ]

    imprimirMenu()
}


procedure imprimirMenu() {
    var opcion = 0 // Debe ser inicializada
    
    do {
        // 1. LECTURA DE LA OPCIÓN
        opcion = leerEntero("Introduce una opción:") 

        // 2. EVALUACIÓN DE LA OPCIÓN (switch)
        switch(opcion) {
            case ENTRAR_JUEGO;
                simularJuego()
                break

            case SALIR_JUEGO;
                writeLine("¡Adiós, le echaremos de menos!");
                break
            
            default
                writeLine("¡ERROR, opción no valida. Vuelva a intentarlooo!");
                break
        } 
        
    } while (opcion != SALIR_JUEGO) // El bucle se repite mientras no se elija salir
}

funcion int leerEntero(string mensaje) {
    int valor = 0;
    bool isCorrecto = false;

    do {
        writeLine(mensaje)

        try {
            valor = (int) readLine();
            isCorrecto = true
        } catch (exception e) {
            writeLine("¡Error, introduzca el formato válido!")
        }
    } while (!isCorrecto)
    return valor
}

// Procedimiento que coordina la lógica completa del juego
procedure simularJuego() {
    // Declaracion de Matrices (Arrays Escalonados)
    int[][] flotaJ1 = int[TAMAÑO_MATRIZ][TAMAÑO_MATRIZ]; // Flota propia J1
    int[][] tirosJ1 = int[TAMAÑO_MATRIZ][TAMAÑO_MATRIZ]; // Tiros realizados por J1 (tablero enemigo)
    int[][] flotaJ2 = int[TAMAÑO_MATRIZ][TAMAÑO_MATRIZ]; // Flota propia J2
    int[][] tirosJ2 = int[TAMAÑO_MATRIZ][TAMAÑO_MATRIZ]; // Tiros realizados por J2 (tablero enemigo)

    // Variables de control
    var jugadorActual = 1;
    var victoria = false;
    
    // 1. Inicializar flotas (Posicionamiento aleatorio y validado)
    posicionarBarcos(flotaJ1, flotaJ2);
    writeLine("¡Flotas posicionadas! Que empiece la batalla.");

    // 2. Bucle principal del juego
    while (!victoria) {
        writeLine("\n======== TURNO DEL JUGADOR " + jugadorActual + " ========");
        
        // Declaración de variables de referencia del turno
        int[][] flotaObjetivo;
        int[][] tirosRegistro;
        string nombreOponente;
        
        // 2.1. Configuración de referencias (Paso por Referencia: las variables temporales apuntan a los arrays originales)
        if (jugadorActual == 1) {
            tirosRegistro = tirosJ1;
            flotaObjetivo = flotaJ2;
            nombreOponente = "JUGADOR 2";
            // Lógica para dibujar paneles de J1 (omitida, asumiendo función dibujarPanel)
        } else {
            tirosRegistro = tirosJ2;
            flotaObjetivo = flotaJ1;
            nombreOponente = "JUGADOR 1";
            // Lógica para dibujar paneles de J2 (omitida, asumiendo función dibujarPanel)
        }

        // 2.2. Obtención de Disparo con CONVERSIÓN DE ÍNDICE
        // Usamos TAMAÑO_MATRIZ (que es 10) para pedir un valor de 1 a 10
        writeLine("Ingresa la Fila de Disparo (1-" + TAMAÑO_MATRIZ + "): ");
        var filaUsuario = leerEntero("Fila:"); 
        // CONVERSIÓN CLAVE: De 1-Base a 0-Base
        var filaTiro = filaUsuario - 1; 

        writeLine("Ingresa la Columna de Disparo (1-" + TAMAÑO_MATRIZ + "): ");
        var columnaUsuario = leerEntero("Columna:");
        // CONVERSIÓN CLAVE: De 1-Base a 0-Base
        var columnaTiro = columnaUsuario - 1; 


        // 2.3. Procesar Tiro y Actualizar Paneles
        var resultadoTiro = procesarTiro(flotaObjetivo, tirosRegistro, filaTiro, columnaTiro);

        // 2.4. Comprobación de Victoria
        // Se cuenta el número de ACIERTOS registrados en el panel de tiros del jugador actual.
        // Se asume que NUM_SUBMARINOS es el total necesario para ganar.
        if (contarAciertos(tirosRegistro) == NUM_SUBMARINOS) {
            victoria = true;
            writeLine("¡VICTORIA para el JUGADOR " + jugadorActual + "! Has hundido la flota de " + nombreOponente);
        }

        // 2.5. Cambio de Turno
        if (!victoria) {
            if (jugadorActual == 1) {
                jugadorActual = 2; 
            } else {
                jugadorActual = 1;
            }
        }
    } 
}


procedure dibujarTablero(int[][] tablero) {
    // Bucle exterior: Recorre las filas (i < tablero.Length)
    for (int i = 0; i < tablero.Length; i++) {
        // Bucle interior: Recorre las columnas de la fila actual (j < tablero[i].Length)
        for (int j = 0; j < tablero[i].Length; j++) {
            // Se accede al elemento con doble índice [i][j]
            if (tablero[i][j] == AGUA) {
                write("~")
            } else if (tablero[i][j] == SUBMARINO) {
                write("S")
            } else if (tablero[i][j] == ACIERTO) {
                write("X")
            } else if (tablero[i][j] == FALLO) {
                write("F")
            } else {
                write("?")
            }
        }
        writeLine("") // Salto de línea al finalizar la impresión de la fila (i)
    }
} 


// Función corregida (asumiendo que posicionDisparo se divide en fila y columna)
function int procesarTiro(int[][] flotaObjetivo, int[][] tirosRegistro, int fila, int columna) {
    
    // 1. Comprobación de acierto en la flota del oponente
    if (flotaObjetivo[fila][columna] == SUBMARINO) { 
        // 2. Actualizar tablero de tiros del jugador: Acierto
        tirosRegistro[fila][columna] = ACIERTO 
        // 3. Actualizar la flota del oponente: Submarino hundido
        flotaObjetivo[fila][columna] = ACIERTO 
        return ACIERTO
    } else {
        // 2. Actualizar panel de tiros del jugador: Fallo
        tirosRegistro[fila][columna] = FALLO 
        return FALLO
    }
}


function bool revisarVecino(int[][] flota, int fila, int columna, int i_offset, int j_offset): bool {
var nuevaFila = fila + i_offset;
var nuevaColumna = columna + j_offset;


// 1. Verificar Límites del Array [1, 2]
if (nuevaFila >= 0 && nuevaFila < TAMAÑO_MATRIZ &&
    nuevaColumna >= 0 && nuevaColumna < TAMAÑO_MATRIZ) {

    // 2. SOLO si está en límites, chequear si hay un SUBMARINO
    if (flota[nuevaFila][nuevaColumna] == SUBMARINO) {
        return false // Encontramos un barco adyacente
    }
}

// Si la celda estaba fuera de límites o no contenía un submarino, no hay problema.
return true

}


function bool esSeguraPosicion( int[][]flota, int fila, int columna): bool {
    for (int i_offset = -1; i_offset <= 1; i_offset++) {
        for (int j_offset = -1; j_offset <= 1; j_offset++) {
            if (i_offset != 0 || j_offset != 0) {
                if (!revisarVecino(flota, fila, columna, i_offset, j_offset)) {
                    return false
                }
            }
        }
    }
    return true
}

// Procedimiento para colocar los submarinos aleatoriamente (incluido y validado)
procedure posicionarBarcos(int[][] flotaJ1, int[][] flotaJ2) {
    int submarino = SUBMARINO;

    // Colocación J1
    for (int i = 0; i < NUM_SUBMARINOS; i++) {
        var colocado = false;
        do {
            // Se necesitan dos coordenadas aleatorias para el Array Bidimensional
            var filaRandom = Math.random(0, TAMAÑO_MATRIZ);
            var columnaRandom = Math.random(0, TAMAÑO_MATRIZ);
            
            // Doble Validación: AGUA y No Adyacencia
            if (flotaJ1[filaRandom][columnaRandom] == AGUA && esSeguraPosicion(flotaJ1, filaRandom, columnaRandom)) {
                flotaJ1[filaRandom][columnaRandom] = submarino;
                colocado = true;
            }
        } while (!colocado);
    } 

    // Colocación J2
    for (int i = 0; i < NUM_SUBMARINOS; i++) {
        var colocado = false;
        do {
            var filaRandom = Math.random(0, TAMAÑO_MATRIZ);
            var columnaRandom = Math.random(0, TAMAÑO_MATRIZ);
            
            // Doble Validación: AGUA y No Adyacencia (sobre flotaJ2)
            if (flotaJ2[filaRandom][columnaRandom] == AGUA && esSeguraPosicion(flotaJ2, filaRandom, columnaRandom)) {
                flotaJ2[filaRandom][columnaRandom] = submarino;
                colocado = true;
            }
        } while (!colocado);
    } 
} 

// Función para contar los aciertos en el tablero de tiros del jugador 
function int contarAciertos(int[][]tiros) {
    int contador = 0
    for (int i = 0; i < tiros.Length; i++) {
        for (int j = 0; j < tiros[i].Length; j++)
        if (tiros[i][j] == ACIERTO) {
            contador = contador + 1
        }
    }
    return contador
}