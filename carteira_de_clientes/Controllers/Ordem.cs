using System;
namespace Carteira_De_Clientes.Controllers
{

    public class Ordem
    {
        public static Models.Cliente clienteCrud = new();
        public static Models.Ordem ordemCrud = new();
        public static Models.FuncionarioServico funcionarioServicoCrud = new();
        public static Models.Ordem CadastrarOrdem(string clienteId, string funcionarioServicoId, string precoOrdem, string dataRealizada, string pago, string descricao, string dataLimite)
        {
            if(clienteId == "" || funcionarioServicoId == "" || precoOrdem == "" || pago == "" || descricao == "" || dataLimite == "")
            {
                throw new Exception("Preencha todos os campos");
            }
            int intClienteId = int.Parse(clienteId);
            Models.Cliente cliente = clienteCrud.Get(intClienteId);

            int intFuncionarioServicoId = int.Parse(funcionarioServicoId);
            Models.FuncionarioServico funcionarioServico = funcionarioServicoCrud.Get(intFuncionarioServicoId);

            Models.Ordem ordem = new(intClienteId, intFuncionarioServicoId, precoOrdem, dataRealizada, pago, descricao, dataLimite);
            return ordemCrud.Cadastrar(ordem);
        }

        public static Models.Ordem GetOrdem(string id)
        {
            try
            {
                Models.Ordem ordem = ordemCrud.Get(int.Parse(id));

                return ordem;
            }
            catch (System.Exception e)
            {
                throw new Exception("Erro ao buscar Ordem: " + e.Message);
            }
        }

        public static IEnumerable<Models.Ordem> GetAllOrdens()
        {
            IEnumerable<Models.Ordem> ordens = ordemCrud.GetAll();

            return ordens;
        }

        public static Models.Ordem AlterarOrdem(string ordemId, string clienteId, string funcionarioServicoId, string precoOrdem, string dataRealizada, string pago, string descricao, string dataLimite)
        {

            try
            {
                int idInt = int.Parse(ordemId);
                Models.Ordem ordem = ordemCrud.Get(idInt);

                ordem.ClienteId = int.Parse(clienteId);
                ordem.FuncionarioServicoId = int.Parse(funcionarioServicoId);
                ordem.PrecoOrdem = precoOrdem;
                ordem.DataRealizada = dataRealizada;
                ordem.Pago = (Models.Generic.Paid)Enum.Parse(typeof(Models.Generic.Paid), pago);
                ordem.Descricao = descricao;
                ordem.DataLimite = dataLimite;
                ordemCrud.Alterar(ordem);

                return ordem;
            }
            catch (System.Exception e)
            {
                throw new Exception("Erro ao alterar Ordem: " + e.Message);
            }
        }

        public static Models.Ordem ExcluirOrdem(string id)
        {
            try
            {
                int idInt = int.Parse(id);
                Models.Ordem ordem = ordemCrud.Get(idInt);
                ordemCrud.Excluir(ordem.Id);

                return ordem;
            }
            catch (System.Exception e)
            {
                throw new Exception("Erro ao excluir Ordem: " + e.Message);
            }
        }
    }
}