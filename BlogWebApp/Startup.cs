using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Westwind.AspNetCore.Markdown;

namespace BlogWebApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMarkdown(config =>
            {
                // Note the required use of the trailing '/' in the path, e.g. '/posts/'
                var folderConfig = config.AddMarkdownProcessingFolder("/posts/", "~/Views/__MarkdownViewTemplate.cshtml");
                folderConfig.ProcessExtensionlessUrls = false;  // Disable default behaviour to process extension-less URLs
                folderConfig.ProcessMdFiles = true; // Force processing of .md files for this folder (default: true)
            });

            // The Markdown middleware requires the use of MVC to use a Razor configuration template
            services.AddMvc(options =>
            {
                // Let's preserve the memory of Sir Terry Pratchett
                options.Filters.Add(new XClacksOverheadAttribute());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseMarkdown();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}
