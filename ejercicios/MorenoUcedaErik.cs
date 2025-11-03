/*50. Piedra, Papel, Tijera (Mejor de Tres) Reutilizar las funciones del ejercicio anterior. 
El programa principal debe gestionar un bucle de "mejor de tres" para llevar la cuenta de las victorias del humano 
y la máquina (contadores simples). 
El juego termina cuando uno de los jugadores alcance dos victorias.*/

// Piedra=1 Papel= 2 y tijera=3 

const int contador; 
function int score(ref int cont bool res){
 if res=true()
 {
    cont+=1
 }   
 else
 {
    cont-=1
 }
 
}

function int jugar(){
    writeline("Bien vamos a jugar");
     int num = math.random()*4
return num;
}
function bool comprobarresultados(int j1 int j2){
  switch(j1)
  {
    //Resultados para J1 eligiendo piedra
    case 1:
        If(j1=j2)
        {
          Writeline("Empate")  
        }
        else
        {
          If(j2=3)
          {
            writeline("Has ganado :D")
            return true;
            break;
          }
          else
          {
            Writeline("Has perdido D:")
            return false;
            break;
          }             
        }
    //Resultados para J1 eligiendo papel 
    case 2:
        If(j1==j2)
        {
          Writeline("Empate")  
        }
        else
        {
          If(j2=1)
          {
            writeline("Has ganado :D")
            return true;
            break;
          }
          else
          {
            Writeline("Has perdido D:")
            return false;
            break;
          }        

    //Resultados para J1 eligiendo tijeras
    case 3: 
    If(j1=j2)
        {
          Writeline("Empate")  
        }
        else
        {
          If(j2=2)
          {
            writeline("Has ganado :D")
            return true;
            break;
          }
          else
          {
            Writeline("Has perdido D:")
            return false;
            break;
          }           
  }
}  

procedure menu (){
    int opc;   
do{
writeline("..........Bienvenido al piedra papel tijeras...........");
writeline("..Introduce el numero de la opcion que quieras elegir..");
writeline("....................1.Nueva partida ...................");
writeline(".......................2.Salir........................");
opcion=readline();
}
while (opc >2);

switch(opc)
{
case 1:
int manoj1 = jugar();
int manoj2 = jugar();
comprobarresultados(manoj1 manoj2);
break;
case 2:
break;
}

}

main{
 menu();

}


