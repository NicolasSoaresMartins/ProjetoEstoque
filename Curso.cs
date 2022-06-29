using Projeto;

namespace ProjetoEstoque
{
    [System.Serializable]
    public class Curso : Produto, IEstoque
    {
        public readonly string autor;
        public int vagas { get; private set; }

        public Curso(string nome, float preco, string autor) : base(nome, preco)
        {
            if (string.IsNullOrWhiteSpace(autor))
                throw new ArgumentNullException(nameof(autor), "Informe um autor válido.");
            this.autor = autor;

        }

        public void AdicionarEntrada()
        {
            Console.WriteLine($"Adicionar vagas no curso {nome}");
            Console.WriteLine("Digite a Qtd. que você quer dar entrada: ");
            int entrada = Program.ObterValorInteiroValido();
            vagas += entrada;
            Console.WriteLine("Entrada registrada");
            Console.ReadLine();
        }

        public void AdicionarSaida()
        {
            Console.WriteLine($"Adicionar entrada no estoque do produto {nome}");
            Console.WriteLine("Digite a Qtd. que você quer dar entrada: ");
            int entrada = Program.ObterValorInteiroValido();
            vagas -= entrada;
            Console.WriteLine("Entrada registrada");
            Console.ReadLine();
        }

        public void Exibir()
        {
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Autor: {autor}");
            Console.WriteLine($"Preço: {preco}");
            Console.WriteLine($"Vagas restantes: {vagas}");
            Console.WriteLine("===========================");
        }
    }
}
