using Projeto;

namespace ProjetoEstoque
{
    [System.Serializable]
    class ProdutoFisico : Produto, IEstoque
    {
        public float frete;
        private int estoque;


        public ProdutoFisico(string nome, float preco, float frete) : base(nome, preco)
        {
            if (frete <= 0)
                throw new ArgumentNullException(nameof(frete), "Informe um frete válido.");
            this.frete = frete;
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine($"Adicionar entrada no estoque do produto {nome}");
            Console.WriteLine("Digite a Qtd. que você quer dar entrada: ");
            int entrada = Program.ObterValorInteiroValido();
            estoque += entrada;
            Console.WriteLine("Entrada registrada");
            Console.ReadLine();
        }

        public void AdicionarSaida()
        {
            Console.WriteLine($"Adicionar saido no estoque do produto {nome}");
            Console.WriteLine("Digite a Qtd. que você quer dar baixa: ");
            int entrada = Program.ObterValorInteiroValido();
            estoque -= entrada;
            Console.WriteLine("Entrada registrada");
            Console.ReadLine();

        }
        public void Exibir()
        {
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Frete: {frete}");
            Console.WriteLine($"Preço: {preco}");
            Console.WriteLine($"Estoque: {estoque}");
            Console.WriteLine("===========================");
        }
    }

}
