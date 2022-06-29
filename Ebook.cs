using Projeto;

namespace ProjetoEstoque
{
    [System.Serializable]
    public class Ebook : Produto, IEstoque
    {
        public readonly string autor;
        public int vendas { get; private set; }

        public Ebook(string nome, float preco, string autor) : base(nome, preco)
        {
            if (string.IsNullOrWhiteSpace(autor))
                throw new ArgumentNullException(nameof(autor), "Informe um autor válido.");
            this.autor = autor;
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine("Não é possivel dar entrada no estoque de um E-book, pois é um produto Digite");
        }

        public void AdicionarSaida()
        {
            Console.WriteLine($"Adicionar vendas no Ebook {nome}");
            Console.WriteLine("Digite a Qtd. que você quer dar entrada: ");
            int entrada = Program.ObterValorInteiroValido();
            vendas += entrada;
            Console.WriteLine("Entrada registrada");
            Console.ReadLine();
        }

        public void Exibir()
        {
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Autor: {autor}");
            Console.WriteLine($"Preço: {preco}");
            Console.WriteLine($"Vendas: {vendas}");
            Console.WriteLine("===========================");
        }
    }
}
