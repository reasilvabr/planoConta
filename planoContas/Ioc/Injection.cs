using MediatR;
using PlanoContas.Domain.Conta.Command;
using PlanoContas.Domain.Conta.Query;
using PlanoContas.Infra.Data;
using PlanoContas.Infra.Repository;

namespace PlanoContas.Ioc;

public static class Injection{
    public static IServiceCollection AddPlanoContasServices(this IServiceCollection services)
    {
        services.AddMediatR(
            typeof(ContaCreateCommand), 
            typeof(ContaUpdateCommand), 
            typeof(ContaDeleteCommand),
            typeof(ContaGetQuery));
        services.AddScoped<IContasRepository, ContasRepositorySQL>();
        services.AddSingleton<ContasContext>(
            new ContasContext(@"Server=127.0.0.1,1433\mssqllocaldb;Database=PlanoContas;User Id=sa;Password=ABcd_1234!;TrustServerCertificate=true;"));
        return services;
    }
}