using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using web.Models;

namespace web.Controllers;

public class HomeController : Controller
{

    public IActionResult Index()
    {
        ViewBag.produtos = Produtos.Listar();
        return View();
    }

}
