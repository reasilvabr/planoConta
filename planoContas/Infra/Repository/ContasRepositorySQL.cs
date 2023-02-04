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
    public async Task CreateContaAsync(Conta conta)
    {
        _db.Contas.Add(conta);
        await _db.SaveChangesAsync();
    }

    public async Task UpdateContaAsync(Conta conta)
    {
        _db.Update(conta);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteContaAsync(CodigoConta codigoConta)
    {
        var conta = await _db.Contas.Where(c => c.CodigoConta == codigoConta).FirstAsync();
        _db.Remove(conta);
        try
        {
            await _db.SaveChangesAsync();
        }
        catch (DbUpdateException)
        {
            throw new InvalidOperationException("Conta não pode ter filhas.");
        }
    }

    public async Task<IEnumerable<Conta>> GetContasAsync()
    {
        return await _db.Contas.ToListAsync();
    }

    public async Task<IEnumerable<Conta>> GetContasPaiAsync()
    {
        return await _db.Contas.Where(c => !c.AceitaLancamento).ToListAsync();
    }

    public async Task<Conta> GetContaAsync(CodigoConta codigoConta)
    {
        return await _db.Contas.Where(c => c.CodigoConta == codigoConta).FirstAsync();
    }
}
