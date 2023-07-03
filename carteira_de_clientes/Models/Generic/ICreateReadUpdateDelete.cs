using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carteira_De_Clientes.Models.Generic
{
    public interface ICreateReadUpdateDelete<T>
    {
        T Cadastrar(T obj);
        IEnumerable<T> GetAll();
        T Get(int id);
        T Alterar(T obj);
        void Excluir(int id);
    }
}