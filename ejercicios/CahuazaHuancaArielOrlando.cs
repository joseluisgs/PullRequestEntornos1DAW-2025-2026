void Main(string[] args)
{
    // Leer dimensión de la matriz
    Console.Write("Introduce la dimensión N de la matriz (N x N): ");
    int n = Convert.ToInt32(Console.ReadLine());

    int[][] matriz = new int[n][n];

    // Leer elementos de la matriz
    Console.WriteLine("Introduce los valores de la matriz:");

    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {

            Console.Write($"Elemento [i][j]:");
            matriz[i][j] = Convert.ToInt32(Console.ReadLine());
        }
    }

    int[] maximosFila = new int[n];
    int sumaMaximos = 0;

    // Calcular el máximo de cada fila
    for (int i = 0; i < n; i++)
    {
        int max = matriz[i][0];
        for (int j = 1; j < n; j++)
        {

            if (matriz[i][j] > max)
            {
                max = matriz[i][j];
            }
        }
        maximosFila[i] = max;
        sumaMaximos += max;
        Console.WriteLine($"Máximo de la fila {i + 1}: {max}");
    }

    // Calcular la media de los máximos por fila
    double media = (double)sumaMaximos / n;
    Console.WriteLine($"La media de los máximos de cada fila es: {media:F2}");
}
