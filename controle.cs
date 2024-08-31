using System;
using System.Collections.Generic;

class Program
{
    static List<Produto> produtos = new List<Produto>();

    static void Main(string[] args)
    {
        int opcao;
        do
        {
            Console.Clear();
            Console.WriteLine("[1] Novo");
            Console.WriteLine("[2] Listar Produtos");
            Console.WriteLine("[3] Remover Produtos");
            Console.WriteLine("[4] Entrada Estoque");
            Console.WriteLine("[5] Saída Estoque");
            Console.WriteLine("[0] Sair");
            Console.Write("Escolha uma opção: ");
            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    NovoProduto();
                    break;
                case 2:
                    ListarProdutos();
                    break;
                case 3:
                    RemoverProduto();
                    break;
                case 4:
                    EntradaEstoque();
                    break;
                case 5:
                    SaidaEstoque();
                    break;
                case 0:
                    Console.WriteLine("Saindo...");
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }

            if (opcao != 0)
            {
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }

        } while (opcao != 0);
    }

    static void NovoProduto()
    {
        Console.Write("Nome do produto: ");
        string nome = Console.ReadLine();
        Console.Write("Quantidade inicial: ");
        int quantidade = int.Parse(Console.ReadLine());
        Console.Write("Preço: ");
        decimal preco = decimal.Parse(Console.ReadLine());
        Console.Write("Modelo: ");
        string modelo = Console.ReadLine();

        produtos.Add(new Produto { Nome = nome, Quantidade = quantidade, Preco = preco, Modelo = modelo });
        Console.WriteLine("Produto adicionado com sucesso!");
    }

    static void ListarProdutos()
    {
        Console.WriteLine("Produtos cadastrados:");
        foreach (var produto in produtos)
        {
            Console.WriteLine($"Nome: {produto.Nome}, Quantidade: {produto.Quantidade}, Preço: {produto.Preco}, Modelo: {produto.Modelo}");
        }
    }

    static void RemoverProduto()
    {
        Console.Write("Nome do produto a ser removido: ");
        string nome = Console.ReadLine();
        Produto produto = produtos.Find(p => p.Nome == nome);

        if (produto != null)
        {
            produtos.Remove(produto);
            Console.WriteLine("Produto removido com sucesso!");
        }
        else
        {
            Console.WriteLine("Produto não encontrado!");
        }
    }

    static void EntradaEstoque()
    {
        Console.Write("Nome do produto: ");
        string nome = Console.ReadLine();
        Produto produto = produtos.Find(p => p.Nome == nome);

        if (produto != null)
        {
            Console.Write("Quantidade a adicionar: ");
            int quantidade = int.Parse(Console.ReadLine());
            produto.Quantidade += quantidade;
            Console.WriteLine("Estoque atualizado com sucesso!");
        }
        else
        {
            Console.WriteLine("Produto não encontrado!");
        }
    }

    static void SaidaEstoque()
    {
        Console.Write("Nome do produto: ");
        string nome = Console.ReadLine();
        Produto produto = produtos.Find(p => p.Nome == nome);

        if (produto != null)
        {
            Console.Write("Quantidade a remover: ");
            int quantidade = int.Parse(Console.ReadLine());
            if (produto.Quantidade >= quantidade)
            {
                produto.Quantidade -= quantidade;
                Console.WriteLine("Estoque atualizado com sucesso!");
            }
            else
            {
                Console.WriteLine("Quantidade insuficiente em estoque!");
            }
        }
        else
        {
            Console.WriteLine("Produto não encontrado!");
        }
    }
}

class Produto
{
    public string Nome { get; set; }
    public int Quantidade { get; set; }
    public decimal Preco { get; set; }
    public string Modelo { get; set; }
}
