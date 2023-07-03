using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Carteira_De_Clientes.Models.Generic;

namespace Carteira_De_Clientes.Models
{
    public class Cliente : CreateReadUpdateDelete<Cliente>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }

        public Cliente()
        {
        }

        public Cliente(string nome, string endereco, string telefone)
        {
            this.Nome = nome;
            this.Endereco = endereco;
            this.Telefone = telefone;
        }
    }
}