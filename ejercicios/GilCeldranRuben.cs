Main {

    writeLine(“introduce un numero del que quieras calcular la media:”);

    string input = readLine();
    decimal num1 = (decimal) input;

    writeLine(“introduce segundo numero”);

    string input2 = readLine();
    decimal num2 = (decimal) input2;

    writeLine(“introduce un tercer numero”);

    string input3 = readLine();
    decimal num3 = (decimal) input3;

    var resultado = (num1 + num2 + num3) / 3;

    writeLine(resultado);

}