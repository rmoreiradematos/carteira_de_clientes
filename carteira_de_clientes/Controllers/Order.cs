namespace carteira_de_clientes
{
  public class Order
  {
    public static Model.Order CadastrarOrdem(
      int contractId, int serviceId
    )
    {
      int idContratoInt = int.Parse(idContrato);
      Model.Contract contrato = Model.Contract.BuscarContrato(idContratoInt);

      int idServicoInt = int.Parse(idServico);
      Model.Servico servico = Model.Servico.BuscarServico(idServicoInt);
      return new Model.Order();
    }

    public static void ExcluirPedido(
      string id
    )
    {
      int idInt = int.Parse(id);
      Model.Order.ExcluirPedido(idInt);
    }

    public static List<Model.Order> ListarPedidos()
    {
      return Model.Order.ListarPedidos();
    }

    public static Model.Order EditarPedido(
      int contractId, int serviceId
    )
    {
     
      int idServiceId = int.Parse(serviceId);
      int idContratoInt = int.Parse(idContrato);

      return Model.Order.EditarPedido(idContratoInt, idServicoInt);
    }
  }
}