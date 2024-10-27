using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Ex_Dio_Tarefas.Context;
using Ex_Dio_Tarefas.Entities;
using Ex_Dio_Tarefas.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ex_Dio_Tarefas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefaController : ControllerBase
    {
        private readonly TarefaContext _context;
        public TarefaController(TarefaContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CriarTarefa(Tarefa tarefa)
        {
            _context.Add(tarefa);
            _context.SaveChanges();
            return Ok(tarefa);
        }

        //Get/Tarefa/{id}
        [HttpGet("{id}")]
        public IActionResult ObterTarefaPorId(int id)
        {
            var tarefa = _context.Tarefas.Find(id);
            if (tarefa == null)
                return NotFound("Tarefa não encontrada!");
            return Ok(tarefa);
        }

        //Put/Tarefa/{id}
        [HttpPut("{id}")]
        public IActionResult AtualizarTarefa(int id, Tarefa tarefa)
        {
            var tarefaDb = _context.Tarefas.Find(id);
            if (tarefaDb == null)
                return NotFound("Tarefa não encontrada!");
            tarefaDb.Titulo = tarefa.Titulo;
            tarefaDb.Descricao = tarefa.Descricao;
            tarefaDb.Data = tarefa.Data;
            tarefaDb.Status = tarefa.Status;
            _context.SaveChanges();
            return Ok(tarefa);
        }

        //Delete/Tarefa/{id}
        [HttpDelete("{id}")]
        public IActionResult ApagarTarefa(int id)
        {
            var tarefaDb = _context.Tarefas.Find(id);
            if (tarefaDb == null)
                return NotFound();
            _context.Remove(tarefaDb);
            _context.SaveChanges();
            return NoContent();
        }


        //Get/Tarefa/ObterTodos
        [HttpGet]
        public IActionResult ObterTodasTarefas()
        {
            var tarefas = _context.Tarefas.ToList();
            if (tarefas == null)
                return NotFound();
            return Ok(tarefas);
        }


        //Get/Tarefa/ObterPorTitulo
        [HttpGet("ObterPorTitulo")]
        public IActionResult ObterPorTitulo(string titulo)
        {
            var tarefa = _context.Tarefas.Where(x => x.Titulo.Contains(titulo));
            if (tarefa == null)
                return NotFound();
            return Ok(tarefa);
        }


        //Get/Tarefa/ObterPorDescrição
        [HttpGet("ObterPorDescrição")]
        public IActionResult ObterPorDescricao(string descricao)
        {
            var tarefa = _context.Tarefas.Where(x => x.Descricao.Contains(descricao));
            if (tarefa == null)
                return NotFound();
            return Ok(tarefa);
        }



        //Get/Tarefa/ObterPorStatus
        [HttpGet("ObterPorStatus")]
        public IActionResult ObterPorStatus(TarefaEnum status)
        {
            var tarefa = _context.Tarefas.Where(x => x.Status == status).ToList();
            if (!tarefa.Any())
                return NotFound("Nenhuma tarefa encontrada com o status especificado.");
            return Ok(tarefa);

        }


        //Get/Tarefa/ObterPorData
        [HttpGet("ObterPorData")]
        public IActionResult ObterPorData(DateTime data)
        {
            var tarefa = _context.Tarefas.Where(x => x.Data.Date == data.Date).ToList();
            if (!tarefa.Any())
                return NotFound("Nenhuma tarefa encontrada com o status especificado.");
            return Ok(tarefa);
        }

    }
}