using System;
using PlanoContas.Domain.Conta.Entity;
using Xunit;

namespace planoContas.test;

public class CodigoContaUnitTest
{
    [Theory]
    [InlineData("1")]
    [InlineData("1.9")]
    [InlineData("999.999.999")]
    [InlineData("1.98.1")]
    [InlineData("55.55.55.55.555")]
    public void valida_codigo_conta_ok(string codigo)
    {
        //arrange, act
        var actual = CodigoConta.Valida(codigo);
        //assert
        Assert.True(actual);
    }

    [Theory]
    [InlineData("1.")] 
    [InlineData("")] 
    [InlineData("1.9999")]
    [InlineData("1000")] 
    [InlineData("1.a.2.10")]
    public void valida_codigo_conta_nok(string codigo)
    {
        //arrange, act
        var actual = CodigoConta.Valida(codigo);

        //assert
        Assert.False(actual);
    }

    [Theory]
    [InlineData("1")]
    [InlineData("1.1")]
    [InlineData("2.5.999")]
    [InlineData("55.55.55.555")]
    [InlineData("999.1.10")]
    public void cria_codigo_conta_ok(string codigo)
    {
        //arrange
        var expected = codigo;

        //act
        var actual = new CodigoConta(codigo).ToString();

        //assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("")]
    [InlineData("1.")]
    [InlineData("ab")]
    [InlineData("94893.1.1")]
    [InlineData("1.1.1.1000")]
    public void cria_codigo_conta_nok(string codigo)
    {
        //arrange
        Action testeValida = delegate(){new CodigoConta(codigo);};

        //act, assert
        Assert.Throws<FormatException>(testeValida);
    }

    [Theory]
    [InlineData("1")]
    [InlineData("1.1")]
    [InlineData("9.9.9")]
    [InlineData("777.777.1")]
    [InlineData("1.1.1.999.999")]
    public void compara_codigo_conta_ok(string codigo)
    {
        //arrange
        var expected = new CodigoConta(codigo);
        
        //act
        var actual = new CodigoConta(codigo);
        
        //assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("1", "2")]
    [InlineData("1.1", "1.1.2")]
    [InlineData("1.1.1", "1.1.1.9")]
    [InlineData("1.1.999.999", "1.1.999.998")]
    [InlineData("1.1.1", "1.1.2")]
    public void compara_codigo_conta_nok(string codigoA, string codigoB)
    {
        //arrange
        var expected = new CodigoConta(codigoA);
        
        //act
        var actual = new CodigoConta(codigoB);
        
        //assert
        Assert.NotEqual(expected, actual);
    }

    [Theory]
    [InlineData("2", "1")]
    [InlineData("1.2", "1.1.2")]
    [InlineData("1.1.1.9", "1.1.1")]
    [InlineData("1.1.999.999", "1.1.999.998")]
    [InlineData("1.1.1.1", "1.1.1")]
    [InlineData("1.10", "1.1")]
    [InlineData("1.10", "1.9")]
    public void compara_maior_codigo_conta_ok(string codigoA, string codigoB)
    {
        //arrange
        var a = new CodigoConta(codigoA);
        var b = new CodigoConta(codigoB);
        
        //act
        var actual = a.CompareTo(b) > 0;
        
        //assert
        Assert.True(actual);
    }
}