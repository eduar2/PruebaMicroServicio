using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using DAL.Models;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using BusinessApplication.Interfaces;
using BusinessApplication.Services;
using Core.Repositories;
using Microsoft.OpenApi.Models;
using Microsoft.Data.Sqlite;
using System.IO;
using Microsoft.EntityFrameworkCore.Metadata;
using Core.Domains;

namespace WebAPITest
{
    public static class Dependencias
    {
            
        // This method gets called by the runtime. Use this method to add services to the container.
        public static IServiceCollection ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            //var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = $"Data Source={sqlitePath}\\test.db" };
            //var connectionString = connectionStringBuilder.ToString();
            ////var sqlitePath = @"~\App_Data\test.db"; //System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)); System.IO.Directory.CreateDirectory(sqlitePath); var fileName = $"{sqlitePath}\\test.db"; if (!File.Exists(fileName)) File.Create(fileName);
            ////var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = $"Data Source={sqlitePath}" };
            ////var connectionString = connectionStringBuilder.ToString();
            //SqliteConnection connection = new SqliteConnection(connectionString);
            
            //optionsBuilder.UseSqlite(connection);

            services.AddControllers();

            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IEstadoCuentaRepository, EstadoCuentaRepository>();
            services.AddScoped<ICuentaService, CuentaService>();
            services.AddScoped<ICuentaRepository, CuentaRepository>();
            services.AddScoped<IPersonaRepository, PersonaRepository>();
            services.AddScoped<IPersonaService, PersonaService>();
            services.AddScoped<IMovimientoService, MovimientoService>();
            services.AddScoped<IMovimientoRepository, MovimientoRepository>();

            services.AddEntityFrameworkSqlServer()
                .AddDbContext<TestDBContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("TestDB")));
            //services.AddEntityFrameworkSqlite()
            //.AddDbContext<TestDBContext>(options =>
            //    options.UseSqlite(connection));


            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v0.1", new OpenApiInfo { Title = "WebApi Test", Version = "v0.1" });
            //});

            //services.AddDbContext<TestDBContext>(options =>
            //    options.UseSqlite(Configuration.GetConnectionString("DataBaseConnection")));
            return services;
        }

    }
}
