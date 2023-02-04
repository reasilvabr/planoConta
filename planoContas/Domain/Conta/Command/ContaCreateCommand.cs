using MediatR;

namespace PlanoContas.Domain.Conta.Command;

public class ContaCreateCommand : IRequest
{
    public ContaCreateCommand(
        string codigo, string codigoPai, 
        string nome, int tipo, bool aceitaLancamento)
    {
        Codigo = codigo;
        CodigoPai = codigoPai;
        Nome = nome;
        Tipo = tipo;
        AceitaLancamento = aceitaLancamento;
    }
    public string Codigo { get; set; }
    public string? CodigoPai { get; set; }
    public string Nome { get; set; }
    public int Tipo { get; set; }
    public bool AceitaLancamento { get; set; }
}