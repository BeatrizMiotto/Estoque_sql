using MySql.Data.MySqlClient;


namespace web.Models;

public class Produtos
{
    public int Id {get; set;}
    public string? Nome {get; set;}
    public string? Descricao {get; set;}
    public string? Entrada {get; set;}
    public string? Validade {get; set;}
    public int Quantidade {get; set;}

    private static readonly string conexao = "Server=localhost;Database=estoque;Uid=root;Pwd=broot;";

    public void SalvarProdutos()
    {
        
        using(var connection = new MySqlConnection (conexao))
        {
            connection.Open();
            var query = $"insert into produto(nome,  descricao, entrada, validade, quantidade )values('{this.Nome}', '{this.Descricao}', '{this.Entrada}', '{this.Validade}', '{this.Quantidade}');";
            if(this.Id >0)
            {
                query = $"update produto set nome ='{this.Nome}', descricao ='{this.Descricao}', entrada='{this.Entrada}', validade= '{this.Validade}', quantidade= '{this.Quantidade}' where id ='{this.Id}';";
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
            var query = $"select * from produto where id = '{idBusca}' or email like '%{idBusca}%' ";
            var command = new MySqlCommand(query, connection);
            var dataReader = command.ExecuteReader();
            
            while(dataReader.Read())
            {
                produtos.Add(new Produtos{
                    Id = Convert.ToInt32(dataReader["Id"]),
                    Nome = dataReader["nome"].ToString(),
                    Descricao = dataReader["descricao"].ToString(),
                    Entrada = dataReader["entrada"].ToString(),
                    Validade = dataReader["validade"].ToString(),
                    Quantidade = Convert.ToInt32(dataReader["quantidade"])
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
            var query = $"select * from produto";
            var command = new MySqlCommand(query, connection);
            var dataReader = command.ExecuteReader();
            
            while(dataReader.Read())
            {
                produtos.Add(new Produtos{
                    Id = Convert.ToInt32(dataReader["Id"]),
                    Nome = dataReader["nome"].ToString(),
                    Descricao = dataReader["descricao"].ToString(),
                    Entrada = dataReader["entrada"].ToString(),
                    Validade = dataReader["validade"].ToString(),
                    Quantidade = Convert.ToInt32(dataReader["quantidade"])

                });

            }
            connection.Close();
        }
        return produtos;

    }

    internal static void ExcluirPorId(int id)
    {
       using(var connection = new MySqlConnection (conexao))
        {
            connection.Open();
            var query = $"delete from produto where id ='{id}';";
    
            var command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }

    public static Produtos? BuscaPorId(int id)
    {
        var produto = new Produtos();
        using(var connection = new MySqlConnection(conexao))
        {
            connection.Open();
            var query = $"select * from produto where id = '{id}' ";
            var command = new MySqlCommand(query, connection);
            var dataReader = command.ExecuteReader();

            while(dataReader.Read())
            {
                produto = new Produtos{
                    Id = Convert.ToInt32(dataReader["Id"]),
                    Nome = dataReader["nome"].ToString(),
                    Descricao = dataReader["descricao"].ToString(),
                    Entrada = dataReader["entrada"].ToString(),
                    Validade = dataReader["validade"].ToString(),
                    Quantidade = Convert.ToInt32(dataReader["quantidade"])
                };
            }
            connection.Close();
        }
        return produto.Id == 0? null : produto;
    }
}