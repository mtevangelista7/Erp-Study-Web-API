using ErpStudyWebAPI.Models;
using ErpStudyWebAPI.Models.DTOs;
using ErpStudyWebAPI.Repository;
using ErpStudyWebAPI.Repository.CategoriaRepo;
using ErpStudyWebAPI.Repository.ProdutoRepo;
using ErpStudyWebAPI.Repository.UsuarioRepo;
using ErpStudyWebAPI.Services;
using ErpStudyWebAPI.Services.AuthServices;
using ErpStudyWebAPI.Services.CategoriaServices;
using ErpStudyWebAPI.Services.ProdutoServices;
using ErpStudyWebAPI.Utilities;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpStudyWebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Aqui definimos nossas configurações de banco
            string dbHost = Environment.GetEnvironmentVariable("DB_HOST");
            string dbName = Environment.GetEnvironmentVariable("DB_NAME");
            string dbUser = Environment.GetEnvironmentVariable("DB_USER");
            string dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
            Util.StringConexao =
                $"Server={dbHost};Database={dbName};User ID={dbUser};Password={dbPassword};Trusted_Connection=False; TrustServerCertificate=True;";

            // Aqui definimos nossas configurações do swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new Microsoft.OpenApi.Models.OpenApiInfo { Title = "ErpStudyWebAPI", Version = "v1" });
                
                // Aqui é onde definimos a documentação que permite ao usuário, enviar o token bearer para o endpoint 
                c.AddSecurityDefinition("Bearer",
                    new OpenApiSecurityScheme
                    {
                        In = ParameterLocation.Header,
                        Description = "Por favor, digite um token válido",
                        Name = "Authorization",
                        Type = SecuritySchemeType.ApiKey,
                        BearerFormat = "JWT",
                        Scheme = "Bearer"
                    });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                        },
                        new string[] { }
                    }
                });

                string directory = AppDomain.CurrentDomain.BaseDirectory;
                string filePath = Path.Combine(directory, "ErpStudyWebAPI.xml");
                c.IncludeXmlComments(filePath);
            });

            // Aqui definimos como irá funcionar nossa autenticação com o JWT
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = false; // TODO verificar como isso funciona
                
                // Setamos nossas opções de validação do token
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    // Aqui definimos onde e como deve ser nossa chave de criptografia (igual ao método que cria token)
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII
                        .GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            // Aqui definimos as configurações para a interface de cache
            services.AddMemoryCache();
            
            // fluent validation
            services.AddScoped<IValidator<Categoria>, CategoriaValidator>();
            services.AddScoped<IValidator<Produto>, ProdutoValidator>();
            services.AddScoped<IValidator<UsuarioCadastroDto>, UsuarioCadastroDTOValidator>();

            // Repository
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            // Services
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IAuthService, AuthService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = string.Empty;
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ErpStudyWebAPI v1");
            });
        }
    }
}