using Business.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class MeuDbContext : DbContext
    {

        public MeuDbContext(DbContextOptions options) : base(options) { }

        //mapeamento dos dbset
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Criando uma garantia  de que serão criados com varchar 100
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            //Ele vai pegar o MeuDbContext vai buscar todas as entidade mapeadas no dbcontext
            //e vai buscar arquivos que herdem de IEntityTypeConfiguration - > para as "<entidades>"
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MeuDbContext).Assembly);

            //delete cascade desativando.
            //procurar por relções dentro do model builder pegando o tipo das entidades resultando em uma lista que atraves possuem relações com foreignkeys
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }

    }
}
