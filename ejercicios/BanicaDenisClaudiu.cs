using Math;

function bool esPrimo (int a){

                if (a <= 1) { // 0 y 1 no son primos

                return false;

                }

                int limite = (int)Math.sqrt(a);

                for (int i = 2; i <= limite, i = i + 1){ // Bucle que se repite hasta que i no sea menor o igual que la raíz cuadrada del numero que use la función.

                               if (a % i == 0){ // el módulo de a entre el iterador es 0, nuestro numero tiene un divisor que no es el mismo ni 1, por lo tanto no es primo

                                            return false;

                               }

                }

return true; // cualquier numero que pase por el for sin devolver falso es un primo

}

Main{

          writeLine(“Dame un número y te diré si es primo”);

          int num = (int)readLine();

          bool esPrimoResultado = esPrimo(num);

          if(esPrimoResultado == true){

                writeLine(“Tu número es primo”);

          }else{

                writeLine(“Tu número no es primo”);

          }

}

