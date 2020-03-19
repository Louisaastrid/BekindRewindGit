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
        public IEnumerable<Category> FindCategoryByName(string search)
        {
            return _db.Query<Category>("SELECT * FROM Category WHERE Name LIKE @Search", new { Search = search + '%' });
        }


    }
}
