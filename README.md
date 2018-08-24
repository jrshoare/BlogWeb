# BlogWeb

A simple ASP.NET Core MVC web application that can be used to serve Markdown formatted blog posts as HTML web pages.

Blogs are created using Markdown syntax and saved to the `/Posts` folder.

The project uses generic Markdown processing middleware installed as a
[NuGet package](https://www.nuget.org/packages/Westwind.AspNetCore.Markdown/) or obtainable as source from
[Westwind.AspNetCore.Markdown](https://github.com/RickStrahl/Westwind.AspNetCore/tree/master/Westwind.AspNetCore.Markdown) to re-route
any request for a file with a `.md` extension to a generic controller to read the contents and process to HTML using
[Markdig](https://github.com/lunet-io/markdig.git).

The resulting HTML is rendered within a View Template configured for the folder.

### License

The project is licensed under the MIT license.