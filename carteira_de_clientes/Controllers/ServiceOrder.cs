namespace carteira_de_clientes
{
  public class ServiceOrder
  {
    public static Model.ServiceOrder CadastrarOrdemDeServico(
      int clientId, int userId, int serviceId, string dateLimit, string dateDone, string dateServiceOrder
    )
    {
      int idClienteInt = int.Parse(idCliente);
      Model.Client cliente = Model.Client.BuscarCliente(idClienteInt);

      int idUsuarioInt = int.Parse(idUsuario);
      Model.Usuario usuario = Model.Usuario.BuscarUsuario(idUsuarioInt);

      int idServicoInt = int.Parse(idServico);
      Model.Servico servico = Model.Servico.BuscarServico(idServicoInt);
      
      return new Model.ServiceOrder(cliente.Id, usuario.Id, servico.Id, dateLimit, dateDone, dateServiceOrder);
    }

    public static void ExcluirOrdemDeServico(
      string id
    )
    {
      int idInt = int.Parse(id);
      Model.ServiceOrder.ExcluirOrdemDeServico(idInt);
    }

    public static List<Model.ServiceOrder> ListarOrdensDeServico()
    {
      return Model.ServiceOrder.ListarOrdensDeServico();
    }

    public static Model.ServiceOrder EditarOrdemDeServico(
      int clientId, int userId, int serviceId, string dateLimit, string dateDone, string dateServiceOrder
    )
    {
      int idInt = int.Parse(id);
      Model.ServiceOrder ordemDeServico = Model.ServiceOrder.BuscarOrdemDeServico(idInt);

      int idClienteInt = int.Parse(idCliente);
      Model.Client cliente = Model.Client.BuscarCliente(idClienteInt);

      int idUsuarioInt = int.Parse(idUsuario);
      Model.Usuario usuario = Model.Usuario.BuscarUsuario(idUsuarioInt);

      int idServicoInt = int.Parse(idServico);
      Model.Servico servico = Model.Servico.BuscarServico(idServicoInt);

      return Model.ServiceOrder.EditarOrdemDeServico(idInt, cliente.Id, usuario.Id, servico.Id, dateLimit, dateDone, dateServiceOrder);
    }
  }
}