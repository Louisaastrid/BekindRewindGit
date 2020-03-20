using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using Dapper;
using System.Text;

namespace BeKindRewind
{
    public class CatalogRepository : IDisposable
    {

        private SqlConnection _db;
        private List<Category> _categories;
        public CatalogRepository(string connectionString)//ok
        {
            _db = new SqlConnection(connectionString);//ok
            _categories = new List<Category>();
            _categories.AddRange(_db.Query<Category>("SELECT category_id AS CategoryId,name, last_update As LastUpdate FROM Category "));//ok


        }
        public void Dispose()
        {
            _db.Close();
        }
        public IEnumerable<Category> Categories => _categories;

        //public IEnumerable<Category> FindCategoryByName(string search)
        //{
        //    return _db.Query<Category>("SELECT * FROM Category WHERE Name LIKE @Search", new { Search = search + '%' });
        //}
        public IEnumerable<Film> GetFilmByCategory(Category category)
        {
            var fields = new Dictionary<string, string>()
            {
                {"film_id"                   ,"FilmID" },
                {"title"                      ,null },
                {"release_year"              ,"ReleaseYear" },
                {"language_id"               ,"LanguageId" },
                {"original_language_id"      ,"OriginalLanguageId" },
                {"rental_duration"           ," RentalDuration" },
                {"length"                    ,null },
                {"replacement_cost"          ," ReplacementCost " },
                {"rating"                    ,null},
                {"special_features"          ," SpecialFeatures " },
                {"last_update"               ,"LastUpdate"},


            };

            var sbSelect = new StringBuilder();
            var sbGroupBy = new StringBuilder();
            var sep = "[film].[";
            foreach (var pair in fields)
            {
                sbGroupBy.Append(sep);
                sbGroupBy.Append(pair.Key);
                sbGroupBy.Append("]");

                sbSelect.Append(sep);
                sbSelect.Append(pair.Key);
                sbSelect.Append("]");

                if (pair.Value != null)
                {
                    sbSelect.Append("AS [");
                    sbSelect.Append(pair.Value);
                    sbSelect.Append("]");
                }
                sep = ",[film].[";
            }
            return _db.Query<Film>($@"
                 SELECT {sbSelect.ToString()}, COUNT(film_actor.actor_id) As ActorNum
                 FROM film 
                 INNER JOIN film_category ON film_category.film_id = film.film_id
                 INNER JOIN film_actor ON film_actor.film_id = film.film_id 
                 WHERE film_category.category_id = @CategoryID
                 GROUP BY {sbGroupBy.ToString()}",
                 category
            );

        }



    }
}
