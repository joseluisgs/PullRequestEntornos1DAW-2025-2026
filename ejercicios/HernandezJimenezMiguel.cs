/*
Trasponer una matriz consiste en intercambiar sus filas por sus columnas.
La primera fila pasa a ser la primera columna, 
la segunda fila la segunda columna... Así, la matriz
    ( 1 0 3 )                                       ( 1 2 2 )
    ( 2 9 0 )     se convierte al trasponerla en    ( 0 9 8 )
    ( 2 8 1 )                                       ( 3 0 1 )  .

El siguiente programa se centra en la lógica de la operación de trasposición.
No devuelve la matriz traspuesta por pantalla, solo hace una llamada a la función
y la retorna internamente.
*/

function int[][] trasponerMatriz ( int[][] matriz){

	int filas = matriz.Length;

  int columnas = matriz[0].Length;

	 //Inicializar el jagged array de filas PERO con las dimensiones INVERTIDAS
  int[][] matrizTraspuesta = int[columnas][]; //El nuevo número de filas es al antiguo número de columnas

  //Inicializar el array interno
	for (int i = 0; i < columnas; i++) {
	
	  matrizTraspuesta[i] = int[filas]; //El número de elementos de cada fila no serán las columnas sino las FILAS
		
	} 

  //Recorrer la matriz original por filas (primer for) y columnas (segundo for ) para asignar sus valores a la traspuesta
	for (int i = 0; i < filas; i++){
	
		for (int j = 0; j < columnas; j++){
		
		traspuestaMatriz[j][i] = matriz[i][j]; // Es la lógica principal del problema formalizada: los índices se intercambian
		
		}
	
	}
	
	return traspuestaMatriz;

}	

Main{

int[][] A = int[][] { {0,1,1}, {1,1,0} };

trasponerMatriz(A); //Para mostrar la matriz por pantalla necesitaría una nueva función imprimirMatriz

}
