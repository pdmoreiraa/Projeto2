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
    }
}
