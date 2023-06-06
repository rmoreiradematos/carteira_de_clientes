using System;
using System.Collections.Generic;

namespace carteira_de_clientes
{
    public class Client
    {
        public static Model.Client CadastrarCliente(
            string nome,
            string cpf,
            string email,
            string telefone,
            string endereco,
            string cidade,
            string estado,
            string cep,
            string pais
        )
        {
            return new Model.Client(nome, cpf, email, telefone, endereco, cidade, estado, cep, pais);
        }

        public static Model.Client ExcluirCliente(
            string id
        )
        {
            int idInt = int.Parse(id);
            Model.Client.ExcluirCliente(idInt);
        }

        public static List<Model.Client> ListarClientes()
        {
            return Model.Client.ListarClientes();
        }

        public static Model.Client EditarCliente(
            string id,
            string nome,
            string cpf,
            string email,
            string telefone,
            string endereco,
            string cidade,
            string estado,
            string cep,
            string pais
        )
        {
            int idInt = int.Parse(id);
            return Model.Client.EditarCliente(idInt, nome, cpf, email, telefone, endereco, cidade, estado, cep, pais);
        }
    }

   
}
