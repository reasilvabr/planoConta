﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlanoContas.Infra.Data;

#nullable disable

namespace planoContas.Migrations
{
    [DbContext(typeof(ContasContext))]
    partial class ContasContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PlanoContas.Domain.Conta.Entity.Conta", b =>
                {
                    b.Property<string>("CodigoConta")
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("AceitaLancamento")
                        .HasColumnType("bit");

                    b.Property<string>("CodigoContaPai")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.HasKey("CodigoConta");

                    b.HasIndex("CodigoContaPai");

                    b.ToTable("Contas");
                });

            modelBuilder.Entity("PlanoContas.Domain.Conta.Entity.Conta", b =>
                {
                    b.HasOne("PlanoContas.Domain.Conta.Entity.Conta", "ContaPai")
                        .WithMany()
                        .HasForeignKey("CodigoContaPai");

                    b.Navigation("ContaPai");
                });
#pragma warning restore 612, 618
        }
    }
}
