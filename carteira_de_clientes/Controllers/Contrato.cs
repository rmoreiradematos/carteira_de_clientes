using System;
namespace Carteira_De_Clientes.Controllers
{

    public class Contrato
    {
        public static Models.Cliente clienteCrud = new();
        public static Models.Funcionario funcionarioCrud = new();
        public static Models.Servico servicoCrud = new();
        public static Models.Contrato contratoCrud = new();
        public static Models.Contrato CadastrarContrato(string clienteId, string funcionarioId, string servicoId, string dateLimit, string dateDone, string dateContract)
        {
            int intClienteId = int.Parse(clienteId);
            Models.Cliente cliente = clienteCrud.Get(intClienteId);

            int intFuncionarioId = int.Parse(funcionarioId);
            Models.Funcionario funcionario = funcionarioCrud.Get(intFuncionarioId);

            int intServicoId = int.Parse(servicoId);
            Models.Servico servico = servicoCrud.Get(intServicoId);

            Models.Contrato contrato = new(cliente.Id, funcionario.Id, servico.Id, dateLimit, dateDone, dateContract);
            return contratoCrud.Cadastrar(contrato);
        }

        public static Models.Contrato GetContrato(string id)
        {
            try
            {
                Models.Contrato contrato = contratoCrud.Get(int.Parse(id));

                return contrato;
            }
            catch (System.Exception e)
            {
                throw new Exception("Erro ao buscar Contrato: " + e.Message);
            }
        }

        public static IEnumerable<Models.Contrato> GetAllContratos()
        {
            IEnumerable<Models.Contrato> contratos = contratoCrud.GetAll();

            return contratos;
        }

        public static Models.Contrato AlterarContrato(string contratoId, string clienteId, string funcionarioId, string servicoId, string dateLimit, string dateDone, string dateContract)
        {

            try
            {
                int idInt = int.Parse(contratoId);
                Models.Contrato contrato = contratoCrud.Get(idInt);

                contrato.ClienteId = int.Parse(clienteId);
                contrato.FuncionarioId = int.Parse(funcionarioId);
                contrato.ServicoId = int.Parse(servicoId);
                contrato.DateLimit = dateLimit;
                contrato.DateDone = dateDone;
                contrato.DateContract = dateContract;

                contratoCrud.Alterar(contrato);

                return contrato;
            }
            catch (System.Exception e)
            {
                throw new Exception("Erro ao alterar Contrato: " + e.Message);
            }
        }

        public static Models.Contrato ExcluirContrato(string id)
        {
            try
            {
                int idInt = int.Parse(id);
                Models.Contrato contrato = contratoCrud.Get(idInt);
                contratoCrud.Excluir(contrato.Id);

                return contrato;
            }
            catch (System.Exception e)
            {
                throw new Exception("Erro ao excluir Contrato: " + e.Message);
            }
        }
    }
}