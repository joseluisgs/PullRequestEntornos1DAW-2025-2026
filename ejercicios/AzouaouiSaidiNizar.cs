Ejercicio 42: Conversión de Temperatura con Criterio Múltiple y Ternario Anidado Pide 
al usuario una temperatura en grados Celsius (decimal). Utiliza el operador ternario (? :) 
anidado para asignar el resultado (string o decimal) basado en estas condiciones:

Si es < 0, convertir a Kelvin (C + 273.15).
Si es >= 0 Y < 100, convertir a Fahrenheit (C * 9/5 + 32).
Si es 100 o más, el resultado es la secuencia de texto "Punto de Ebullición". Muestra el resultado.

main {
    writeLine ("Dame una temperatura");
    decimal temp = readLine();
    var resultado = (temp 0)? temp+273,15 : temp;
    resultado = (resultado >= 0 && resultado <= 100)?resultado * 9/5+32: resultado ;
    resultado = (resultado >= 100)? (string) "Punto de ebullicion": resultado;
    writeLine (resultado);
}

