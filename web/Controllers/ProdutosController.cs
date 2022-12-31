using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using web.Models;

namespace web.Controllers;

public class ProdutosController : Controller
{
    public IActionResult Index()
    {
        ViewBag.produtos = Produtos.Listar();
        return View();
    }

    public IActionResult Cadastrar([FromForm] Produtos produto)
    {
        if(string.IsNullOrEmpty(produto.Nome))
        {
            ViewBag.erro = "O nome do produto não pode ser vazio";
            return View();
        }
        produto.SalvarProdutos();
        return Redirect("/produtos");
    }
    [Route("/produtos/{id}/excluir")]
    public IActionResult Excluir([FromRoute] int id)
    {
        
        Produtos.ExcluirPorId(id);
        return Redirect("/produtos");
    }
    [Route("/produtos/{id}/editar")]
    public IActionResult Editar([FromRoute] int id, [FromForm] Produtos produto)
    {
        produto.Id = id;
        produto.SalvarProdutos();
        ViewBag.produto = Produtos.BuscaPorId(id);
        return Redirect("/produtos");
    }
    
}
