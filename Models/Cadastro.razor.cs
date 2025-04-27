using System;
using Microsoft.AspNetCore.Components;
using ToDoList.Models;
using System.Text.RegularExpressions;


namespace ToDoList.Pages
{
    public partial class Cadastro : ComponentBase
    {
        private List<Usuario> usuarios = new();
        private string nome;
        private string nomeUsuario;
        private string senha;
        private string msgErro;
        private string msgSucesso;

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        private async Task CriarNovoUsuario()
        {
            msgErro = string.Empty;
            msgSucesso = string.Empty;

            // Validações
            if (string.IsNullOrWhiteSpace(nomeUsuario))
            {
                msgErro = "O nome de usuário não pode ser vazio.";
            }
            else if (nomeUsuario.Length < 7 || nomeUsuario.Length > 15)
            {
                msgErro = "O nome de usuário deve ter entre 7 e 15 caracteres.";
            }
            else if (usuarios.Any(u => u.NomeUsuario == nomeUsuario))
            {
                msgErro = "O nome de usuário já existe.";
            }
            else if (!SenhaValida(senha))
            {
                msgErro = "A senha deve conter letras, pelo menos um número e pelo menos um caractere especial.";
            }

            // Se houver erro, retorna e não faz nada
            if (!string.IsNullOrEmpty(msgErro))
            {
                return;
            }

            // Cria o novo usuário e adiciona à lista
            var novoUsuario = new Usuario { Nome = nome, NomeUsuario = nomeUsuario, Senha = senha };
            usuarios.Add(novoUsuario);

            // Mensagem de sucesso
            msgSucesso = "Usuário criado com sucesso! Você será redirecionado para o login!";

            // Espera 7 segundos e redireciona para a página de login
            await Task.Delay(7000); // Espera 7 segundos
            NavigationManager.NavigateTo("/login"); // Redireciona para a página de login

            // Limpa os campos
            nome = string.Empty;
            nomeUsuario = string.Empty;
            senha = string.Empty;
        }

        private bool SenhaValida(string senha)
        {
            if (string.IsNullOrEmpty(senha))
            {
                return false;
            }

            var regex = new Regex(@"^(?=.*[a-zA-Z])(?=.*\d)(?=.*[!@#$%^&*()\-_=+\[\]{}|\\:;""'<>,.?/~`]).{6,}$");
            return regex.IsMatch(senha);
        }
    }
}
