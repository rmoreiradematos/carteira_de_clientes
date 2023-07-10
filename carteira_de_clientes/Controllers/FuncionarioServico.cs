using System;
namespace Carteira_De_Clientes.Controllers
{

    public class FuncionarioServico
    {
        public static Models.FuncionarioServico funcionarioServicoCrud = new();
        public static Models.Funcionario funcionarioCrud = new();
        public static Models.Servico servicoCrud = new();
        public static Models.FuncionarioServico CadastrarFuncionarioServico(string funcionarioId, string servicoId)
        {
            try{

                int intFuncionarioId = int.Parse(funcionarioId);
                Models.Funcionario funcionario = funcionarioCrud.Get(intFuncionarioId);

                int intServicoId = int.Parse(servicoId);
                Models.Servico servico = servicoCrud.Get(intServicoId);

                Models.FuncionarioServico funcionarioServico = new(intFuncionarioId, intServicoId);
                return funcionarioServicoCrud.Cadastrar(funcionarioServico);
            }catch(Exception e)
            {
                throw new Exception("Funcionario servico failed to parse");
            }
        }

        public static Models.FuncionarioServico GetFuncionarioServico(string id)
        {
            try
            {
                Models.FuncionarioServico funcionarioServico = funcionarioServicoCrud.Get(int.Parse(id));

                return funcionarioServico;
            }
            catch (System.Exception e)
            {
                throw new Exception("Erro ao buscar o Responsável pelo serviço: " + e.Message);
            }
        }

        public static IEnumerable<Models.FuncionarioServico> GetAllFuncionarioServicos()
        {
            IEnumerable<Models.FuncionarioServico> funcionarioServicos = funcionarioServicoCrud.GetAll();

            return funcionarioServicos;
        }

        public static Models.FuncionarioServico AlterarFuncionarioServico(string funcionarioServicoId, string funcionarioId, string servicoId)
        {

            try
            {
                int idInt = int.Parse(funcionarioServicoId);
                Models.FuncionarioServico funcionarioServico = funcionarioServicoCrud.Get(idInt);

                funcionarioServico.FuncionarioId = int.Parse(funcionarioId);
                funcionarioServico.ServicoId = int.Parse(servicoId);

                funcionarioServicoCrud.Alterar(funcionarioServico);

                return funcionarioServico;
            }
            catch (System.Exception e)
            {
                throw new Exception("Erro ao alterar o serviço do usuário: " + e.Message);
            }
        }

        public static Models.FuncionarioServico ExcluirFuncionarioServico(string id)
        {
            try
            {
                int idInt = int.Parse(id);
                Models.FuncionarioServico funcionarioServico = funcionarioServicoCrud.Get(idInt);
                funcionarioServico.Excluir(funcionarioServico.Id);

                return funcionarioServico;
            }
            catch (System.Exception e)
            {
                throw new Exception("Erro ao excluir esta atribuição: " + e.Message);
            }
        }
    }
}