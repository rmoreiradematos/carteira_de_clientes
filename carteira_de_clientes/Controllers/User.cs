using System;
using System.Security.Cryptography;
using System.Text;

namespace Carteira_De_Clientes.Controllers
{
    public class User
    {
        public static Models.Funcionario funcionarioCrud = new();

        public static Models.Funcionario CadastrarFuncionario(string nome, string senha, string email, string role, string salario)
        {
            Models.Funcionario funcionario = new(nome, Controllers.Login.GenerateHashCode(StringToInt(senha)).ToString(), email, role, double.Parse(salario));
            return funcionarioCrud.Cadastrar(funcionario);
        }

        public static int StringToInt(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                int result = BitConverter.ToInt32(hashBytes, 0);
                return result;
            }
        }

        public static IEnumerable<Models.Funcionario> GetAllFuncionarios()
        {
            IEnumerable<Models.Funcionario> funcionario = funcionarioCrud.GetAll();

            return funcionario;
        }

        public static Models.Funcionario GetFuncionario(string id)
        {
            try
            {
                int idInt = int.Parse(id);
                Models.Funcionario funcionario = funcionarioCrud.Get(idInt);

                return funcionario;
            }
            catch (System.Exception e)
            {
                throw new Exception("Erro ao buscar Funcionario: " + e.Message);
            }
        }

        public static Models.Funcionario GetFuncionarioByEmail(string email)
        {
            Models.Funcionario funcionario = funcionarioCrud.GetAll().FirstOrDefault(x => x.Email == email) ?? throw new Exception("Funcionario não encontrado");
            return funcionario;
        }

        public static Models.Funcionario AlterarFuncionario(string funcionarioId, string nome, string email, string role, string salario)
        {
            try
            {
                int idInt = int.Parse(funcionarioId);
                Models.Funcionario funcionario = funcionarioCrud.Get(idInt);

                funcionario.Nome = nome;
                funcionario.Email = email;
                funcionario.Role = (Models.Generic.Roles)Enum.Parse(typeof(Models.Generic.Roles), role);
                funcionario.Salario = Double.Parse(salario);

                funcionarioCrud.Alterar(funcionario);

                return funcionario;
            }
            catch (System.Exception e)
            {
                throw new Exception("Erro ao alterar Funcionario: " + e.Message);
            }
        }

        public static Models.Funcionario ExcluirFuncionario(string id)
        {
            try
            {
                int idInt = int.Parse(id);
                Models.Funcionario funcionario = funcionarioCrud.Get(idInt);
                funcionarioCrud.Excluir(idInt);

                return funcionario;
            }
            catch (System.Exception e)
            {
                throw new Exception("Erro ao excluir Funcionario: " + e.Message);
            }
        }
    }
}