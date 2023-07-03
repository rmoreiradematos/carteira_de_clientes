using System;
namespace Carteira_De_Clientes.Controllers
{

    public class Servico
    {
        public static Models.Servico servicoCrud = new();
        public static Models.Servico CadastrarCliente(string nome, string preco)
        {
            Models.Servico servico = new(nome, preco);
            return servicoCrud.Cadastrar(servico);
        }

        public static Models.Servico GetServico(string id)
        {
            try
            {
                Models.Servico servico = servicoCrud.Get(int.Parse(id));

                return servico;
            }
            catch (System.Exception e)
            {
                throw new Exception("Erro ao buscar Servico: " + e.Message);
            }
        }

        public static IEnumerable<Models.Servico> GetAllServicos()
        {
            IEnumerable<Models.Servico> servicos = servicoCrud.GetAll();

            return servicos;
        }

        public static Models.Servico AlterarServico(string servicoId, string nome, string preco)
        {

            try
            {
                int idInt = int.Parse(servicoId);
                Models.Servico servico = servicoCrud.Get(idInt);

                servico.Nome = nome;
                servico.Preco = preco;

                servicoCrud.Alterar(servico);

                return servico;
            }
            catch (System.Exception e)
            {
                throw new Exception("Erro ao alterar Servico: " + e.Message);
            }
        }

        public static Models.Servico ExcluirServico(string id)
        {
            try
            {
                int idInt = int.Parse(id);
                Models.Servico servico = servicoCrud.Get(idInt);
                servicoCrud.Excluir(servico.Id);

                return servico;
            }
            catch (System.Exception e)
            {
                throw new Exception("Erro ao excluir Servico: " + e.Message);
            }
        }
    }
}