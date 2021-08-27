using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RestWithASPNET.Model.Context;
using RestWithASPNET.Business;
using RestWithASPNET.Business.Implementations;
using System;
using RestWithASPNET.Repository;
using Serilog;
using System.Collections.Generic;
using RestWithASPNET.Repository.Generic;
using Microsoft.Net.Http.Headers;
using RestWithASPNET.Hypermedia.Filters;
using RestWithASPNET.Hypermedia.Enricher;

namespace RestWithASPNET {
    public class Startup {

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }
        public Startup(IConfiguration configuration, IWebHostEnvironment environment) {
            Configuration = configuration;
            Environment = environment;

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {

            services.AddControllers();

            // Conexão com o banco
            var connection = Configuration["MySQLConnection:MySQLConnectionString"];
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 25));
            services.AddDbContext<MySQLContext>(options => options.UseMySql(connection, serverVersion));

            if (Environment.IsDevelopment()) {
                MigrationDatabse(connection);
            }

            services.AddMvc(options => {
                options.RespectBrowserAcceptHeader = true;

                options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("aplication/xml"));
                options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("aplication/json"));
            }).AddXmlSerializerFormatters();

            var filterOptions = new HyperMediaFilterOptions();
            filterOptions.ContentResponseEnricherList.Add(new PersonEnricher());
            filterOptions.ContentResponseEnricherList.Add(new BooksEnricher());

            services.AddSingleton(filterOptions);

            // Versionamento da API
            services.AddApiVersioning();

            // Injeção de dependências
            services.AddScoped<IPersonBusiness, PersonBusinessImplementation>();
            services.AddScoped<IBooksBusiness, BooksBusinessImplementation>();

            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
                endpoints.MapControllerRoute("DefaultApi", "{controller=values}/{id}");
            });
        }
        private void MigrationDatabse(string connection) {
            try
            {
                var evolveConnection = new MySql.Data.MySqlClient.MySqlConnection(connection);
                var evolve = new Evolve.Evolve(evolveConnection, msg => Log.Information(msg)) {
                    Locations = new List<String> { "db/migrations", "db/dataset" },
                    IsEraseDisabled = true,
                };
                evolve.Migrate();
            } 
            catch (Exception ex)
            {
                Log.Error("Database migration failed", ex);
                throw;
            }
        }
    }
}
