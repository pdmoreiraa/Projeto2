using MySql.Data.MySqlClient;
using Projeto2.Models;
using System.Data;

namespace Projeto2.Repository
{
    public class ProdutoRepository(IConfiguration configuration)
    {
        private readonly string _conexaoMySQL = configuration.GetConnectionString("ConexaoMySQL");



       
        public void CadastrarProduto(Produto produto)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand("insert into Produtos(Nome, Descricao, Preco, Quantidade) " +
                                                    "values (@nome, @descricao, @preco, @quantidade)", conexao);
                cmd.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = produto.Nome;
                cmd.Parameters.Add("@Descricao", MySqlDbType.VarChar).Value = produto.Descricao;
                cmd.Parameters.Add("@Preco", MySqlDbType.Decimal).Value = produto.Preco;
                cmd.Parameters.Add("@Quantidade", MySqlDbType.Int32).Value = produto.Quantidade;
                cmd.ExecuteNonQuery();
                conexao.Close();

            }
     
        }


        public IEnumerable<Produto> TodosProdutos()
        {
            List<Produto> Produtolist = new List<Produto>();

            // Bloco using para garantir que a conexão seja fechada e os recursos liberados após o uso
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                // Abre a conexão com o banco de dados MySQL
                conexao.Open();
                // Cria um novo comando SQL para selecionar todos os registros da tabela 'cliente'
                MySqlCommand cmd = new MySqlCommand("SELECT * from Produtos", conexao);

                // Cria um adaptador de dados para preencher um DataTable com os resultados da consulta
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                // Cria um novo DataTable
                DataTable dt = new DataTable();
                // metodo fill- Preenche o DataTable com os dados retornados pela consulta
                da.Fill(dt);
                // Fecha explicitamente a conexão com o banco de dados 
                conexao.Close();

                // interage sobre cada linha (DataRow) do DataTable
                foreach (DataRow dr in dt.Rows)
                {
                    // Cria um novo objeto Cliente e preenche suas propriedades com os valores da linha atual
                    Produtolist.Add(
                                new Produto
                                {
                                    Id = Convert.ToInt32(dr["IdProd"]),
                                    Nome = ((string) dr["Nome"]), // Converte o valor da coluna "nome" para string
                                    Descricao = ((string) dr["Descricao"]), // Converte o valor da coluna "nome" para string
                                    Preco = ((decimal) dr["Preco"]), // Converte o valor da coluna "telefone" para string
                                    Quantidade = Convert.ToInt32(dr["Quantidade"]), // Converte o valor da coluna "codigo" para inteiro
                                });
                }
                // Retorna a lista de todos os clientes
                return Produtolist;
            }
            
        }

        // Método para buscar um cliente específico pelo seu código (Codigo)
        public Produto ObterProduto(int Id)
        {
            // Bloco using para garantir que a conexão seja fechada e os recursos liberados após o uso
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                // Abre a conexão com o banco de dados MySQL
                conexao.Open();
                // Cria um novo comando SQL para selecionar um registro da tabela 'cliente' com base no código
                MySqlCommand cmd = new MySqlCommand("SELECT * from Produtos where IdProd=@IdProd ", conexao);

                // Adiciona um parâmetro para o código a ser buscado, definindo seu tipo e valor
                cmd.Parameters.AddWithValue("@IdProd", Id);

                // Cria um adaptador de dados (não utilizado diretamente para ExecuteReader)
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                // Declara um leitor de dados do MySQL
                MySqlDataReader dr;
                // Cria um novo objeto Cliente para armazenar os resultados
                Produto produto = new Produto();

                /* Executa o comando SQL e retorna um objeto MySqlDataReader para ler os resultados
                CommandBehavior.CloseConnection garante que a conexão seja fechada quando o DataReader for fechado*/

                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                // Lê os resultados linha por linha
                while (dr.Read())
                {
                    // Preenche as propriedades do objeto Cliente com os valores da linha atual
                    produto.Id = Convert.ToInt32(dr["IdProd"]);//propriedade Codigo e convertendo para int
                    produto.Nome = (string)(dr["Nome"]); // propriedade Nome e passando string
                    produto.Preco = ((decimal)dr["Preco"]);//propriedade telefone e passando string
                    produto.Quantidade = Convert.ToInt32(dr["Quantidade"]); //propriedade email e passando string
                }
                // Retorna o objeto Cliente encontrado (ou um objeto com valores padrão se não encontrado)
                return produto;
            }
        }

    }
}
