using MediatR;

namespace PlanoContas.Domain.Conta.Query;

public class CodigoContaGetQuery : IRequest<string>
{
    public CodigoContaGetQuery(string? codigoPai)
    {
        CodigoPai = codigoPai;
    }
    public string? CodigoPai { get; set; }
}