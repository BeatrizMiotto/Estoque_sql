using MySql.Data.MySqlClient;


namespace web.Models;

public class Produtos
{
    public int Id {get; set;}
    public string? Nome {get; set;}
    public string? Descricao {get; set;}
    public string? DataCriacao {get; set;}
    public string? DataValidade {get; set;}
    public int QuantidadeEstoque {get; set;}

    private static readonly string conexao = "Server=localhost;Database=persistencia;Uid=root;Pwd=broot;";

    public void SalvarProdutos()
    {
        
        using(var connection = new MySqlConnection (conexao))
        {
            connection.Open();
            var query = $"insert into produtos(nome,  descricao, data_criacao, data_validade, quantidade_estoque )values('{this.Nome}', '{this.Descricao}', '{this.DataCriacao}', '{this.DataValidade}', '{this.QuantidadeEstoque}');";
            if(this.Id >0)
            {
                query = $"update produtos set nome ='{this.Nome}', descricao ='{this.Descricao}', data_criacao='{this.DataCriacao}', data_validade= '{this.DataValidade}', quantidade_estoque= '{this.QuantidadeEstoque}' where id ='{this.Id}';";
            }
            
            var command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
    public static List<Produtos> BuscarPorId(string idBusca)
    {
        var produtos = new List<Produtos>();
        using(var connection = new MySqlConnection(conexao))
        {
            connection.Open();
            var query = $"select * from produtos where id = '{idBusca}' or email like '%{idBusca}%' ";
            var command = new MySqlCommand(query, connection);
            var dataReader = command.ExecuteReader();
            
            while(dataReader.Read())
            {
                produtos.Add(new Produtos{
                    Id = Convert.ToInt32(dataReader["Id"]),
                    Nome = dataReader["nome"].ToString(),
                    Descricao = dataReader["descricao"].ToString(),
                    DataCriacao = dataReader["data_criacao"].ToString(),
                    DataValidade = dataReader["data_validade"].ToString(),
                    QuantidadeEstoque = Convert.ToInt32(dataReader["quantidade_estoque"])
                });

            }
            connection.Close();
        }
        return produtos;
    }
    public static List<Produtos> Listar()
    {
        var produtos = new List<Produtos>();
        using(var connection = new MySqlConnection(conexao))
        {
            connection.Open();
            var query = $"select * from produtos";
            var command = new MySqlCommand(query, connection);
            var dataReader = command.ExecuteReader();
            
            while(dataReader.Read())
            {
                produtos.Add(new Produtos{
                    Id = Convert.ToInt32(dataReader["Id"]),
                    Nome = dataReader["nome"].ToString(),
                    Descricao = dataReader["descricao"].ToString(),
                    DataCriacao = dataReader["data_criacao"].ToString(),
                    DataValidade = dataReader["data_validade"].ToString(),
                    QuantidadeEstoque = Convert.ToInt32(dataReader["quantidade_estoque"])

                });

            }
            connection.Close();
        }
        return produtos;

    }
}