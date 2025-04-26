using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Models
{
    public class ListaDeTarefas
    {
        public string Nome { get; set; }
        public List<string> Tarefas { get; set; }


        public ListaDeTarefas()
        {
            Tarefas = new List<string>();
        }    
    }
}