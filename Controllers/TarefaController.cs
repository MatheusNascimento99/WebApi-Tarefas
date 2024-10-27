using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Ex_Dio_Tarefas.Context;
using Ex_Dio_Tarefas.Entities;
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
        public IActionResult Create(Tarefa tarefa)
        {
            _context.Add(tarefa);
            _context.SaveChanges();
            return Ok(tarefa);
        }

        //Get/Tarefa/{id}

        //Put/Tarefa/{id}

        //Delete/Tarefa/{id}

        //Get/Tarefa/ObterTodos

        //Get/Tarefa/ObterPorTitulo

        //Get/Tarefa/ObterPorData

        //Get/Tarefa/ObterPorStatus


        

    }
}