using BeKindRewind;
using System;
using System.Data.SqlClient;

namespace BeKindRewindConsole
{
    class Program
    {
        const string basePath = @"C:\Users\astrid.rangba\Documents\BekindRewindGit\BekindRewindGit\BeKindRewind";
        static readonly string connectionStr = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={basePath}\data\sakila.mdf;Integrated Security=True;Connect Timeout=30";
        static void Main(string[] args)
        {
            ConsoleKeyInfo choix;
            do
            {
                Console.WriteLine("1 - afficher la liste des catégories");
                Console.WriteLine("2 - Trouver une catégorie ");
                Console.WriteLine("3 - Quitter ");
                Console.WriteLine("Votre choix : ");
                choix = Console.ReadKey();
                Console.WriteLine();
                switch (choix.KeyChar)
                {
                    case '1':
                        try
                        {
                            using (var CatalogRepo = new CatalogRepository(connectionStr))
                            {
                                int index=0;
                                foreach (var category in CatalogRepo.Categories)
                                {
                                    Console.WriteLine($"{++index}-{category.Name}, ({category.CategoryId})");
                                }
                            }

                        }
                        catch (SqlException e)
                        {
                            Console.Error.WriteLine($"Database connection: {e.Message}");
                        }
                        break;
                    case '2':
                        {
                            Console.Write("Votre recherche : ");
                            var search = Console.ReadLine();
                            using (var CatalogRepo = new CatalogRepository(connectionStr))
                            {
                                var result = CatalogRepo.FindCategoryByName(search);
                                foreach (var category in result)
                                {

                                    Console.WriteLine($"-{category.Name}");
                                }
                            }

                            break;
                        }

                    case '3':
                        break;
                    default:
                        Console.Error.WriteLine($"Touche non gérée");
                        break;


                }
            } while (choix.KeyChar != '3');

        }
    }
}
