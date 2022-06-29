namespace ProjetoEstoque
{

    [System.Serializable]
    public abstract class Produto 
    {
        public string nome;
        public float preco;

        public Produto(string nome, float preco)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentNullException(nameof(nome), "Informe um nome válido.");
            if (preco <= 0)
                throw new ArgumentNullException(nameof(preco), "Informe um preço maior que zero.");

            this.nome = nome;
            this.preco = preco;


        }
    }
}
