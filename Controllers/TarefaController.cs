using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TarefasMVC.Context;
using TarefasMVC.Models;

namespace TarefasMVC.Controllers
{
    [Route("[controller]")]
    public class TarefaController : Controller
    {

        private readonly OrganizadorContext _context;

        public TarefaController(OrganizadorContext context)
        {
            _context = context;
        }

        
        public IActionResult Index()
        {
            var tarefas = _context.Tarefas.ToList();

            return View(tarefas);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Tarefa tarefa) 
        {
            if (tarefa == null)
            { 
                return View();
            }

            _context.Tarefas.Add(tarefa);
            _context.SaveChanges();
            
            return RedirectToAction("Index");
        } 
    }
}