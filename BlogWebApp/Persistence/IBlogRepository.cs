﻿using BlogWebApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogWebApp.Persistence
{
    public interface IBlogRepository
    {
        /// <summary>
        /// Retrieves a collection of <see cref="BlogSnippet"/> items for the
        /// <paramref name="count"/> most recent blog posts.
        /// </summary>
        /// <param name="count">The number of items to include in the collection.</param>
        /// <returns>
        /// A collection containing <see cref="BlogSnippet"/> items for the
        /// <paramref name="count"/> most recent blog posts.
        /// </returns>
        Task<IEnumerable<BlogSnippet>> GetMostRecentAsync(int count = 10);
    }
}
