using Math;

function int jugarMaquina() {
    return Math.random(1, 3);
}

//Funcion que determina un ganador
function int comprobarVictoria(int jugadaHumano, int jugadaMaquina) {

    

    // 1 (Piedra) > 3 (Tijera)
    // 2 (Papel) > 1 (Piedra)
    // 3 (Tijera) > 2 (Papel)

    //Comprobar empate
    if (jugadaHumano == jugadaMaquina) {
        return 0;
    }

    //Casos posibles en los que gana el humano
    if ((jugadaHumano == 1 && jugadaMaquina == 3) || 
        (jugadaHumano == 2 && jugadaMaquina == 1) ||
        (jugadaHumano == 3 && jugadaMaquina == 2)) {
        
        return 1;

    } 
        
    return -1;

}

Main {


    //Inicializamos victorias a 0
    int victoriaHumano = 0;
    int victoriaMaquina = 0;

    int jugarHumano = 0;
    bool isOk = false;

    writeLine("----------------------------------");
    writeLine("PIEDRA, PAPEL O TIJERA");
    writeLine("----------------------------------");

    writeLine("REGLAS");
    writeLine("[1] = PIEDRA, [2] = PAPEL, [3] = TIJERA");
    writeLine("[Piedra gana a tijera], [Papel gana a piedra], [Tijera gana a papel]");


    //Bucle que comprueba la entrada de datos
    do {

        try {
            jugarHumano = (int) readLine();
            isOk = true;

        } catch(NumberFormatException) {
            writeLine("Introduce un formato valido de tipo entero entre 1 y 3");
            isOk = false;

        }

    } while(!isOk)

    //Llamada a la funcion jugarMaquina()
    int maquinaJugada = jugarMaquina();

    //Llamada a la funcion comprobarVictoria()
    int comprobar = comprobarVictoria(jugarHumano, maquinaJugada);

    //Comprobante por si gana la maquina
    if(comprobar == -1) {
        victoriaMaquina = victoriaMaquina + 1;
        writeLine("victorias maquina:" + victoriaMaquina);

    //Comprobante por si gana el usuario
    } else if(comprobar == 1) {
        victoriaHumano = victoriaHumano + 1;
        writeLine("victorias humano:" + victoriaHumano);

    //En cualquier otro caso es empate
    } else {
        writeLine("Empate");

    }

    writeLine("El jugador ha sacado :" + jugarHumano + "La maquina ha sacado:" + maquinaJugada );

    //Imprimimos los resultados
    writeLine("Victorias del usuario:" + victoriaHumano + "Victoria de la maquina:" + victoriaMaquina);
