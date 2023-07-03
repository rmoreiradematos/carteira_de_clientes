using System;
namespace Carteira_De_Clientes.Controllers
{

    public class ServiceOrder
    {
        public static Models.OrdemDeServico ordemDeServicoCrud = new();
        public static Models.Funcionario funcionarioCrud = new();
        public static Models.Servico servicoCrud = new();
        public static Models.OrdemDeServico CadastrarContrato(string done, string funcionarioId, string servicoId)
        {
            int intFuncionarioId = int.Parse(funcionarioId);
            Models.Funcionario funcionario = funcionarioCrud.Get(intFuncionarioId);

            int intServicoId = int.Parse(servicoId);
            Models.Servico servico = servicoCrud.Get(intServicoId);

            Models.OrdemDeServico ordemDeServico = new(done, funcionario.Id, servico.Id);
            return ordemDeServicoCrud.Cadastrar(ordemDeServico);
        }

        public static Models.OrdemDeServico GetOrdemDeServico(string id)
        {
            try
            {
                Models.OrdemDeServico ordemDeServico = ordemDeServicoCrud.Get(int.Parse(id));

                return ordemDeServico;
            }
            catch (System.Exception e)
            {
                throw new Exception("Erro ao buscar Ordem de Servico: " + e.Message);
            }
        }

        public static IEnumerable<Models.OrdemDeServico> GetAllOrdemDeServicos()
        {
            IEnumerable<Models.OrdemDeServico> ordemDeServicos = ordemDeServicoCrud.GetAll();

            return ordemDeServicos;
        }

        public static Models.OrdemDeServico AlterarOrdemDeServico(string ordemDeServicoId ,string done, string funcionarioId, string servicoId)
        {

            try
            {
                int idInt = int.Parse(ordemDeServicoId);
                Models.OrdemDeServico ordemDeServico = ordemDeServicoCrud.Get(idInt);


                ordemDeServico.FuncionarioId = int.Parse(funcionarioId);
                ordemDeServico.ServicoId = int.Parse(servicoId);
                ordemDeServico.Done = (Models.Generic.Dones)Enum.Parse(typeof(Models.Generic.Dones), done);

                ordemDeServicoCrud.Alterar(ordemDeServico);

                return ordemDeServico;
            }
            catch (System.Exception e)
            {
                throw new Exception("Erro ao alterar Ordem de Servico: " + e.Message);
            }
        }

        public static Models.OrdemDeServico ExcluirOrdemDeServico(string id)
        {
            try
            {
                int idInt = int.Parse(id);
                Models.OrdemDeServico ordemDeServico = ordemDeServicoCrud.Get(idInt);
                ordemDeServico.Excluir(ordemDeServico.Id);

                return ordemDeServico;
            }
            catch (System.Exception e)
            {
                throw new Exception("Erro ao excluir Ordem de Servico: " + e.Message);
            }
        }
    }
}