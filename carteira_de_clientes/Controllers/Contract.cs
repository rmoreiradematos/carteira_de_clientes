using System;
using System.Collections.Generic;

namespace carteira_de_clientes
{
    public class Contract
    {
        public static Models.Contract CadastrarContrato(
        string idCliente, string idUsuario, string idServico, string dateLimit, string dateDone, string dateContract)
        {
            int clientId = int.Parse(idCliente);
            int userId = int.Parse(idUsuario);
            int serviceId = int.Parse(idServico);

            Models.Client cliente = Models.Client.BuscarCliente(clientId);
            Models.User usuario = Models.User.BuscarUsuario(userId);
            Models.Service servico = Models.Service.BuscarServico(serviceId);

            return new Models.Contract(cliente.Id, usuario.Id, servico.Id, dateLimit, dateDone, dateContract);
        }

        public static Models.Contract ExcluirContrato(int id)
        {
            try
            {
                Models.Contract contrato = Models.Contract.BuscarContrato(id);
                if (contrato != null)
                {
                    throw new Exception("Contrato não cadastrado");
                }

                Models.Contract.ExcluirContrato(id);

                return contrato;
            }
            catch (System.Exception)
            {

                throw new Exception("Erro ao buscar contrato");
            }
        }

        public static List<Models.Contract> ListarContratos()
        {
            return Models.Contract.ListarContratos();
        }

        public static Models.Contract EditarContrato(int id, int clientId, int userId, int serviceId, string dateLimit, string dateDone, string dateContract)
        {
            Models.Contract contrato = Models.Contract.BuscarContrato(id);
            Models.Client cliente = Models.Client.BuscarCliente(clientId);
            Models.User usuario = Models.User.BuscarUsuario(userId);
            Models.Service servico = Models.Service.BuscarServico(serviceId);

            Models.Contract.EditarContrato(id, cliente.Id, usuario.Id, servico.Id, dateLimit, dateDone, dateContract);

            return contrato;
        }
    }
}