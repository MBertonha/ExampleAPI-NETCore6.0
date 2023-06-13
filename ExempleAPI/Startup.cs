using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using ExempleAPI.Configuracoes;
using ExampleAPI.Infra.Database;
using Servico.Servicos;
using ExampleAPI.Servico.AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ExempleAPI.Configuracoes.Security;

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

            services.AddScoped<JwtTokenGenerator>(provider =>
            {
                var config = Configuration.GetSection("AppSettings");
                var secretKey = config.GetValue<string>("SecretKey");
                return new JwtTokenGenerator(secretKey);
            });
            #endregion

            #region TNF
            services.AddAutoMapperTnf();
            services.AddTnfEntityFrameworkCore();
            services.AddTnfDomain();
            #endregion

            #region Swagger
            services.AddSwaggerConfiguration(Configuration);
            #endregion

            #region Token JWT

            var config = Configuration.GetSection("AppSettings");
            var secretKey = config.GetValue<string>("SecretKey");
            var key = Encoding.ASCII.GetBytes(secretKey);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
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

            #region Token JWT
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                // Exemplo de proteção de um endpoint específico
                endpoints.MapGet("/api/secure", async context =>
                {
                    await context.Response.WriteAsync("Este é um endpoint protegido.");
                }).RequireAuthorization();
            });
            #endregion

            app.UseMvc();
        }

    }
}
