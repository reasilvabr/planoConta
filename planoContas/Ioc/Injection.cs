using MediatR;
using Microsoft.EntityFrameworkCore;
using PlanoContas.Domain.Conta.Command;
using PlanoContas.Domain.Conta.Query;
using PlanoContas.Infra.Data;
using PlanoContas.Infra.Repository;

namespace PlanoContas.Ioc;

public static class Injection{
    public static IServiceCollection AddPlanoContasServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(
            typeof(ContaCreateCommand), 
            typeof(ContaUpdateCommand), 
            typeof(ContaDeleteCommand),
            typeof(ContaGetQuery));
        services.AddScoped<IContasRepository, ContasRepositorySQL>();
        services.AddDbContextFactory<ContasDBContext>(options => options.UseSqlServer(configuration.GetConnectionString("Default")));
        return services;
    }
}