using System.Collections.Generic;
using System.Linq;
using PlanoContas.Domain.Conta.Adapter;
using PlanoContas.Domain.Conta.Entity;
using Xunit;

namespace PlanoContas.test;

public class CodigoContaAdapterUnitTest
{
    public IEnumerable<Conta> ContasParaTeste
    {
        get
        {
            string[] contas = {
                "1",
                "1.1",
                "2",
                "2.1",
                "2.1.1",
                "2.2",
                "3"};
            return contas.Select(c => new Conta(new CodigoConta(c), "a", ETipoConta.Receita, false));
        }
    }

    [Fact]
    public void busca_filhos_ok()
    {
        var listaContas = ContasParaTeste;
        var adapter = new CodigoContaAdapter(listaContas);
        var actual = adapter.BuscaFilhos(new CodigoConta("2"));

        Assert.True(actual.Count() == 2);
    }

    [Theory]
    [InlineData("2", "2.2")]
    [InlineData(null, "3")]
    [InlineData("1", "1.1")]
    [InlineData("2.1", "2.1.1")]
    [InlineData("3", null)]
    public void busca_max_filho_ok(string pai, string expected)
    {
        var listaContas = ContasParaTeste;
        var adapter = new CodigoContaAdapter(listaContas);
        CodigoConta? codigoPai = null;
        if (pai != null)
            codigoPai = new CodigoConta(pai);
        var actual = adapter.BuscaMaxFilho(codigoPai)?.ToString();

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("1", "1", "1.2")]
    [InlineData("2", "2", "2.3")]
    [InlineData("2.1", "2.1", "2.1.2")]
    [InlineData("2.1.1", "2.1.1", "2.1.1.1")]
    [InlineData(null, null, "4")]
    public void gera_proximo_codigo_ok(string codigoPai, string expectedPai, string expectedCodigo)
    {
        //arrange
        var listaContas = ContasParaTeste;
        var adapter = new CodigoContaAdapter(listaContas);
        CodigoConta? codigoContaPai = null;
        if(codigoPai != null)
            codigoContaPai = new CodigoConta(codigoPai);
        //act
        var actual = adapter.ProximoCodigo(codigoContaPai);
        var actualPai = actual.Item1?.ToString();
        var actualCodigo = actual.Item2.ToString();
        //assert
        Assert.Equal(expectedPai, actualPai);
        Assert.Equal(expectedCodigo, actualCodigo);
    }
}