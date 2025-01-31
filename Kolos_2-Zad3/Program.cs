using System;
using System.Collections.Generic;

class GuestBookApp
{
    static void Main()
    {
        WelcomeMessage();
        var (guests, totalGuests) = GetAllGuests();
        DisplayGuests(guests);
        DisplayGuestCount(totalGuests);
    }

    static void WelcomeMessage()
    {
        Console.WriteLine("Witamy w Księdze Gości");
        Console.WriteLine("***************************");
    }

    static string GetPartyName()
    {
        Console.Write("Podaj nazwisko rodziny/grupy: ");
        return Console.ReadLine().Trim();
    }

    static int GetPartySize()
    {
        int size;
        while (true)
        {
            Console.Write("Ile osób jest w Twojej grupie: ");
            if (int.TryParse(Console.ReadLine(), out size) && size > 0)
                return size;
            Console.WriteLine("Nieprawidłowe dane. Wprowadź poprawną liczbę osób.");
        }
    }

    static bool AskToContinue()
    {
        Console.Write("Czy są jeszcze goście do dodania? (tak/nie): ");
        string response = Console.ReadLine().Trim().ToLower();
        return response == "tak";
    }

    static (List<string>, int) GetAllGuests()
    {
        List<string> guests = new List<string>();
        int totalGuests = 0;

        do
        {
            string name = GetPartyName();
            int size = GetPartySize();
            guests.Add(name);
            totalGuests += size;
        } while (AskToContinue());

        return (guests, totalGuests);
    }

    static void DisplayGuests(List<string> guests)
    {
        Console.WriteLine("----------------------------------------------------------");
        Console.WriteLine("Lista Gości:");
        for (int i = 0; i < guests.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {guests[i]}");
        }
        Console.WriteLine("Dziękujemy wszystkich za przybycie.");
    }

    static void DisplayGuestCount(int totalGuests)
    {
        Console.WriteLine($"Łączna liczba gości podczas dzisiejszego wieczoru: {totalGuests}.");
    }
}
