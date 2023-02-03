namespace PlanoContas.Domain.Conta.Entity;

public enum ETipoConta{
    Receita = 1,
    Despesa = 2
}

public class Conta
{
    public Conta(CodigoConta codigoConta, string nome, ETipoConta tipo, bool aceitaLancamento)
    {
        this.CodigoConta = codigoConta;
        //this.ContaPai = contaPai;
        this.Nome = nome;
        this.Tipo = tipo;
        this.AceitaLancamento = aceitaLancamento;
    }
    public Conta? ContaPai { get; set; }
    public CodigoConta CodigoConta { get; set; }
    public string Nome { get; set; }
    public ETipoConta Tipo { get; set; }
    public bool AceitaLancamento { get; set; }
}