using System.Text;
using System.Text.RegularExpressions;

namespace PlanoContas.Domain.Conta.Entity;

public class CodigoConta : IComparable<CodigoConta>
{
    public CodigoConta(string codigoConta)
    {
        this.Codigo = CodigoConta.Parse(codigoConta);
    }
    protected LinkedList<int> Codigo {get; set;}

    public override string ToString()
    {
        return string.Join('.', Codigo.ToArray());
    }

    public static bool Valida(string codigo)
    {
        var regex = new Regex(@"^(\d{1,3}\.)*\d{1,3}$");
        return codigo.Length <= 50 && regex.IsMatch(codigo);
    }

    protected static LinkedList<int> Parse(string codigo)
    {
        if(!CodigoConta.Valida(codigo))
            throw new FormatException();

        var retorno = new LinkedList<int>();
        var arrayCodigo = codigo.Split('.');
        foreach(var str in arrayCodigo)
        {
            retorno.AddLast(int.Parse(str));
        }
        return retorno;
    }

    public int CompareTo(CodigoConta? other)
    {
        var tamanho = this.Codigo.Count();
        if(other?.Codigo.Count() > tamanho) 
        {
            tamanho = other.Codigo.Count();
        }
        var compara = 0;
        for(var i = 0; i < tamanho; i++)
        {
            compara = this.Codigo.ElementAtOrDefault(i).CompareTo(other?.Codigo.ElementAtOrDefault(i));
            if (compara != 0)
                return compara;
        }
        return compara;
    }
}