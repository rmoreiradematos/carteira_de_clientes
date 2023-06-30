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
        public Roles Role { get; set; }
        public double Salario { get; set; }

        public Funcionario()
        {
        }
        public Funcionario(string nome, string senha, string email, string role, double salario)
        {
            this.Nome = nome;
            this.Senha = senha;
            this.Email = email;
            Role = (Roles)Enum.Parse(typeof(Roles), role);
            Salario = salario;
        }
    }
}