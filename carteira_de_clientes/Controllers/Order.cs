using System;
using System.Collections.Generic;

namespace carteira_de_clientes
{
    public class Order
    {
        public static Models.Order CadastrarOrdem(string contractId, string serviceId)
        {
            int idContratoInt = int.Parse(contractId);
            Models.Contract contrato = Models.Contract.BuscarContrato(idContratoInt);

            int idServicoInt = int.Parse(serviceId);
            Models.Service servico = Models.Service.BuscarServico(idServicoInt);

            return new Models.Order(idContratoInt, idServicoInt);
        }

        public static Models.Order ExcluirOrder(int id)
        {
            try
            {
                Models.Order ordem = Models.Order.BuscarOrdem(id);
                if (ordem != null)
                {
                    throw new Exception("Ordem não cadastrada");
                }

                Models.Order.ExcluirOrdem(id);

                return ordem;
            }
            catch (System.Exception)
            {

                throw new Exception("Erro ao buscar ordem");
            }
        }


        public static List<Models.Order> ListarOrdens()
        {
            return Models.Order.ListarOrders();
        }

        public static Models.Order EditarOrdem(string id, string clientId, string serviceId)
        {
            int idInt = int.Parse(id);
            int clientIdInt = int.Parse(clientId);
            int serviceIdInt = int.Parse(serviceId);
            Models.Order order = Models.Order.BuscarOrdem(idInt);

            Models.Order.EditarOrdem(idInt, clientIdInt, serviceIdInt);

            return order;
        }
    }
}