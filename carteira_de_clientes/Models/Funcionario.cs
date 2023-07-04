using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Carteira_De_Clientes.Models.Generic;

namespace Carteira_De_Clientes.Models
{

    public class Funcionario : CreateReadUpdateDelete<Funcionario>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public Roles Funcao { get; set; }
        public double Salario { get; set; }

        public Funcionario()
        {
        }
        public Funcionario(string nome, string senha, string email, string funcao, double salario)
        {
            this.Nome = nome;
            this.Senha = senha;
            this.Email = email;
            this.Funcao = (Roles)Enum.Parse(typeof(Roles), funcao);
            this.Salario = salario;
        }
    }
}