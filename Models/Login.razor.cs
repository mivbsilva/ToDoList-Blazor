using System;
using Microsoft.AspNetCore.Components;
using ToDoList.Models;
using System.Text.RegularExpressions;


namespace ToDoList.Pages
{
    public partial class Login : ComponentBase
    {
        private string msgErro;

        private void efetuarLogin()
        {
            msgErro = string.Empty;
        }       
    }
}
