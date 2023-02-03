namespace PlanoContas.Domain.Conta.Dto;

public class ContaDto
{
    public ContaDto(Conta.Entity.Conta conta){
        CodigoConta = conta.CodigoConta.ToString();
        CodigoContaPai = conta.ContaPai?.CodigoConta.ToString();
        Nome = conta.Nome;
        Tipo = (int)conta.Tipo;
        AceitaLancamento = conta.AceitaLancamento;
    }
    public string CodigoConta { get; set; }
    public string? CodigoContaPai { get; set; }
    public string Nome { get; set; }
    public int Tipo { get; set; }
    public bool AceitaLancamento { get; set; }    
}