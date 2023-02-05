using System.Text;
using System.Text.RegularExpressions;

namespace PlanoContas.Domain.Conta.Entity;

public class CodigoConta : IComparable<CodigoConta>, IEquatable<CodigoConta>
{
    public CodigoConta(string codigoConta)
    {
        this.Codigo = ConverteParaLinkedList(codigoConta);
    }
    protected LinkedList<int> Codigo {get; private set;}

    protected LinkedList<int> ConverteParaLinkedList(string codigo)
    {
        if(!CodigoConta.Valida(codigo))
            throw new InvalidOperationException("Código inválido.");

        var retorno = new LinkedList<int>();
        var arrayCodigo = codigo.Split('.');
        foreach(var str in arrayCodigo)
        {
            retorno.AddLast(int.Parse(str));
        }
        return retorno;
    }

    public int Level => Codigo.Count();

    public int CodigoPorLevel(int? level = null)
    {
        if(level.HasValue)
            return Codigo.ElementAt(level.Value - 1);
        return Codigo.ElementAt(Level - 1);
    }

    public override string ToString()
    {
        return string.Join('.', Codigo.ToArray());
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

    public static bool Valida(string codigo)
    {
        var regex = new Regex(@"^([1-9]{1}\d{0,2}\.)*[1-9]{1}\d{0,2}$");
        return codigo.Length <= 50 && regex.IsMatch(codigo);
    }

    public static bool ValidaPai(CodigoConta? pai, CodigoConta filho)
    {
        if (pai == null && filho.Level > 1)
        {
            return false;
        }
        if(pai != null && pai.Level != filho.Level - 1)
        {
            return false;
        }
        if(pai!=null)
        {
            for(int l = 1; l <= pai.Level; l++)
            {
                if(pai.CodigoPorLevel(l) != filho.CodigoPorLevel(l))
                {
                    return false;
                }
            }
        }
        return true;
    }

    public bool Equals(CodigoConta? other)
    {
        return this.ToString() == other?.ToString();
    }
}