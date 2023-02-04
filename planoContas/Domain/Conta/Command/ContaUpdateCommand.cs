namespace PlanoContas.Domain.Conta.Command;

public class ContaUpdateCommand : ContaCreateCommand
{
    public ContaUpdateCommand(string codigo, string codigoPai,
        string nome, int tipo, bool aceitaLancamento)
        : base(codigo, codigoPai, nome, tipo, aceitaLancamento)
    {

    }
}