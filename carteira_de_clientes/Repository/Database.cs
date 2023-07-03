using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using MySql.Data.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore.Metadata;
using Carteira_De_Clientes.Models;
using MySql.Data.EntityFrameworkCore.Extensions;
using System.Data.SqlClient;
using System.Linq;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Pomelo.EntityFrameworkCore.MySql.Storage;
using MySqlConnector;


namespace Banco
{
    public class DataBase : DbContext
    {
        public DataBase() { }
        public DataBase(DbContextOptions<DataBase> options) : base(options) { }

        public DbSet<OrdemDeServico> OrdemDeServicos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Contrato> Contratos { get; set; }
        public DbSet<Ordem> Ordens { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        private string _connectionString = "Server=localhost;User Id=root;Database=senhas;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(_connectionString, ServerVersion.AutoDetect(_connectionString));
        }


    }
}