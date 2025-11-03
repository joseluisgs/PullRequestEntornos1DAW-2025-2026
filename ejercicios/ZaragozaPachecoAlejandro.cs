using Math;

const int TAM_FILAS = 5;
const int TAM_COLUMNAS = 6;
const int NUM_BUTACAS_FS = 3; 
const double PRECIO_ENTRADA = 5.50; 

const int OPCION_MOSTRAR = 1;
const int OPCION_COMPRAR = 2;
const int OPCION_DEVOLVER = 3;
const int OPCION_INFORME = 4;
const int OPCION_SALIR = 5;

enum Estado {
    LIBRE,         
    OCUPADA,       
    FUERA_SERVICIO 
}

struct Posicion {
    int fila;
    int columna;
}

struct Butaca {
    Posicion posicion; 
    decimal precio; 
    Estado estado;

Main {
    Butaca[][] sala = Butaca[TAM_FILAS][TAM_COLUMNAS];

    initButacas(sala); 
    
    writeLine("Bienvenido al cine");
    writeLine("=====================");
    writeLine("");
    
    var opcion = 0;
    
    do {
        writeLine(OPCION_MOSTRAR + ". Mostrar sala");
        writeLine(OPCION_COMPRAR + ". Comprar entrada");
        writeLine(OPCION_DEVOLVER + ". Devolver entrada");
        writeLine(OPCION_INFORME + ". Informe final (Estadísticas)");
        writeLine(OPCION_SALIR + ". Salir");
        write("Ingrese una opción: ");
        
        var inputOpcion = readLine().Trim();

        var patronOpcion = @"^[1-5]$";
        var regexOpcion = Regex(patronOpcion);
        
        opcion = 0;

        
        if (regexOpcion.IsMatch(inputOpcion)) {
            opcion = (int)inputOpcion[0];
        }

        switch (opcion) {
            case OPCION_MOSTRAR:
                mostrarSala(sala);
                break;
            case OPCION_COMPRAR:
                comprarEntrada(sala);
                break;
            case OPCION_DEVOLVER:
                devolverEntrada(sala);
                break;
            case OPCION_INFORME:
                generarInforme(sala);
                break;
            case OPCION_SALIR:
                writeLine("¡Hasta luego!");
                break;
            default:
                writeLine("Opción no válida");
                break;
        }
        
        writeLine("");
    } while (opcion != OPCION_SALIR);
}

procedure initButacas(Butaca[][] sala) {
    for (int i = 0; i < sala.Length; i++) {
        for (int j = 0; j < sala[i].Length; j++) {
            Posicion posicion = Posicion { fila = i, columna = j};
            Butaca butaca = Butaca {
                posicion = posicion;
                precio = PRECIO_ENTRADA;
                estado = Estado.LIBRE
            }
            sala[i][j] = butaca;
        }
    }
    
    writeLine("Inicializando sala. Estableciendo " + NUM_BUTACAS_FS + " butacas fuera de servicio aleatoriamente.");

    var countFS = 0;
    while (countFS < NUM_BUTACAS_FS) {
        var randFila = Math.Random(0, TAM_FILAS - 1);
        var randColumna = Math.Random(0, TAM_COLUMNAS - 1);

        if (sala[randFila][randColumna].estado != Estado.FUERA_SERVICIO) {
            sala[randFila][randColumna].estado = Estado.FUERA_SERVICIO;
            countFS = countFS + 1;
        }
    }
}

procedure mostrarSala(Butaca[][] sala) {
    writeLine("Estado de la sala de cine");
    
    write("    ");
    for (int i = 1; i <= sala.Length; i++) {
        write(" | " + i + "  "); 
    }
    writeLine(" |");
    
    for (int fila = 0; fila < sala.Length; fila++) {
        write(" " + obtenerLetra(fila) + " "); 

        for (int columna = 0; columna < sala[fila].Length; columna++) {
            if (sala[fila][columna].estado == Estado.OCUPADA) {
                write(" | 🔴 "); 
            } else if (sala[fila][columna].estado == Estado.FUERA_SERVICIO) {
                write(" | 🚫 "); 
            } else {
                write(" | 🟢 ");
            }
        }
        writeLine(" |"); 
    }
    writeLine("");
}

function string obtenerLetra(int fila) {
    const string filasLetras = "ABCDE";
    return filasLetras[fila];
}

function int obtenerIndiceFila(string letra) {
    const string filasLetras = "ABCDE";
    return filasLetras.IndexOf(letra);
}

procedureocuparButaca(Butaca[][] sala, Posicion posicion) {
    sala[posicion.fila][posicion.columna] = Estado.OCUPADA;
    writeLine("Butaca ocupada correctamente. Coste: " + PRECIO_ENTRADA + " €");
}

function boolean hayButacaLibre(Butaca[][] sala) {
    for (int fila = 0; fila < TAM; fila++) {
        for (int columna = 0; columna < TAM; columna++) {
            if (sala[fila][columna].estado == Estado.LIBRE) {
                return true;
            }
        }
    }
    return false;
}

procedure comprarEntrada(Butaca[][] sala) {
    writeLine("");
    if (hayButacaLibre(sala) == false) {
        writeLine("No hay butacas libres disponibles para la venta.");
        return;
    }
    
    var isCorrecto = false;
    do {
        writeLine("Ingrese la fila y la columna a comprar (Fila:Columna, Ejemplo: A:2): ");
        
        var patron = @"^[A-E]:[1-5]$";
        var regex = Regex(patron);
        var input = readLine().Trim().ToUpper();

        if (regex.IsMatch(input) == false) {
            writeLine("No has introducido una butaca válida (Ejemplo: A:2).");
            isCorrecto = false;
        } else {
            var inputSplit = input.Split(':');
            Posicion posicion = Posicion {
                fila = obtenerIndiceFila(inputSplit[0]), 
                columna = (int)inputSplit[1][0] - 1
            };
           
            if (sala[posicion.fila][posicion.columna].estado == TipoButaca.LIBRE) {
                ocuparButaca(sala, posicion);
                writeLine("✅ Compra realizada correctamente. Coste: " + PRECIO_ENTRADA + " €");
                writeLine("✅ Butaca " + input + (posicion.columna + 1) + " ocupada.");
                isCorrecto = true;
            } 
        
            else if (sala[posicion.fila][posicion.columna].estado == TipoButaca.FUERA_SERVICIO) {
                writeLine("🔴 La butaca " + input + " está fuera de servicio.");
                isCorrecto = false;
            } 
            else if (isOcupada(sala, posicion)) { 
                writeLine("La butaca " + input + " ya está ocupada.");
                isCorrecto = false;
            } 
            else {
                 writeLine("🔴 Error desconocido al comprar la butaca " + input + ".");
                 isCorrecto = false;
            }
        }
    } while (isCorrecto == false);
}

procedure liberarButaca(Butaca[][] sala, Posicion posicion) {
    sala[posicion.fila][posicion.columna] = Butaca.LIBRE;
    writeLine("Butaca liberada correctamente");
}

procedure devolverEntrada(TipoButaca[][] sala) {
    writeLine("");
    var isCorrecto = false;
    
    do {
        writeLine("Ingrese la fila y la columna a devolver (Fila:Columna, Ejemplo: A:2): ");
        
        var patron = @"^[A-E]:[1-5]$";
        var regex = Regex(patron);
        var input = readLine().Trim().ToUpper();

        if (regex.IsMatch(input) == false) {
            writeLine("No has introducido una butaca válida.");
            isCorrecto = false;
        } else {
            var inputSplit = input.Split(':');
            Posicion posicion = Posicion {
                fila = obtenerIndiceFila(inputSplit[0]),
                columna = (int)inputSplit[1][0] - 1
            }; 

            if (isOcupada(sala, posicion) == false) {
                writeLine("🔴 La butaca " + input + " no estaba ocupada y no puede ser devuelta.");
                isCorrecto = false;
            } else {
                liberarButaca(sala, posicion);
                writeLine("✅ Devolución realizada correctamente.");
                isCorrecto = true;
            }
        }
    } while (isCorrecto == false);
}

function int contarButacas(Butaca[][] sala, Estado estado) {
    var contador = 0;
    for (int fila = 0; fila < sala.Length; fila++) {
        for (int columna = 0; columna < sala[fila].Length; columna++) {
            if (sala[fila][columna].estado == estado) {
                contador = contador + 1;
            }
        }
    }
    return contador;
}

function double obtenerRecaudacion(Butaca[][] sala) {
    // Casting de int a double es necesario para la multiplicación.
    var vendidas = contarButacas(sala, Estado.OCUPADA);
    return (double)vendidas * PRECIO_ENTRADA;
}

function double obtenerPorcentajeOcupacion(int vendidas, int disponibles) {
    if (disponibles == 0) {
        return 0.0;
    }
    var porcentaje = ((double)vendidas / (double)disponibles) * 100.0; 
    return porcentaje;
}


procedure generarInforme(Butaca[][] sala) {
    writeLine("");
    var vendidas = contarButacas(sala, Estado.OCUPADA);
    var libres = contarButacas(sala, Estado.LIBRE);
    var fs = contarButacas(sala, Estado.FUERA_SERVICIO);
    
    var disponibles =  vendidas + libres; // Butacas que no están F/S
    
    var ocupacionPorcentaje = obtenerPorcentajeOcupacion(vendidas, disponibles);
    var recaudacionTotal = obtenerRecaudacion(sala);
    
    var informe = StringBuilder();

    informe.Append("--- INFORME CINEDAW ---");
    informe.Append("\nEntradas Vendidas: " + vendidas);
    informe.Append("\nAsientos Libres: " + libres);
    informe.Append("\nAsientos No Disponibles (F/S): " + fs);
    informe.Append("\nOcupación: " + formatDouble(ocupacionPorcentaje, 2) + "% (sobre " + disponibles + " asientos disponibles)");
    informe.Append("\nRecaudación Total: " + formatDouble(recaudacionTotal, 2) + "€");

    writeLine(informe.ToString());
}


function boolean isOcupada(Butaca[][] sala, Posicion posicion) {
    return sala[posicion.fila][posicion.columna].estado == Estado.OCUPADA;
}

function string formatDouble(double value, int decimals) {

    var factor = Math.Pow(10, decimals); 
    var roundedValue = (int)(value * factor);
    var finalValue = (double)roundedValue / factor;
    return "" + finalValue;
}