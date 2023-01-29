using Business.Interfaces;
using Data.Context;
using Data.Repository;
using Microsoft.AspNetCore.Mvc.DataAnnotations;

namespace App.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            //Injeção de dependencia
            services.AddScoped<MeuDbContext>();
            services.AddScoped<IPessoaRepository, PessoaRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();

            return services;
        }

    }

}
