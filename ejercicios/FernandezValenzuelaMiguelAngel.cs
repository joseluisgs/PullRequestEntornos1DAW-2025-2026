Main {

    writeLine("Introduce un número entero:");

    string input= readline();

    int numero = (int) input;

    bool menorCero = (numero < 0);

    bool mayorCien = (numero > 100);

    bool resultado = menorCero || mayorCien;

    writeLine(resultado);

}