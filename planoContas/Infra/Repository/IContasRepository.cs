using PlanoContas.Domain.Conta.Entity;

namespace PlanoContas.Infra.Repository;
public interface IContasRepository
{
    Task<IEnumerable<Conta>> GetContas();
    Task<IEnumerable<Conta>> GetContasPai();
    Task<Conta> GetConta(CodigoConta codigoConta);
    Task CreateConta(Conta conta);
    Task UpdateConta(Conta conta);
    Task DeleteConta(CodigoConta codigoConta);

}