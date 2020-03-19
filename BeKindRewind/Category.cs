using System;
using System.Collections.Generic;
using System.Text;
using Dapper;

namespace BeKindRewind
{
    public class Category
    {
        public int category_id { get; set; }
        public string name { get; set; }
        public DateTime last_update { get; set; }
        public Category() //requis par dapper 
        {
        
        }


    }
}
