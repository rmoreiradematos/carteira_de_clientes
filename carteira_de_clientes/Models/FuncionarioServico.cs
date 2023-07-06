using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Carteira_De_Clientes.Models.Generic;

namespace Carteira_De_Clientes.Models
{
    public class FuncionarioServico : CreateReadUpdateDelete<FuncionarioServico>
    {
        public int Id { get; set; }
        public int FuncionarioId { get; set; }
        public Funcionario Funcionario { get; set; }
        public int ServicoId { get; set; }
        public Servico Servico { get; set; }

        public FuncionarioServico()
        {
        }

        public FuncionarioServico(int funcionarioId, int servicoId)
        {
            this.FuncionarioId = funcionarioId;
            this.ServicoId = servicoId;
        }
    }
}
