using Microsoft.EntityFrameworkCore;
using PlanoContas.Domain.Conta.Entity;
using PlanoContas.Infra.Data;

namespace PlanoContas.Infra.Repository;

public class ContasRepositorySQL : IContasRepository
{
    private readonly ContasContext _db;
    public ContasRepositorySQL(ContasContext db)
    {
        _db = db;
    }
    public async Task CreateConta(Conta conta)
    {
        _db.Contas.Add(conta);
        await _db.SaveChangesAsync();
    }

    public async Task UpdateConta(Conta conta)
    {
        _db.Update(conta);
        await _db.SaveChangesAsync();

    }

    public async Task DeleteConta(CodigoConta codigoConta)
    {
        var conta = await _db.Contas.Where(c => c.CodigoConta == c.CodigoConta).FirstAsync();
        _db.Remove(conta);
        await _db.SaveChangesAsync();
    }

    public async Task<IEnumerable<Conta>> GetContas()
    {
        return await _db.Contas.ToListAsync();
    }

    public async Task<IEnumerable<Conta>> GetContasPai()
    {

        return await _db.Contas.Where(c => !c.AceitaLancamento).ToListAsync();

    }
}
