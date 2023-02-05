using Microsoft.EntityFrameworkCore;
using PlanoContas.Domain.Conta.Entity;

namespace PlanoContas.Infra.Data;

public class ContasDBContext : DbContext
{

    public ContasDBContext(DbContextOptions<ContasDBContext> options): base(options)
    {
    }

    public DbSet<Conta> Contas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Conta>(conta =>
        {
            conta.Property(c => c.CodigoConta).HasConversion(c => c.ToString(), c => new CodigoConta(c));
            conta.Property(c => c.CodigoConta).HasColumnType("varchar(50)");
            conta.Property(c => c.CodigoContaPai).HasConversion(c => c.ToString(), c => new CodigoConta(c));
            conta.Property(c => c.CodigoContaPai).HasColumnType("varchar(50)");
            conta.HasKey(c => c.CodigoConta);
        });
        modelBuilder.Entity<Conta>()
            .HasOne<Conta>()
            .WithMany()
            .HasForeignKey(c => c.CodigoContaPai).OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<Conta>().Ignore(c => c.ContaPai);
    }
}