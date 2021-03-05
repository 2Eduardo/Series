using System;

namespace Series
{
    class Program
    {
        static SerieRepository repository = new SerieRepository();
        static void Main(string[] args)
        {
            string userOption = "";

            while ((userOption = UserOption().ToUpper()) != "X")
            {
                switch (userOption)
                {
                    case "1":
                        repository.ReadAll();
                        break;
                    case "2":
                        repository.Create(UserOptionInsert());
                        break;
                    case "3":
                        repository.Update(UserOptionFind(), UserOptionUpdate());
                        break;
                    case "4":
                        repository.Delete(UserOptionFind());
                        break;
                    case "5":
                        repository.ReadByID(UserOptionFind());
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentException("Invalid command!");
                }
            }
        }
        private static string UserOption()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Séries!!!");
            Console.WriteLine("Choose the desired option");

            Console.WriteLine("1 - Get all series");
            Console.WriteLine("2 - Insert new serie");
            Console.WriteLine("3 - Update serie");
            Console.WriteLine("4 - Delete serie");
            Console.WriteLine("5 - Find serie");
            Console.WriteLine("C - Clear the console");
            Console.WriteLine("X - Exit");
            Console.WriteLine();

            string option = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return option;
        }

        private static Serie UserOptionInsert()
        {
            Serie newSerie = null;
            int genreNumber = 0;
            int year = 0;
            string title = "";
            string desc = "";

            Console.WriteLine("Create a new serie");
            foreach (int item in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine("{0}-{1}", item, Enum.GetName(typeof(Genre), item));
            }
            Console.Write("Type the genre: ");
            genreNumber = int.Parse(Console.ReadLine());

            Console.Write("Write the title: ");
            title = Console.ReadLine();

            Console.Write("Write the year of begin: ");
            year = int.Parse(Console.ReadLine());

            Console.Write("Write a description: ");
            desc = Console.ReadLine();

            newSerie = new Serie(id: repository.NextID(),
                                       genre: (Genre)genreNumber,
                                       title: title,
                                       year: year,
                                       description: desc);

            return newSerie;
        }

        public static Serie UserOptionUpdate()
        {
            Serie updtSerie = null;
            updtSerie = UserOptionInsert();
            return updtSerie;
        }

        public static int UserOptionFind()
        {
            int id = 0;
            Console.Write("Type the ID: ");
            id = int.Parse(Console.ReadLine());
            return id;
        }
    }
}
