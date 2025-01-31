using System;

class Program
{
    static void Main()
    {
        // Pobieranie liczby meczów od użytkownika
        Console.Write("Podaj liczbę meczów w sezonie: ");
        int numMatches = int.Parse(Console.ReadLine());

        int[] goals = new int[numMatches];

        // Pobieranie liczby strzelonych bramek w każdym meczu
        for (int i = 0; i < numMatches; i++)
        {
            Console.Write($"Podaj liczbę bramek w meczu {i + 1}: ");
            goals[i] = int.Parse(Console.ReadLine());
        }

        // Analiza wyników
        var stats = AnalyzeGoals(goals);

        Console.WriteLine("--------------------------------------------");
        Console.WriteLine($"Łączna liczba bramek: {stats.Item1}");
        Console.WriteLine($"Średnia liczba bramek na mecz: {stats.Item2:F2}");
        Console.WriteLine($"Najwyższy wynik w sezonie: {stats.Item3}");
    }

    static Tuple<int, double, int> AnalyzeGoals(int[] goals)
    {
        int totalGoals = 0;
        int maxGoals = 0;

        // Obliczanie sumy bramek i maksymalnej liczby bramek w jednym meczu
        for (int i = 0; i < goals.Length; i++)
        {
            totalGoals += goals[i];
            if (goals[i] > maxGoals)
            {
                maxGoals = goals[i];
            }
        }

        // Obliczanie średniej liczby bramek
        double averageGoals = (double)totalGoals / goals.Length;

        return Tuple.Create(totalGoals, averageGoals, maxGoals);
    }
}
