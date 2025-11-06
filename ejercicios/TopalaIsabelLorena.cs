Main {

    writeLine(“introduce un número entero”);
    string input = readLine();
    int numero = (int) input;

    bool validez = !(edad >= 10 && <=20);
    string valido = (validez == true) ? “Dentro del rango” : “Fuera de rango”;

    writeLine(“El numero es:” +valido);
    
}