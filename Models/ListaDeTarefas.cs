using System;
using System.Collections.Generic;

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
