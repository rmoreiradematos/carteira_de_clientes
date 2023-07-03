using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Carteira_De_Clientes.Models.Generic;

namespace Carteira_De_Clientes.Models
{
    public class Contrato : CreateReadUpdateDelete<Contrato>
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public int FuncionarioId { get; set; }
        public Funcionario Funcionario { get; set; }
        public int ServicoId { get; set; }
        public Servico Servico { get; set; }
        public string DateLimit { get; set; }
        public string DateDone { get; set; }
        public string DateContract { get; set; }

        public Contrato()
        {
        }

        public Contrato(int clienteId, int funcionarioId, int servicoId, string dateLimit, string dateDone, string dateContract)
        {
            this.ClienteId = clienteId;
            this.FuncionarioId = funcionarioId;
            this.ServicoId = servicoId;
            this.DateLimit = dateLimit;
            this.DateDone = dateDone;
            this.DateContract = dateContract;
        }

    }

}