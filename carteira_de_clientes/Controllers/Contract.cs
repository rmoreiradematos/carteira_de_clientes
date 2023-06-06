namespace carteira_de_clientes
{
  public class Contract
  {
    public static Model.Contract CadastrarContrato(
      int clientId, int userId, int serviceId, string dateLimit, string dateDone, string dateContract
    )
    {
      int idClienteInt = int.Parse(idCliente);
      Model.Client cliente = Model.Client.BuscarCliente(idClienteInt);

      int idUsuarioInt = int.Parse(idUsuario);
      Model.Usuario usuario = Model.Usuario.BuscarUsuario(idUsuarioInt);

      int idServicoInt = int.Parse(idServico);
      Model.Servico servico = Model.Servico.BuscarServico(idServicoInt);
      
      return new Model.Contract(cliente.Id, usuario.Id, servico.Id, dateLimit, dateDone, dateContract);
    }

    public static void ExcluirContrato(
      string id
    )
    {
      int idInt = int.Parse(id);
      Model.Contract.ExcluirContrato(idInt);
    }

    public static List<Model.Contract> ListarContratos()
    {
      return Model.Contract.ListarContratos();
    }

    public static Model.Contract EditarContract(
      int clientId, int userId, int serviceId, string dateLimit, string dateDone, string dateContract
    )
    {
      int idInt = int.Parse(id);
      Model.Contract contrato = Model.Contract.BuscarContrato(idInt);

      int idClienteInt = int.Parse(idCliente);
      Model.Client cliente = Model.Client.BuscarCliente(idClienteInt);

      int idUsuarioInt = int.Parse(idUsuario);
      Model.Usuario usuario = Model.Usuario.BuscarUsuario(idUsuarioInt);

      int idServicoInt = int.Parse(idServico);
      Model.Servico servico = Model.Servico.BuscarServico(idServicoInt);

      return Model.Contract.EditarContrato(idInt, cliente.Id, usuario.Id, servico.Id, dateLimit, dateDone, dateContract);
    }
  }
}