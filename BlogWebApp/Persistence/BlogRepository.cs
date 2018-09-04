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

        public async Task<IEnumerable<BlogSnippet>> GetMostRecentAsync(int count = 10)
        {
            var snippets = new List<BlogSnippet>();
            var blogPosts = new SortedList<DateTime, string>(new ReverseDateTimeComparer());

            var contentRootPath = Environment.WebRootPath;
            var postsPath = Path.Combine(contentRootPath, "posts");

            var enumerationOptions = new EnumerationOptions
            {
                RecurseSubdirectories = true,
                IgnoreInaccessible = true
            };

            foreach (var folderPath in Directory.EnumerateDirectories(postsPath, "*", enumerationOptions))
            {
                // Assume folder structure of posts/{yyyy}/{mm}/{dd}
                var segments = folderPath.Split(Path.DirectorySeparatorChar).TakeLast(3).ToArray();
                if (segments.Length == 3)
                {
                    if (DateTime.TryParse(string.Format("{0}/{1}/{2}", segments[0], segments[1], segments[2]), out DateTime postDate))
                    {
                        foreach (var filePath in Directory.GetFiles(folderPath))
                        {
                            if (Path.GetExtension(filePath) == ".md")
                            {
                                blogPosts.Add(postDate, filePath);
                            }
                        }
                    }
                }
            }

            foreach (var blogPost in blogPosts.Take(count))
            {
                var postedOn = blogPost.Key;
                var snippet = new BlogSnippet
                {
                    PostedOn = postedOn,
                    Url = blogPost.Value.Substring(blogPost.Value.LastIndexOf("posts")).Replace("\\", "/")
                };

                string markdown = await File.ReadAllTextAsync(blogPost.Value);
                string[] firstLines = StringUtils.GetLines(markdown, 30); // Assume YAML front matter block is in first 30 lines
                var firstLinesText = string.Join("\n", firstLines);

                if (markdown.StartsWith("---"))
                {
                    var yaml = StringUtils.ExtractString(firstLinesText, "---", "---", returnDelimiters: true);
                    if (yaml != null)
                    {
                        snippet.Title = StringUtils.ExtractString(yaml, "title: ", "\n");
                        snippet.Abstract = StringUtils.ExtractString(yaml, "abstract: ", "\n");
                    }
                }

                if (snippet.Title == null)
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

                snippets.Add(snippet);
            }

            return snippets;
        }

        private IHostingEnvironment Environment { get; set; }

        private class ReverseDateTimeComparer : Comparer<DateTime>
        {
            public override int Compare(DateTime x, DateTime y)
            {
                return y.CompareTo(x);
            }
        }
    }
}
