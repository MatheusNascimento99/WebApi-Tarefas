using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ex_Dio_Tarefas.Enum;

namespace Ex_Dio_Tarefas.Entities
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = default!;
        public string Descricao { get; set; } = default!;
        public DateTime Data { get; set; } = default!;
        public TarefaEnum Status { get; set; } = default!;
    }
}