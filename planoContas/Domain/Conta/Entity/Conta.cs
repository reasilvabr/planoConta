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
            if(!CodigoConta.ValidaCodigoPai(CodigoContaPai, CodigoConta))
            {
                throw new InvalidOperationException("Código pai/filho incoerentes.");
            }
        }
    }
    private CodigoConta _codigoConta;
    public CodigoConta CodigoConta { get; private set; }
    public CodigoConta? CodigoContaPai { get; private set; }
    public string Nome { get; set; }
    private ETipoConta _tipo;
    public ETipoConta Tipo
    {
        get => _tipo;
        private set
        {
            if (ContaPai != null
            && ContaPai.Tipo != value)
            {
                throw new InvalidOperationException("Conta filha deve ter mesmo tipo do pai.");
            }
            _tipo = value;
        }
    }
    public bool AceitaLancamento { get; set; }
}