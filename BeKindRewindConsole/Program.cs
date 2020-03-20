using BeKindRewind;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace BeKindRewindConsole
{
    class Program
    {
        const string basePath = @"C:\Users\astrid.rangba\Documents\BekindRewindGit\BekindRewindGit\BeKindRewind";
        static readonly string connectionStr = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={basePath}\data\sakila.mdf;Integrated Security=True;Connect Timeout=30";
        static void Main(string[] args)
        {
            //ConsoleKeyInfo choix;
            //do
            //{
            //    Console.WriteLine("1 - afficher la liste des catégories");
            //    Console.WriteLine("2 - Trouver une catégorie ");
            //    Console.WriteLine("3 - Film par catégorie ");
            //    Console.WriteLine("4 - Quitter ");
            //    Console.WriteLine("Votre choix : ");
            //    choix = Console.ReadKey();
            //    Console.WriteLine();
            //    int index = 0;
            //    switch (choix.KeyChar)
            //    {

            //        case '1':
            //            try
            //            {
            //                using (var CatalogRepo = new CatalogRepository(connectionStr))
            //                {

            //                    foreach (var category in CatalogRepo.Categories)
            //                    {
            //                        Console.WriteLine($"{++index}-{category.Name}, ({category.CategoryId})");
            //                    }
            //                }

            //            }
            //            catch (SqlException e)
            //            {
            //                Console.Error.WriteLine($"Database connection: {e.Message}");
            //            }
            //            break;

            //        case '2':
            //            {
            //                Console.Write("Votre recherche : ");
            //                var search = Console.ReadLine();
            //                using (var CatalogRepo = new CatalogRepository(connectionStr))
            //                {
            //                    var result = CatalogRepo.FindCategoryByName(search);
            //                    foreach (var category in result)
            //                    {

            //                        Console.WriteLine($"-Vous avez choisi {category.Name}");
            //                    }
            //                }

            //                break;
            //            }
            //        case '3':
            //            {

            //            }
            //            {
            //                Console.Write("Votre recherche : ");
            //                var search = Console.ReadLine();

            //                using (var CatalogRepo = new CatalogRepository(connectionStr))
            //                {
            //                    var result = CatalogRepo.GetFilmByCategory(search).Take(10);
            //                    foreach (var film in result)
            //                    {

            //                        Console.WriteLine($"{film.Title}");
            //                    }
            //                }

            //                break;
            //            }

            //        case '4':
            //            break;
            //        default:
            //            Console.Error.WriteLine($"Touche non gérée");
            //            break;


            //    }
            //} while (choix.KeyChar != '4');
            bool end = false;
            using (var catalogRepo = new CatalogRepository(connectionStr))
            {
                while (!end)
                {
                    int index = 0;
                    foreach (var category in catalogRepo.Categories)
                    {
                        Console.WriteLine($"{++index} - {category.Name}");
                    }

                    Console.WriteLine($"{++index} - Quitter");
                    Console.WriteLine("Votre choix : ");


                    var choix = Console.ReadLine();
                    int choixNum;
                    Console.WriteLine();

                    if (int.TryParse(choix, out choixNum))
                    {
                        if (choixNum == index)
                        {
                            end = true;
                        }else if( 1<=choixNum && choixNum < index){
                            var category = catalogRepo.Categories.ElementAt(choixNum - 1);
                            Console.WriteLine("Film de cette catégorie:");
                            foreach(var film in catalogRepo.GetFilmByCategory(category).Take(10))
                            {
                                Console.WriteLine($"- {film.Title} ({film.ActorNum})");
                            }
                        }
                    }else
                    {
                        Console.Error.WriteLine("Touche non gérée");
                    }

                }

            }

        }
    }
}
