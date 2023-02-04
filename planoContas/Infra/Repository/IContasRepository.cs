using PlanoContas.Domain.Conta.Entity;

namespace PlanoContas.Infra.Repository;
public interface IContasRepository
{
    Task<IEnumerable<Conta>> GetContasAsync();
    Task<IEnumerable<Conta>> GetContasPaiAsync();
    Task<Conta> GetContaAsync(CodigoConta codigoConta);
    Task CreateContaAsync(Conta conta);
    Task UpdateContaAsync(Conta conta);
    Task DeleteContaAsync(CodigoConta codigoConta);

}