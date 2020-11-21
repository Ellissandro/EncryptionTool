using EncryptionTool.Api.Models;
using EncryptionTool.Domain.Entities;
using EncryptionTool.Domain.Interfaces.Services;
using EncryptionTool.Domain.ValueObjects;
using EncryptionTool.Infra.Persistence.EF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EncryptionTool.Api.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IServiceUsuario _serviceUsuario;
        private readonly EncryptionToolContext _context;

        public HomeController(ILogger<HomeController> logger, IServiceUsuario serviceUsuario, EncryptionToolContext context)
        {
            _logger = logger;
            _serviceUsuario = serviceUsuario;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Cadastro()
        {

           return View();
        
        }

        public IActionResult ListarUsuarios()
        {
            try
            {
                var usuarios = _serviceUsuario.ObterTodosUsuarios();
                return View(usuarios);
            }
            catch (Exception e)
            {
                TempData["MSG_E"] = e;
                return View();
            }
        }


        [HttpPost]
        public IActionResult Cadastro([FromForm] Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var save = _serviceUsuario.AdicionarUsuario(usuario);

                    if(save)
                    {
                        TempData["MSG_S"] = "Cadastro Realizado com sucesso!";
                        return RedirectToAction(nameof(ListarUsuarios));
                    }else
                      TempData["MSG_E"] = "Este email já está sendo usado.";
                }
                                 
            }
            catch (Exception e)
            {
                TempData["MSG_E"] = e;
            }

            return View();
        }

        public IActionResult Excluir(Guid Id)
        {
            try
            {
                _serviceUsuario.Excluir(Id);
                TempData["MSG_S"] = "Usuário Excluído com sucesso!";
            }
            catch (Exception e)
            {
                TempData["MSG_E"] = e;
            }

            return RedirectToAction(nameof(ListarUsuarios));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }      

    }
}
