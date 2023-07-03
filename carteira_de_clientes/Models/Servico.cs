using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Carteira_De_Clientes.Models.Generic;

namespace Carteira_De_Clientes.Models
{
    public class Servico : CreateReadUpdateDelete<Servico>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Preco { get; set; }

        public Servico()
        {
        }

        public Servico(string nome, string preco)
        {
            this.Nome = nome;
            this.Preco = preco;
        }
    }
}