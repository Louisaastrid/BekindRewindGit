using System;
using System.Collections.Generic;
using System.Text;
using Dapper;

namespace BeKindRewind
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public DateTime LastUpdate { get; set; }
        public Category() //requis par dapper 
        {
        
        }


    }
}
