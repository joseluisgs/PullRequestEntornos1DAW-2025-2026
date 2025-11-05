/*
Impresión y Análisis Básico: Dado un vector de números enteros, obtenga funciones que permitan:
 a) imprimir el vector.
 b) calcular el máximo del vector. 
 c)calcular el mínimo del vector.
 d) calcular la media del vector.
*/

/*
----- ZONA DE FUNCIONES Y PROCEDIMIENTOS -----
*/

//Procedimiento que imprime los elementos de un vector
procedure printVector(int[] vector) {

    foreach(var elements in vector) {
        writeLine(elements);
    }
}

//Funcion que calcula el elemento maximo (el mayor) de el vector y devuelve un entero
function int maximumVector(int[] vector) {
    var max = vector[0];

    //Metodo foreach que recorrera todos los elementos del vector
    foreach(var elements in vector) {

        //Si el elemento es mayor que el maximo, el maximo pasa a ser el elemento mayor en esa iteración
        if(elements > max) {
            max = elements; 
        }

    }

    return max; //Devolvemos el resultado de max (ej. 9)
}


//Funcion que calcula el elemento minimo (el menor) de el vector y devuelve un entero
function int minimumVector(int[] vector) {
    var min = vector[0];

    //Metodo foreach que recorrera todos los elementos del vector
    foreach(elements in vector) {
        
        //Si el elemento es menor que el minimo, el minimo pasa a ser el elemento menor en esa iteración
        if(elements < min) {
            min = elements; 
        }

    }

    return min; //Devolvemos el resultado de min (ej. 2)
}

//Funcion que calcula la media de un vector y devuelve un decimal
function decimal averageVector(int[] vector) {

    //Variable contador para comprobar la cantidad de elementos a dividir
    var counter = 0;

    for(int i = 0; i < vector.Length; i++) {
        counter = counter + vector[i];
    }

    //Declaramos variable para poder medir la longitud del vector
    var length = vector.Length;

    //Realizamos la operacion que nos dara la media del vector (longitud del vector entre la suma de los elementos)
    decimal result = length / (decimal)counter;

    return result; //Devolvemos la media del vector (ej. 24.3)

}