using System;
namespace Carteira_De_Clientes.Controllers
{

    public class Order
    {
        public static Models.Cliente clienteCrud = new();
        public static Models.Servico servicoCrud = new();
        public static Models.Ordem ordemCrud = new();
        public static Models.Ordem CadastrarOrdem(string clienteId, string servicoId)
        {
            int intClienteId = int.Parse(clienteId);
            Models.Cliente cliente = clienteCrud.Get(intClienteId);

            int intServicoId = int.Parse(servicoId);
            Models.Servico servico = servicoCrud.Get(intServicoId);

            Models.Ordem ordem = new(cliente.Id, servico.Id);
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

        public static Models.Ordem AlterarOrdem(string ordemId, string clienteId, string servicoId)
        {

            try
            {
                int idInt = int.Parse(ordemId);
                Models.Ordem ordem = ordemCrud.Get(idInt);

                ordem.ClienteId = int.Parse(clienteId);
                ordem.ServicoId = int.Parse(servicoId);

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