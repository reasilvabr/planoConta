using PlanoContas.Domain.Conta.Entity;

namespace PlanoContas.Domain.Conta.Adapter;
public class CodigoContaAdapter
{
    class Tree{
        public Tree(IEnumerable<Conta.Entity.Conta> contas){
            Root = new TreeNode(0, null);
            var pos = 0;
            while (pos < contas.Count())
            {
                Adiciona(Root, contas, ref pos);              
                pos++;
            }
        }

        public TreeNode Root;
        void Adiciona(TreeNode pai, IEnumerable<Conta.Entity.Conta> contas, ref int posAtual){
            var conta = contas.ElementAt(posAtual);
            var node = new TreeNode(conta.CodigoConta.CodigoPorLevel(), conta);
            pai.AdicionaFilho(node);
            while(posAtual < contas.Count() - 1 &&
                contas.ElementAt(posAtual + 1).CodigoConta.Level == conta.CodigoConta.Level + 1)
            {
                posAtual++;
                Adiciona(node, contas, ref posAtual);
            }
        }

        public TreeNode? Encontra(CodigoConta codigo)
        {
            var node = Root;
            for(var i = 1; i <= codigo.Level; i++)
            {
                node = node?.Filhos.Where(n => n.Valor == codigo.CodigoPorLevel(i)).FirstOrDefault();
            }
            return node;
        }
    }
    class TreeNode{
        public TreeNode(int valor, Conta.Entity.Conta? conta)
        {
            Valor = valor;
            Conta = conta;
            Filhos = new LinkedList<TreeNode>();
        }
        public int Valor { get; set; }
        public Conta.Entity.Conta? Conta { get; set; }
        public TreeNode? Pai { get; set; }
        public LinkedList<TreeNode> Filhos { get; set; }
        public void AdicionaFilho(TreeNode filho){
            filho.Pai = this;
            Filhos.AddLast(filho);
        }
    }

    private readonly Tree tree;
    public CodigoContaAdapter(IEnumerable<Conta.Entity.Conta> contas){
        tree = new Tree(contas.OrderBy(c => c.CodigoConta));
    }

    public IEnumerable<CodigoConta>? BuscaFilhos(CodigoConta codigoPai)
    {
        var pai = tree.Encontra(codigoPai);
        return pai?.Filhos.Where(n=> n.Conta != null).Select(n => n.Conta.CodigoConta);
    }

    public CodigoConta? BuscaMaxFilho(CodigoConta? codigoPai = null)
    {
        TreeNode? pai;
        pai = tree.Root;
        if(codigoPai != null)
            pai = tree.Encontra(codigoPai);
        return pai?.Filhos.LastOrDefault()?.Conta?.CodigoConta;
    }

    public Tuple<CodigoConta?, CodigoConta> ProximoCodigo(CodigoConta? codigoPai)
    {
        TreeNode pai;
        pai = tree.Root;
        if(codigoPai != null)
        {
            var nodePai = tree.Encontra(codigoPai);
            if(nodePai != null)
            {
                pai = nodePai;
            }
        }
        var maiorFilho = BuscaMaxFilho(codigoPai);
        if(maiorFilho != null)
        {
            var proximo = maiorFilho.CodigoPorLevel() + 1;
            if(proximo > 999)
            {
                return ProximoCodigo(pai.Pai?.Conta?.CodigoConta);
            }
            var arrConta = maiorFilho.ToString().Split(".");
            arrConta[arrConta.Length - 1] = proximo.ToString();
            var novaConta = new CodigoConta(string.Join(".", arrConta));
            return new Tuple<CodigoConta?, CodigoConta>(codigoPai, novaConta);
        }
        else
        {
            var novaConta = new CodigoConta(pai.Conta?.CodigoConta.ToString() + ".1" ?? "1");
            return new Tuple<CodigoConta?, CodigoConta>(codigoPai, novaConta);
        }
    }
}