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
        public int FuncionarioServicoId { get; set; }
        public FuncionarioServico FuncionarioServico { get; set; }
        public string PrecoOrdem { get; set; }
        public string DataRealizada { get; set; }
        public Paid Pago { get; set; }
        public string Descricao { get; set; }
        public string DataLimite { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }


        public Ordem()
        {
        }

        public Ordem(int clienteId, int funcionarioServicoId, string precoOrdem, string dataRealizada, string pago, string descricao, string dataLimite)
        {
            this.ClienteId = clienteId;
            this.FuncionarioServicoId = funcionarioServicoId;
            this.PrecoOrdem = precoOrdem;
            this.DataRealizada = dataRealizada;
            this.Pago = (Paid)Enum.Parse(typeof(Paid), pago);
            this.Descricao = descricao;
            this.DataLimite = dataLimite;
        }
    }
}