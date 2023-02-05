using Microsoft.EntityFrameworkCore;
using PlanoContas.Domain.Conta.Entity;
using PlanoContas.Infra.Data;

namespace PlanoContas.Infra.Repository;

public class ContasRepositorySQL : IContasRepository
{
    private readonly IDbContextFactory<ContasDBContext> _dbContextFactory;
    public ContasRepositorySQL(IDbContextFactory<ContasDBContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    public async Task CreateContaAsync(Conta conta)
    {
        using (var db = _dbContextFactory.CreateDbContext())
        {
            db.Contas.Add(conta);
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
    }

    public async Task UpdateContaAsync(Conta conta)
    {
        using (var db = _dbContextFactory.CreateDbContext())
        {
            db.Update(conta);
            await db.SaveChangesAsync();
        }
    }

    public async Task DeleteContaAsync(CodigoConta codigoConta)
    {
        using (var db = _dbContextFactory.CreateDbContext())
        {
            var conta = await db.Contas.Where(c => c.CodigoConta == codigoConta).FirstAsync();
            db.Remove(conta);
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
    }

    public async Task<IEnumerable<Conta>> GetContasAsync()
    {
        using (var db = _dbContextFactory.CreateDbContext())
        {
            return await db.Contas.ToListAsync();
        }
    }

    public async Task<IEnumerable<Conta>> GetContasPaiAsync()
    {
        using (var db = _dbContextFactory.CreateDbContext())
        {
            return await db.Contas.Where(c => c.AceitaLancamento == false).ToListAsync();
        }
    }

    public async Task<Conta> GetContaAsync(CodigoConta codigoConta)
    {
        using (var db = _dbContextFactory.CreateDbContext())
        {
            return await db.Contas.Where(c => c.CodigoConta == codigoConta).FirstAsync();
        }
    }
}
