using BlogWebApp.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Westwind.AspNetCore.Markdown.Utilities;

namespace BlogWebApp.Persistence
{
    public class BlogRepository : IBlogRepository
    {
        public BlogRepository(IHostingEnvironment environment)
        {
            Environment = environment;
        }

        /// <summary>
        /// Retrieves a collection of <see cref="BlogSnippet"/> items for the
        /// <paramref name="count"/> most recent blog posts.
        /// </summary>
        /// <param name="count">The number of items to include in the collection.</param>
        /// <returns>
        /// A collection containing <see cref="BlogSnippet"/> items for the
        /// <paramref name="count"/> most recent blog posts.
        /// </returns>
        public async Task<IEnumerable<BlogSnippet>> GetMostRecentAsync(int count = 10)
        {
            IEnumerable<BlogSnippet> snippets = await RetrieveAllAsync();
            return snippets.OrderByDescending(s => s.PostedOn).Take(count);
        }

        /// <summary>
        /// Retrieves a collection of <see cref="BlogSnippet"/> items where the abstract,
        /// categories or keywords in the YAML front matter block contains the specified text.
        /// </summary>
        /// <param name="query">The text to be matched.</param>
        /// <param name="count">The number of items to include in the collection.</param>
        /// <returns>
        /// A collection containing <see cref="BlogSnippet"/> items for the
        /// <paramref name="count"/> blog posts matching the search term.
        /// </returns>
        public async Task<IEnumerable<BlogSnippet>> FindMatchingAsync(string query, int count = 10)
        {
            var lowerQuery = query.ToLowerInvariant();

            IEnumerable<BlogSnippet> snippets = await RetrieveAllAsync();
            return snippets
                .Where(s => s.Abstract.ToLowerInvariant().Contains(lowerQuery) ||
                    s.Categories.Where(c => c.ToLowerInvariant().Contains(lowerQuery)).Count() != 0 ||
                    s.Keywords.Where(k => k.ToLowerInvariant().Contains(lowerQuery)).Count() != 0)
                .Take(count);
        }

        /// <summary>
        /// Gets a collection containing <see cref="BlogSnippet"/> items for all blog posts.
        /// </summary>
        /// <returns>
        /// A collection containing <see cref="BlogSnippet"/> items for all blog posts.
        /// </returns>
        private async Task<IEnumerable<BlogSnippet>> RetrieveAllAsync()
        {
            var snippets = new List<BlogSnippet>();

            foreach (var path in GetAllPaths())
            {
                var snippet = new BlogSnippet
                {
                    Url = $"/{path.Substring(path.LastIndexOf("posts")).Replace("\\", "/")}"
                };

                string markdown = await File.ReadAllTextAsync(path);
                string[] firstLines = StringUtils.GetLines(markdown, 30); // Assume YAML front matter block is in first 30 lines

                if (markdown.StartsWith("---"))
                {
                    UpdateFromYamlFrontMatterBlock(snippet, firstLines);
                }

                if (string.IsNullOrEmpty(snippet.Title))
                {
                    foreach (var line in firstLines.Take(10))
                    {
                        if (line.TrimStart().StartsWith("# "))
                        {
                            snippet.Title = line.TrimStart(new char[] { ' ', '\t', '#' });
                            break;
                        }
                    }
                }

                if (snippet.PostedOn.Equals(DateTime.MinValue))
                {
                    snippet.PostedOn = GetPostDateFromPath(path);
                }

                snippets.Add(snippet);
            }

            return snippets;
        }

        /// <summary>
        /// Returns a collection containing the fully-qualified paths of all blog posts.
        /// </summary>
        /// <returns>
        /// A collection containing the fully-qualified paths of all blog posts.
        /// </returns>
        private IList<string> GetAllPaths()
        {
            var paths = new List<string>();
            var postsPath = Path.Combine(Environment.WebRootPath, "posts");

            var enumerationOptions = new EnumerationOptions
            {
                RecurseSubdirectories = true,
                IgnoreInaccessible = true
            };

            foreach (var folderPath in Directory.EnumerateDirectories(postsPath, "*", enumerationOptions))
            {
                foreach (var filePath in Directory.GetFiles(folderPath))
                {
                    if (Path.GetExtension(filePath) == ".md")
                    {
                        paths.Add(filePath);
                    }
                }
            }

            return paths;
        }

        /// <summary>
        /// Attempts to update the content of the supplied <see cref="BlogSnippet"/> from
        /// a YAML front matter block in the supplied array of lines.
        /// </summary>
        /// <param name="snippet">The <see cref="BlogSnippet"/> to be updated.</param>
        /// <param name="lines">An array of lines possibly containing a YAML front matter block.</param>
        private void UpdateFromYamlFrontMatterBlock(BlogSnippet snippet, string[] lines)
        {
            var linesText = string.Join("\n", lines);
            var yaml = StringUtils.ExtractString(linesText, "---", "---", returnDelimiters: true);
            if (yaml != null)
            {
                snippet.Title = StringUtils.ExtractString(yaml, "title: ", "\n");
                snippet.Abstract = StringUtils.ExtractString(yaml, "abstract: ", "\n");
                snippet.Categories = StringUtils.ExtractString(yaml, "categories: ", "\n")
                        .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                snippet.Keywords = StringUtils.ExtractString(yaml, "keywords: ", "\n")
                        .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (DateTime.TryParse(StringUtils.ExtractString(yaml, "postDate: ", "\n"), out DateTime postedOn))
                {
                    snippet.PostedOn = postedOn;
                }
            }
        }

        /// <summary>
        /// Attempts to get the post date of a blog from the file path.
        /// </summary>
        /// <param name="path">The fully-qualified path to the blog post file.</param>
        /// <returns>A <see cref="DateTime"/> for the post date of the blog.</returns>
        /// <remarks>
        /// Assumes a path ending with /{yyyy}/{mm}/{dd}/'file-name'. If no date can be
        /// parsed from the path then the minimum value for <see cref="DateTime"/> is returned.
        /// </remarks>
        private DateTime GetPostDateFromPath(string path)
        {
            var segments = Path.GetDirectoryName(path).Split(Path.DirectorySeparatorChar).TakeLast(3).ToArray();
            if (segments.Length == 3)
            {
                if (DateTime.TryParse($"{segments[0]}/{segments[1]}/{segments[2]}", out DateTime postDate))
                {
                    return postDate;
                }
            }

            return DateTime.MinValue;
        }

        private IHostingEnvironment Environment { get; set; }
    }
}
