using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using web.Models;

namespace web.Controllers;

public class ProdutosController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

}
