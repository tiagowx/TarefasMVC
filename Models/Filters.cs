using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TarefasMVC.Models
{
    public class Filters
    {
        public List<Tarefa> Tarefas;
        public string BuscaString;
        public EnumStatusTarefa Status;
        public DateTime Inicial;
        public DateTime Final;
    }
}