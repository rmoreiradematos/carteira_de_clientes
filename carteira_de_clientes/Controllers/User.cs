using System;
using System.Collections.Generic;
using Models;
namespace carteira_de_clientes
{
    public class User
    {
        public static Models.User CadastrarUsuario(string nome, string senha, string email, string role)
        {
            int intNome = int.Parse(nome);
            UserType userTypeRole = (UserType)Enum.Parse(typeof(UserType), role);
            return new Models.User(intNome, senha, email, userTypeRole);
        }

        public static Models.User ExcluirUsuario(int id)
        {
            try
            {
                Models.User user = Models.User.BuscarUsuario(id);
                if (user != null)
                {
                    throw new Exception("Usuário não cadastrado");
                }

                Models.User.ExcluirUsuario(id);

                return user;
            }
            catch (System.Exception)
            {

                throw new Exception("Erro ao buscar o usuário");
            }
        }

        public static List<Models.User> ListarUsuarios()
        {
            return Models.User.ListarUsuarios();
        }

        public static Models.User EditarUsuario(string id, string name, string password, string role)
        {
            int idInt = int.Parse(id);
            Models.User usuario = Models.User.BuscarUsuario(idInt);

            UserType userTypeRole = (UserType)Enum.Parse(typeof(UserType), role);
            Models.User.EditarUsuario(idInt, name, password, userTypeRole);

            return usuario;
        }
    }
}