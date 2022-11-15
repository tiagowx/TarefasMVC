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
    public class TarefaController : Controller
    {

        private readonly OrganizadorContext _context;

        public TarefaController(OrganizadorContext context)
        {
            _context = context;
        }

        
        public IActionResult Index()
        {
            Filters Search = new Filters();
            Search.Tarefas = _context.Tarefas.ToList();

            return View(Search);
        }
        
        [HttpPost]
        public IActionResult Buscar(Filters filtros)
        {
            if(!Models.IsValid)
                return null;
            
            Filters Busca = new Filters();

            

        }

        public IActionResult Criar()
        {            
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Tarefa tarefa)
        {
            if (!ModelState.IsValid){
                return View();
            }

            // TODO: Adicionar a tarefa recebida no EF e salvar as mudanças (save changes)
            _context.Tarefas.Add(tarefa);
            _context.SaveChanges();
            
            return RedirectToAction("Index");
        } 

        public IActionResult Editar(int id)
        {
            var tarefaBanco = _context.Tarefas.Find(id);
            return View(tarefaBanco);
        }

        [HttpPost]
        public IActionResult Editar(Tarefa tarefa)
        {
            if (!ModelState.IsValid){
                return View();
            }

            var tarefaBanco = _context.Tarefas.Find(tarefa.Id);

            tarefaBanco.Titulo = tarefa.Titulo;
            tarefaBanco.Descricao = tarefa.Descricao;
            tarefaBanco.Data = tarefa.Data;
            tarefaBanco.Status = tarefa.Status;

            // TODO: Adicionar a tarefa recebida no EF e salvar as mudanças (save changes)
            _context.Tarefas.Update(tarefaBanco);
            _context.SaveChanges();
            
            return RedirectToAction("Index");
        } 

        public IActionResult Deletar(int id)
        {
            var tarefaBanco = _context.Tarefas.Find(id);
            return View(tarefaBanco);
        }

        [HttpPost]
        public IActionResult Deletar(Tarefa tarefa)
        {
            var tarefaBanco = _context.Tarefas.Find(tarefa.Id);
            
            if(tarefaBanco == null)
                return View();

            _context.Tarefas.Remove(tarefaBanco);
            _context.SaveChanges(); 

            return RedirectToAction(nameof(Index));          
        }
    }
}