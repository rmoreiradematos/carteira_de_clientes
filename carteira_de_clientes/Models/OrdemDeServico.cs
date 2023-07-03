using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Carteira_De_Clientes.Models.Generic;

namespace Carteira_De_Clientes.Models
{
    public class OrdemDeServico : CreateReadUpdateDelete<OrdemDeServico>
    {
        public int Id { get; set; }
        public Dones Done { get; set; }
        public int FuncionarioId { get; set; }
        public Funcionario Funcionario { get; set; }
        public int ServicoId { get; set; }
        public Servico Servico { get; set; }

        public OrdemDeServico()
        {
        }

        public OrdemDeServico(string done, int funcionarioId, int servicoId)
        {
            Done = (Dones)Enum.Parse(typeof(Dones), done);
            this.FuncionarioId = FuncionarioId;
            this.ServicoId = servicoId;
        }
    }
}
