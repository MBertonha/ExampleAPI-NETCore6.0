using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using ExempleAPI.Configuracoes;
using ExampleAPI.Infra.Database;
using Servico.Servicos;
using ExampleAPI.Servico.AutoMapper;


namespace ExempleAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            BancoDadosConfig = new DataBaseConfig(configuration);
        }

        public IConfiguration Configuration { get; }
        public DataBaseConfig BancoDadosConfig { get; set; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(o => o.EnableEndpointRouting = false)
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddNewtonsoftJson();

            #region CORS
            services.AddCors();
            #endregion

            #region Versionamento
            services.AddVersionamentoConfiguration();
            #endregion

            #region Banco Dados
            services.AddEfCoreSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            #endregion

            #region Memory Cache
            services.AddMemoryCache();
            #endregion

            #region Classes
            services.AddServicosConfiguracao();
            #endregion

            #region TNF
            services.AddAutoMapperTnf();
            services.AddTnfEntityFrameworkCore();
            services.AddTnfDomain();
            #endregion

            #region Swagger
            services.AddSwaggerConfiguration(Configuration);
            #endregion

            #region Token
            #endregion

            return services.BuildServiceProvider(false);

        }

        /*Conexão com Sql Server*/
        public void Configure(IApplicationBuilder app, IHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwaggerConfiguration(provider);

            app.UseRouting();

            #region CORS
            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });
            #endregion

            app.UseAuthorization();

            app.UseMvc();
        }

    }
}
