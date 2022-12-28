using MySql.Data.MySqlClient;

namespace Negocio.Models;

public class Produtos
{
    public int Id {get; set;}
    public string? Nome {get; set;}
    public string? Descricao {get; set;}
    public string? DataCriacao {get; set;}
    public string? DataValidade {get; set;}
    public string? QuantidadeEstoque {get; set;}

    private static readonly string conexao = "Server=localhost;Database=persistencia;Uid=root;Pwd=broot;";

    public void SalvarProdutos()
    {
        
        using(var connection = new MySqlConnection (conexao))
        {
            connection.Open();
            var query = $"insert into produtos(nome,  descricao, data_criacao, data_validade, quantidade_estoque )values('{this.Nome}', '{this.Descricao}', '{this.DataCriacao}', '{this.DataValidade}', '{this.QuantidadeEstoque}');";
            var command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}