using System.ComponentModel.DataAnnotations;

namespace PlanoContas.Domain.Conta.Entity;

public enum ETipoConta
{
    Receita = 1,
    Despesa = 2
}

public class Conta
{
    public Conta(CodigoConta codigoConta, CodigoConta? codigoContaPai, string nome, ETipoConta tipo, bool aceitaLancamento)
    {
        CodigoConta = codigoConta;
        CodigoContaPai = codigoContaPai;
        Nome = nome;
        Tipo = tipo;
        AceitaLancamento = aceitaLancamento;
    }
    private Conta? _contaPai;
    public Conta? ContaPai
    {
        get => _contaPai;
        set
        {
            if (value != null && value.AceitaLancamento)
            {
                throw new InvalidOperationException("Conta pai não pode aceitar lançamentos.");
            }
            if (value != null && value.Tipo != Tipo)
            {
                throw new InvalidOperationException("Conta filha deve ter mesmo tipo do pai.");
            }
            _contaPai = value;
            CodigoContaPai = value?.CodigoConta;
            if (!CodigoConta.ValidaPai(CodigoContaPai, CodigoConta))
            {
                throw new InvalidOperationException("Código pai/filho incoerentes.");
            }
        }
    }
    private CodigoConta _codigoConta;
    public CodigoConta CodigoConta { get; private set; }
    public CodigoConta? CodigoContaPai { get; private set; }
    
    [Required]
    [MinLength(3, ErrorMessage = "Nome deve ter ao menos 3 caracteres.")]
    public string Nome { get; set; }
    public ETipoConta Tipo { get; private set; }
    public bool AceitaLancamento { get; set; }
}