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
