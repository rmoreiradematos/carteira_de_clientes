using System;
using System.Collections.Generic;

namespace carteira_de_clientes
{

    public class Client
    {
        public static Models.Client CadastrarCliente(
            string nome,
            string telefone,
            string endereco
        )
        {
            return new Models.Client(nome, endereco, telefone);
        }

        public static Models.Client ExcluirCliente(int id)
        {

            try
            {
                Models.Client cliente = Models.Client.BuscarCliente(id);
                if (cliente != null)
                {
                    throw new Exception("Cliente não cadastrado");
                }

                Models.Client.ExcluirCliente(id);

                return cliente;
            }
            catch (System.Exception)
            {

                throw new Exception("Erro ao buscar cliente");
            }

        }

        public static List<Models.Client> ListarClientes()
        {
            return Models.Client.ListarClientes();
        }

        public static Models.Client EditarCliente(
            string id,
            string nome,
            string telefone,
            string endereco

        )
        {
            int idInt = int.Parse(id);
            Models.Client cliente = Models.Client.BuscarCliente(idInt);
            Models.Client.EditarCliente(idInt, nome, endereco, telefone);

            return cliente;
        }
    }
}