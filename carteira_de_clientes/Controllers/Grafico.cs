using System;
using Banco;
using Microsoft.EntityFrameworkCore;

namespace Carteira_De_Clientes.Controllers
{

    public class Grafico
    {

        public static List<Carteira_De_Clientes.Models.Ordem> PagouMasOServicoNaoFoiRealizado()
        {
            using (var context = new DataBase())
            {
                var query = context.Ordens.FromSqlRaw("SELECT ordens.DataRealizado, ordens.Pago, ordens.DataLimite, clientes.Nome, funcionarios.Nome FROM Ordem inner join on clientes clientes.id = ordens.id inner join on funcionarioservicos funcionarioservicos.Id = ordens.FuncionarioServicoId inner join on funcionarios funcionarioservico.FuncionarioId = funcionarios.Id  WHERE Pago = 1 AND DataRealizada = ''").ToList();
                return query;
            }
        }

        public static void FoiRealizadoMasNaoPagou()
        {
            
        }

        public static void ClientesAAtender()
        {
            
        }
    }
}