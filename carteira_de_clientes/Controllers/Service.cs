namespace carteira_de_clientes
{
  public class Service
  {
    public static Model.Service CadastrarServico(
      string nome, string preco
    )
    {
      return new Model.Service(nome, preco);
    }

    public static void ExcluirServico(
      string id
    )
    {
      int idInt = int.Parse(id);
      Model.Service.ExcluirServico(idInt);
    }

    public static List<Model.Service> ListarServicos()
    {
      return Model.Service.ListarServicos();
    }

    public static Model.Service EditarServico(
      string id, string nome, string preco
    )
    {
      int idInt = int.Parse(id);
      return Model.Service.EditarServico(idInt, nome, preco);
    }
  }
}