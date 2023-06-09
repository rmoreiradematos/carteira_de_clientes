using System;
using System.Collections.Generic;
using Models;
namespace carteira_de_clientes
{
    public class User
    {
        public static Models.User CadastrarUsuario(string nome, string senha, string email, UserType role)
        {
            return new Models.User(nome, senha, email, role);
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

                Models.User.ExcluirUser(id);

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

        public static Models.User EditarUsuario(string id, string nome, string email, string senha, UserType role)
        {
            int idInt = int.Parse(id);
            Models.User usuario = Models.User.BuscarUsuario(idInt);

            Models.User.EditarUsuario(idInt, nome, senha, email, role);

            return usuario;
        }
    }
}