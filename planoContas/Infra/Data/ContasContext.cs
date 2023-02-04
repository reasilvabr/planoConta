using Microsoft.EntityFrameworkCore;
using PlanoContas.Domain.Conta.Entity;

namespace PlanoContas.Infra.Data;

public class ContasContext : DbContext
{

    public ContasContext(string connectionString)
    {
        ConnectionString = connectionString;
    }

    string ConnectionString { get; set; }

    public DbSet<Conta> Contas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConnectionString);
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
            .HasOne(c => c.ContaPai)
            .WithMany()
            .HasForeignKey(c => c.CodigoContaPai).OnDelete(DeleteBehavior.NoAction);
    }
}