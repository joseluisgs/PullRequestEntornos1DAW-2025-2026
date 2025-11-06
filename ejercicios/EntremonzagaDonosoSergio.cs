using Math;

procedure calcularPuntuacion (int[] arr1, int[] arr2, int a, int b)
{
    for (int i = 0; i < arr1.length; i + 1)
    {
        a = a + arr1[i];
        b = b + arr2[i];
    }
}
procedure ganador(int a, int b)
    {
        if (a > b)
        {
            writeLine("Gana tirador1");
        }
        else if (a < b)
        {
            writeLine("Gana tirador 2");
        }
        else
        {
            writeLine("Empate");
        }
    }
procedure diferenciaMax(int[] arr1, int[] arr2)
{
    int x;
    int y;
    int z;
    int a;
    for (int i = 0; i < arr1.Length; i + 1)
    {
        if (arr1[i] >= arr2[i])
        {
            y = arr1[i] - arr2[i];
            a = 1;
        }
        else
        {
            y = arr2[i] - arr1[i];
            a = 2;
        }
        if (x > y)
        {
            x = y;
            z = i;
        }
        writeLine("Mayor diferencia de" + x + "en la ronda" + (z + 1) + "a favor del jugador" + a);
    }
}

Main{
    var j1= int[10];
    var j2= int[10];
    int resultadoJ1;
    int resultadoJ2;
for (int i = 0; i < j1.length; i + 1)
{
    j1[i] = Math.random(0, 10);
    j2[i] = Math.random(0, 10);
}
calcularPuntuacion(j1, j2, out resultadoJ1, out resultadoJ2);
ganador(resultadoJ1, resultadoJ2);
diferenciaMax(j1, j2)
}