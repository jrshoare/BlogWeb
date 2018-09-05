# BlogWeb

A simple ASP.NET Core MVC web application that can be used to serve Markdown formatted blog posts as HTML web pages.

Blogs are created using Markdown syntax and saved to the `/Posts` folder.

A YAML front matter block can be used to define a title and abstract for each blog post. This must be defined in the
first few lines of the blog post enclosed within `---` characters, for example:

```
---
title: Your title goes here
abstract: Your abstract goes here.
keywords: Keyword1, Keyword2, etc
categories: Category1, Category2, etc
postDate: 2018-09-04T16:24:17.0000000+01:00
---
# Your title repeated here

The rest of your blog post goes here.
```

If the `postDate:` keyword is present and defines a date that can be parsed to a .NET `DateTime` object then it is used
to report the date of the blog post. Otherwise, if the file is located in a sub-directory tree structure using the
convention `{yyyy}/{mm}/{dd}` then this date is used. If neither of these strategies succeed then the post date of the
blog assumes the minium value for a .NET `DateTime` object.

The application includes a simple search capability that performs a case-insensitive match for the supplied text against
the abstract, keywords and categories.

The project uses generic Markdown processing middleware installed as a
[NuGet package](https://www.nuget.org/packages/Westwind.AspNetCore.Markdown/) or obtainable as source from
[Westwind.AspNetCore.Markdown](https://github.com/RickStrahl/Westwind.AspNetCore/tree/master/Westwind.AspNetCore.Markdown) to re-route
any request for a file with a `.md` extension to a generic controller to read the contents and process to HTML using
[Markdig](https://github.com/lunet-io/markdig.git).

The resulting HTML is rendered within a View Template configured for the folder.

### License

The project is licensed under the MIT license.