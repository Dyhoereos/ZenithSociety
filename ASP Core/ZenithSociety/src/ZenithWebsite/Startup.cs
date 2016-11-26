using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ZenithWebsite.Data;
using ZenithWebsite.Models;
using ZenithWebsite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.AspNetCore.Cors.Infrastructure;
using OpenIddict;
using CryptoHelper;

namespace ZenithWebsite
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            // Add framework services.
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            //var connection = Configuration["Data:DefaultConnection:ConnectionString"];
            //services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(connection));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Register the OpenIddict services, including the default Entity Framework stores.
            services.AddOpenIddict<ApplicationDbContext>()
                // Register the ASP.NET Core MVC binder used by OpenIddict.
                // Note: if you don't call this method, you won't be able to
                // bind OpenIdConnectRequest or OpenIdConnectResponse parameters.
                .AddMvcBinders()

                // Enable the token endpoint (required to use the password flow).
                .EnableAuthorizationEndpoint("/connect/authorize")
                .EnableTokenEndpoint("/connect/token")

                // Allow client applications to use the grant_type=password flow.
                .AllowPasswordFlow()
                .AllowAuthorizationCodeFlow()

                // During development, you can disable the HTTPS requirement.
                .DisableHttpsRequirement()

                // Register a new ephemeral key, that is discarded when the application
                // shuts down. Tokens signed using this key are automatically invalidated.
                // This method should only be used during development.
                .AddEphemeralSigningKey();

            services.AddMvc();
            var corsBuilder = new CorsPolicyBuilder();
            corsBuilder.AllowAnyHeader();
            corsBuilder.AllowAnyMethod();
            corsBuilder.AllowAnyOrigin();
            corsBuilder.AllowCredentials();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", corsBuilder.Build());
            });

            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IServiceProvider services, ApplicationDbContext context)
        {
            app.UseCors("AllowAll");

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }


            app.UseStaticFiles();
            app.UseIdentity();


            // Add external authentication middleware below. To configure them please see http://go.microsoft.com/fwlink/?LinkID=532715

            app.UseOAuthValidation();

            app.UseOpenIddict();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            using (var context1 = new ApplicationDbContext(
                app.ApplicationServices.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                context1.Database.EnsureCreated();

                if (!context1.Applications.Any())
                {
                    context1.Applications.Add(new OpenIddictApplication
                    {
                        // Assign a unique identifier to your client app:
                        Id = "48BF1BC3-CE01-4787-BBF2-0426EAD21342",

                        // Assign a display named used in the consent form page:
                        DisplayName = "MVC Core client application",

                        // Register the appropriate redirect_uri and post_logout_redirect_uri:
                        RedirectUri = "http://localhost:53507/signin-oidc",
                        LogoutRedirectUri = "http://localhost:53507/",

                        ClientSecret = Crypto.HashPassword("secret_secret_secret"),

                        // Note: use "public" for JS/mobile/desktop applications
                        // and "confidential" for server-side applications.
                        Type = OpenIddictConstants.ClientTypes.Confidential
                    });

                    context1.SaveChanges();
                }
            }

            Seed.Initialize(context, services);
        }
    }
}
