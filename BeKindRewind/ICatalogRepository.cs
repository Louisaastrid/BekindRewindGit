using System.Collections.Generic;
using System;

namespace BeKindRewind
{
    public interface ICatalogRepository : IDisposable
    {
        IEnumerable<Category> Categories { get; }

        IEnumerable<Film> GetFilmByCategory(Category category);
    }
}