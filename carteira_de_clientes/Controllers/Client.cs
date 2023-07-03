using System;
namespace Carteira_De_Clientes.Controllers
{

    public class Client
    {
        public static Models.Cliente clienteCrud = new();
        public static Models.Cliente CadastrarCliente(string nome, string telefone, string endereco)
        {
            Models.Cliente cliente = new(nome, telefone, endereco);
            return clienteCrud.Cadastrar(cliente);
        }

        public static Models.Cliente GetCliente(string id)
        {
            try
            {
                Models.Cliente cliente = clienteCrud.Get(int.Parse(id));

                return cliente;
            }
            catch (System.Exception e)
            {
                throw new Exception("Erro ao buscar Cliente: " + e.Message);
            }
        }

        public static IEnumerable<Models.Cliente> GetAllClientes()
        {
            IEnumerable<Models.Cliente> clientes = clienteCrud.GetAll();

            return clientes;
        }

        public static Models.Cliente AlterarCliente(string clienteId, string nome, string telefone, string endereco)
        {

            try
            {
                int idInt = int.Parse(clienteId);
                Models.Cliente cliente = clienteCrud.Get(idInt);

                cliente.Nome = nome;
                cliente.Telefone = telefone;
                cliente.Endereco = endereco;

                clienteCrud.Alterar(cliente);

                return cliente;
            }
            catch (System.Exception e)
            {
                throw new Exception("Erro ao alterar Cliente: " + e.Message);
            }
        }

        public static Models.Cliente ExcluirCliente(string id)
        {
            try
            {
                int idInt = int.Parse(id);
                Models.Cliente cliente = clienteCrud.Get(idInt);
                clienteCrud.Excluir(cliente.Id);

                return cliente;
            }
            catch (System.Exception e)
            {
                throw new Exception("Erro ao excluir Cliente: " + e.Message);
            }
        }
    }
}