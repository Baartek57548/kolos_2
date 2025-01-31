using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Pobieranie ciągu znaków od użytkownika
        Console.Write("Wprowadź ciąg znaków: ");
        string input = Console.ReadLine();

        // Znalezienie najdłuższego podciągu unikalnych znaków
        var result = FindLongestUniqueSubstring(input);
        Console.WriteLine("---------------------------------------------------");
        Console.WriteLine($"Najdłuższy podciąg: {result.Item1} - {result.Item2}");
    }

    static Tuple<string, int> FindLongestUniqueSubstring(string s)
    {
        int maxLength = 0; // Długość najdłuższego znalezionego podciągu
        int start = 0; // Początek aktualnego podciągu
        int bestStart = 0; // Początek najlepszego podciągu
        HashSet<char> seen = new HashSet<char>(); // Zbiór unikalnych znaków w aktualnym podciągu

        // Przechodzenie przez ciąg znaków
        for (int end = 0; end < s.Length; end++)
        {
            // Jeśli napotkany znak już wystąpił, przesuwamy początek podciągu
            while (seen.Contains(s[end]))
            {
                seen.Remove(s[start]); // Usunięcie znaku z początku
                start++; // Przesunięcie początku podciągu w prawo
            }

            // Dodanie nowego znaku do zbioru
            seen.Add(s[end]);

            // Aktualizacja najdłuższego podciągu, jeśli jest dłuższy od poprzedniego
            if (end - start + 1 > maxLength)
            {
                maxLength = end - start + 1;
                bestStart = start;
            }
        }

        // Pobranie najdłuższego podciągu
        string longestSubstring = s.Substring(bestStart, maxLength);
        return Tuple.Create(longestSubstring, maxLength);
    }
}