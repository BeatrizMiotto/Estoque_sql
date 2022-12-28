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
            ViewBag.erro = "O nome não pode ser vazio";
            return View();
        }
        produto.SalvarProdutos();
        return Redirect("/produtos");
    }
}
