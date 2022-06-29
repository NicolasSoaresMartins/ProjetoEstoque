using ProjetoEstoque;
using System.Runtime.Serialization.Formatters.Binary;
namespace Projeto
{

    class Program
    {
        static List<IEstoque> produtos = new List<IEstoque>();
        enum Menu { listar = 1, Adicionar, Remover, Entrada, Saida, Sair }
        static bool EscolheuSair = false;

        static void Main(string[] args)
        {
            Carregar();

            while (EscolheuSair == false)
            {
                Console.Write("Sistema de estoque");
                Console.WriteLine("\n1-Listar\n2-Adicionar\n3-Remover\n4-Entrada\n5-Saida\n6-Sair");
                int opInt = ObterValorInteiroValido();
                Menu escolha = (Menu)opInt;

                ChamarMenuEscolhido(escolha);

            }
        }

        private static void ChamarMenuEscolhido(Menu escolha)
        {
            switch (escolha)
            {
                case Menu.listar:
                    Listagem();
                    break;
                case Menu.Adicionar:
                    Cadastro();
                    break;
                case Menu.Remover:
                    Remover();
                    break;
                case Menu.Entrada:
                    Entrada();
                    break;
                case Menu.Saida:
                    Saida();
                    break;
                case Menu.Sair:
                    EscolheuSair = true;
                    break;
                default:
                    break;
            }
            Console.Clear();
        }

        static void Listagem()
        {
            Console.WriteLine("Lista de produtos");
            int i = 0;
            foreach (var produto in produtos)
            {
                Console.WriteLine("ID: " + i);
                produto.Exibir();
                i++;
            }
            Console.ReadLine();
        }

        static void Remover()
        {

            Listagem();
            Console.WriteLine("Digite o ID do elemento que você quer remover:");
            int id = ObterValorInteiroValido();


            while (id >= 0 && id < produtos.Count)
            {
                produtos.RemoveAt(id);
                Salvar();
            }
        }

        static void Entrada()
        {
            Listagem();

            Console.WriteLine("Digite o ID do elemento que você quer dar entrada: ");

            while (true)
            {
                int id = ObterValorInteiroValido();
                if (id >= 0 && id < produtos.Count)
                {
                    produtos[id].AdicionarEntrada();
                    Console.ReadLine();
                    Salvar();
                    break;
                }
                else
                {
                    Console.WriteLine("Valor informado está fora da lista. Informe um valor maior que zero que esteja dentro da lista");
                }
            }
        }

        public static int ObterValorInteiroValido()
        {
            var receba = 0;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out receba))
                    break;
                else
                    Console.WriteLine("Informe um valor valido");
            }


            return receba;
        }
        public static float ObterValorDecimalPositivoValido()
        {
            float receba = 0;
            while (true)
            {
                if (float.TryParse(Console.ReadLine(), out receba) && receba > 0)
                    break;
                else
                    Console.WriteLine("Informe um valor valido, deve ser maior que zero.");
            }


            return receba;
        }


        static void Saida()
        {
            Listagem();
            Console.WriteLine("Digite o ID do elemento que você quer dar baixa: ");
            while (true)
            {
                int id = ObterValorInteiroValido();
                if (id >= 0 && id < produtos.Count)
                {
                    produtos[id].AdicionarSaida();
                    Console.ReadLine();
                    Salvar();
                    break;
                }
                else
                {
                    Console.WriteLine("Valor informado está fora da lista. Informe um valor maior que zero que esteja dentro da lista");
                }
            }
        }

        static void Cadastro()
        {
            Console.WriteLine("Cadastro de Produto");
            Console.WriteLine("1-Produto Fisico\n2-Ebook\n3-Curso");
            int escolhaInt = ObterValorInteiroValido();

            switch (escolhaInt)
            {
                case 1:
                    CadastrarPFisico();
                    break;
                case 2:
                    CadastrarEbook();
                    break;
                case 3:
                    CadastrarCurso();
                    break;
            }
        }
        static void CadastrarPFisico()
        {
            bool confirma = false;


            Console.WriteLine("Cadastrar produto fisico");

            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(nome))
            {
                Console.WriteLine("Nome Inválido, digite um nome válido");
                nome = Console.ReadLine();
            }
            Console.WriteLine("Preco: ");
            float preco = ObterValorDecimalPositivoValido();
            while (preco <= 0)
            {
                Console.WriteLine("Preço inválido, digite novamente");
                float.TryParse(Console.ReadLine(), out preco);
            }
            Console.WriteLine("Frete: ");
            float frete = ObterValorDecimalPositivoValido();
            while (frete <= 0)
            {
                Console.WriteLine("Frete inválido, digite novamente");
                float.TryParse(Console.ReadLine(), out frete);
            }



            try
            {
                var pf = new ProdutoFisico(nome, preco, frete);
                produtos.Add(pf);
                Salvar();
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }


        }

        static void CadastrarEbook()
        {
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(nome))
            {
                Console.WriteLine("Nome Inválido, digite um nome válido");
                nome = Console.ReadLine();
            }
            Console.WriteLine("Preco: ");
            float preco = ObterValorDecimalPositivoValido();
            while (preco <= 0)
            {
                Console.WriteLine("Preço inválido, digite novamente");
                float.TryParse(Console.ReadLine(), out preco);
            }
            Console.WriteLine("Autor: ");
            string autor = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(autor))
            {
                Console.WriteLine("Autor inválido, Digite novamente");
                autor = Console.ReadLine();
            }

            try
            {
                var eb = new Ebook(nome, preco, autor);
                produtos.Add(eb);
                Salvar();
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
        static void CadastrarCurso()
        {
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(nome))
            {
                Console.WriteLine("Nome Inválido, digite um nome válido");
                nome = Console.ReadLine();
            }
            Console.WriteLine("Preco: ");
            float preco = ObterValorDecimalPositivoValido();
            while (preco <= 0)
            {
                Console.WriteLine("Preço inválido, digite novamente");
                float.TryParse(Console.ReadLine(), out preco);
            }
            Console.WriteLine("Autor: ");
            string autor = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(autor))
            {
                Console.WriteLine("Autor inválido, Digite novamente");
                autor = Console.ReadLine();
            }
            try
            {
                var cs = new Curso(nome, preco, autor);
                produtos.Add(cs);
                Salvar();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }

        }
        static void Salvar()
        {
            var stream = new FileStream("produtos.dat", FileMode.OpenOrCreate);
            var encoder = new BinaryFormatter();

            encoder.Serialize(stream, produtos);

            stream.Close();
        }

        static void Carregar()
        {
            var stream = new FileStream("produtos.dat", FileMode.OpenOrCreate);
            var encoder = new BinaryFormatter();


            try
            {

                produtos = (List<IEstoque>)encoder.Deserialize(stream);
                if (produtos == null)
                {
                    produtos = new List<IEstoque>();
                }
            }
            catch (Exception e)
            {
                produtos = new List<IEstoque>();
            }
            stream.Close();
        }
    }
}

