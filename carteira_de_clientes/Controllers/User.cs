namespace carteira_de_clientes
{
  public class User
  {
    public static Model.User CadastrarUsuario(
      string nome, string email, string senha
    )
    {
      return new Model.User(nome, email, senha);
    }

    public static void ExcluirUsuario(
      string id
    )
    {
      int idInt = int.Parse(id);
      Model.User.ExcluirUsuario(idInt);
    }

    public static List<Model.User> ListarUsuarios()
    {
      return Model.User.ListarUsuarios();
    }

    public static Model.User EditarUsuario(
      string id, string nome, string email, string senha
    )
    {
      int idInt = int.Parse(id);
      return Model.User.EditarUsuario(idInt, nome, email, senha);
    }
  }
}