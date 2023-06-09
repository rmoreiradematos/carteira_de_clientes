using System;
using System.Collections.Generic;

namespace carteira_de_clientes
{
    public class Service
    {
        public static Models.Service CadastrarServico(string nome, string preco)
        {
            return new Models.Service(nome, preco);
        }

        public static Models.Service ExcluirServico(int id)
        {
            try
            {
                Models.Service service = Models.Service.BuscarServico(id);
                if (service != null)
                {
                    throw new Exception("Serviço não cadastrado");
                }

                Models.Service.ExcluirServico(id);

                return service;
            }
            catch (System.Exception)
            {

                throw new Exception("Erro ao buscar serviço");
            }
        }

        public static List<Models.Service> ListarServicos()
        {
            return Models.Service.ListarServicos();
        }

        public static Models.Service EditarServico(string id, string nome, string preco)
        {
            int idInt = int.Parse(id);
            Models.Service service = Models.Service.BuscarServico(idInt);
            Models.Service.EditarService(idInt, nome, preco);

            return service;
        }
    }
}