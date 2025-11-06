
Main{

          writeLine(“Introduce tu edad:”);

          string input  = readline();

          int edad = (int) input;

          string resultado = (edad >= 18) ? "Eres mayor de edad" : "Eres menor de edad";

          writeLine(resultado);

}