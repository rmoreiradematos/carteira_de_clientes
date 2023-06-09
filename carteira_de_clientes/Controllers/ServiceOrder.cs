using System;
using System.Collections.Generic;

namespace carteira_de_clientes
{
    public class ServiceOrder
    {
        public static Models.ServiceOrder CadastrarServicoOrdem(bool done, string userId, string serviceId)
        {
            // Models.ServiceOrder feito = Models.ServiceOrder.BuscarServicoOrdem(done);

            int idUsuarioInt = int.Parse(userId);
            Models.User usuario = Models.User.BuscarUsuario(idUsuarioInt);

            int idServicoInt = int.Parse(serviceId);
            Models.Service servico = Models.Service.BuscarServico(idServicoInt);

            return new Models.ServiceOrder(done, usuario.Id, servico.Id);
        }

        public static Models.ServiceOrder ExcluirOrdemDeServico(int id)
        {
            try
            {
                Models.ServiceOrder serviceOrder = Models.ServiceOrder.BuscarServicoOrdem(id);
                if (serviceOrder != null)
                {
                    throw new Exception("Ordem de serviço não cadastrada");
                }

                Models.ServiceOrder.ExcluirServicoOrdem(id);

                return serviceOrder;
            }
            catch (System.Exception)
            {

                throw new Exception("Erro ao buscar Ordem de serviço");
            }
        }

        public static List<Models.ServiceOrder> ListarOrdensDeServico()
        {
            return Models.ServiceOrder.ListarServicoOrdens();
        }

        public static Models.ServiceOrder EditarServicoOrdem(string id, bool done, string userId, string serviceId)
        {
            int idInt = int.Parse(id);
            Models.ServiceOrder serviceOrder = Models.ServiceOrder.BuscarServicoOrdem(idInt);

            int idUsuarioInt = int.Parse(userId);
            Models.ServiceOrder ordemDeServico = Models.ServiceOrder.BuscarServicoOrdem(idUsuarioInt);

            int idServicoInt = int.Parse(serviceId);
            Models.Service servico = Models.Service.BuscarServico(idServicoInt);

            Models.ServiceOrder.EditarServicoOrdem(idInt, done, ordemDeServico.Id, servico.Id);

            return serviceOrder;
        }
    }
}