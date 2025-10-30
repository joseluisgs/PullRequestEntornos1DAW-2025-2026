/*Impresión y Análisis Básico: Dado un vector de números enteros, obtenga funciones 
que permitan: 
a) imprimir el vector; 
b) calcular el máximo del vector; 
c) calcular el mínimo del vector; y 
d) calcular la media del vector.*/

// Imprimir el Vector 🖨️
procedure imprimirVector(int[] numeros){

    writeLine("El array Contiene los siguientes números:");

    foreach (int numero in numeros){
        writeLine("Numero: " + numero);
    }
}

// Número mayor del Array
function int numMaximo(int[] numeros){

    if (numeros.length == 0){
        throw new ArrayVacioException("Array vacio");
    } //Por precaucion, aqui se lanza una ArrayVacioException si el array no tiene tamaño

    int numeroMaximo = numeros[0];

    foreach (int numero in numeros){

        if (numero > numeroMaximo){
            numeroMaximo = numero;
        }
    }

    return numeroMaximo;
}

// Numero menor del Array
function int numMinimo(int[] numeros){

    if (numeros.length == 0){
        throw new ArrayVacioException("Array vacio");
    }

    int numeroMinimo = numeros[0];

    foreach (int numero in numeros){

        if (numero < numeroMinimo){
            numeroMinimo = numero;
        }
    }

    return numeroMinimo;
}

// Media del Array
function decimal mediaArray(int[] numeros){

    if (numeros.length == 0){
        throw new ArrayVacioException("Array vacio");
    }

    int suma = 0;
    decimal resultado = 0.0;

    for (int i = 0; i < numeros.length; i++){

        suma += numeros[i];
    }

    resultado = (decimal)suma / numeros.length;
    //Casting explicito para que el resultado sea decimal
    return resultado;
}

Main{

    var numeros = int[] { 25, 14, 86, 20, 55};
    imprimirVector(numeros);
    writeLine("Numero mas grande del array: " + numMaximo(numeros));
    writeLine("Numero mas pequeño del array: " + numMinimo(numeros));
    writeLine("La media del Array es: " + mediaArray(numeros));

}