using Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mappings
{
    //mapeamento - mapeamento do tipo de coluna o tamanho de campo usando...
    public class PessoaMapping : IEntityTypeConfiguration<Pessoa>
    {
        //Inplementação da interface
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            //mapeando as propriedades Objetos no caso e que ele seja requerido
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("nvarchar(200)");

            builder.Property(p => p.Documento)
                .IsRequired()
                .HasColumnType("nvarchar(14)");

            builder.Property(p => p.Telefone)
                .IsRequired()
                .HasColumnType("nvarchar(13)");

            //Pessoa para endereço 1:1 - o fornecedor tem 1 endereço apenas 
            builder.HasOne(f => f.Endereco)
                .WithOne(e => e.Pessoa);

            //Defino nome da tabela
            builder.ToTable("Pessoas");

        }
    }
}
