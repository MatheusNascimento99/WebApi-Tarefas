using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ex_Dio_Tarefas.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ex_Dio_Tarefas.Context
{
    public class TarefaContext : DbContext
    {
        public TarefaContext(DbContextOptions<TarefaContext> options) : base(options)
        {

        }

        public DbSet<Tarefa> Tarefas { get; set; }
    }
}