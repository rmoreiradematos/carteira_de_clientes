using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Carteira_De_Clientes.Models.Generic;

namespace Carteira_De_Clientes.Models
{
    public class Ordem : CreateReadUpdateDelete<Ordem>
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public int ServicoId { get; set; }
        public Servico Servico { get; set; }

        public Ordem()
        {
        }

        public Ordem(int clienteId, int servicoId)
        {
            this.ClienteId = clienteId;
            this.ServicoId = servicoId;
        }
    }
}