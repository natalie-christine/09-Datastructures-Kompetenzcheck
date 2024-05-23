
/*Aufgabe: Bibliothek
Du bist Bibliothekar und möchtest deine Bücher und Autoren verwalten. Du möchtest eine Liste aller Autoren erstellen. Diese Liste soll nicht nur den Name des Autors beinhalten, 
sondern auch jene Bücher, die in der Bibliothek geführt werden. Ein Titel darf max. 1 Mal pro Autor vorkommen. Dein Programm soll folgendes ermöglichen:

Liste aller Autoren ausgeben
Liste aller Bücher eines bestimmten Autors ausgeben
Suche den Autor eines bestimmten Titels
Liste alle Titeln, welche in der Bibliothek verfügbar sind, inkl. Autor im Format: 'Die Verwandlung' von 'Franz Kafka'
*/

using System.Runtime.CompilerServices;

namespace at.Schoefecker
{
    public class Program
    {
          private static IDictionary<string, List<Book>> authors = new Dictionary<string, List<Book>>()
            {
               { "Haruki Murakami", new List<Book> {
            new Book("Kafka am Strand", true),
            new Book("Naokos Lächeln", false),
            new Book("Mister Aufziehvogel", true)
        }},
        { "Jane Austen", new List<Book> {
            new Book("Stolz und Vorurteil", true),
            new Book("Emma", false),
            new Book("Verstand und Gefühl", true),
            new Book("Northanger Abbey", false)
        }},
        { "George Orwell", new List<Book> {
            new Book("1984", true),
            new Book("Farm der Tiere", false),
            new Book("Erledigt in Paris und London", true),
            new Book("Eine kleine Anleitung zum Töten", false)
        }},
        { "J.K. Rowling", new List<Book> {
            new Book("Harry Potter und der Stein der Weisen", true),
            new Book("Harry Potter und die Kammer des Schreckens", false),
            new Book("Harry Potter und der Gefangene von Askaban", true),
            new Book("Harry Potter und der Feuerkelch", false)
        }},
        { "Stephen King", new List<Book> {
            new Book("Es", true),
            new Book("Shining", false),
            new Book("Der dunkle Turm", true),
            new Book("Carrie", false)
        }},
        { "Franz Kafka", new List<Book> {
            new Book("Die Verwandlung", true),
            new Book("Der Prozess", false)
        }}
    };
             public static void Main(string[] args)
        {


            bool play = true;

            do
            {

                string[,] choices = {
                    //{ IDX, choice,}
                    {"0", "Liste aller Autoren ausgeben"},
                    {"1", "Liste aller Bücher eines bestimmten Autors ausgeben"},
                    {"2", "Suche den Autor eines bestimmten Titels"},
                    {"3", "Liste alle Titeln, welche in der Bibliothek verfügbar sind"},
                    {"4", " "},
                    {"5", "Exit"},

            };

                PrintTable(choices);
                int userInput = Convert.ToInt32(Console.ReadLine());


                switch (userInput)
                {

                    case 0:
                        Console.WriteLine("Hier wird eine Liste aller Autoren angezeigt");
                        ShowAutors();
                        break;

                    case 1:
                        Console.WriteLine("Hier wird eine Liste aller Bücher eines Autors");
                        ShowBooksFromAuthors();
                        break;
                    case 2:
                        Console.WriteLine("Suche den Autor eines bestimmten Titels");
                        ShowTitelFromAuthors();
                        break;

                    case 3:
                        Console.WriteLine("Hier kannst du alle verfügbaren Bücher sehen");
                        ShowAvailableBooks();
                        break;


                    case 4:
                        Console.WriteLine(". . . . .");
                        break;

                    case 5:
                        Console.WriteLine("Auf Wiedersehen! ");
                        play = false;
                        break;

                    default:

                        Console.WriteLine("Ungültige Eingabe");
                        break;


                }

            } while (play);
        }

        private static void PrintTable(String[,] choices)
        {

            Console.WriteLine("Was möchtest du tun?");

            for (int i = 0; i < choices.GetLength(0); i++)
            {
                Console.WriteLine($"{choices[i, 0]} {choices[i, 1]}");


            }
        }

        private static void ShowAutors()
        {
            foreach (var author in authors.Keys)
            {
                Console.WriteLine(author);
            }

        }


        private static void ShowBooksFromAuthors()
        {
            Console.WriteLine("Bitte geben Sie den Namen des Autors ein:");
            string authorName = Console.ReadLine() ?? "";

            if (authors.ContainsKey(authorName))
            {
                foreach (var book in authors[authorName])
                {
                    Console.WriteLine($"{book.Title} (verfügbar: {(book.IsAvailable ? "Ja" : "Nein")})");
                }
            }
            else
            {
                Console.WriteLine("Dieser Autor ist nicht in der Liste.");
            }

        }

        private static void ShowAvailableBooks()
        {
            foreach (var author in authors)
            {
                foreach (var book in author.Value)
                {
                    if (book.IsAvailable)
                    {
                        Console.WriteLine($"{book.Title} von {author.Key}");
                    }
                }
            }
        }

        private static void ShowTitelFromAuthors()
        {
            Console.WriteLine("Bitte geben Sie den Titel des Buches ein:");
            string bookTitle = Console.ReadLine() ?? "" ;

            foreach (var author in authors)
            {
                foreach (var book in author.Value)
                {
                    if (book.Title.Equals(bookTitle, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine($"Der Autor von \"{bookTitle}\" ist {author.Key}.");
                        return;
                    }
                }
            }

            Console.WriteLine("Dieses Buch ist nicht in der Liste.");
        }

    }
}










