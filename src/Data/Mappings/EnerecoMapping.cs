using Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings
{
    public class EnerecoMapping : IEntityTypeConfiguration<Endereco>
    {
        //Inplementação da interface
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            //mapeando as propriedades Objetos no caso e que ele seja requerido
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Logradouro)
                .IsRequired()
                .HasColumnType("nvarchar(200)");

            builder.Property(p => p.Numero)
                .IsRequired()
                .HasColumnType("nvarchar(50)");

            builder.Property(p => p.Cep)
                .IsRequired()
                .HasColumnType("nvarchar(8)");

            builder.Property(p => p.Complemento)
                .IsRequired()
                .HasColumnType("nvarchar(200)");

            builder.Property(p => p.Bairro)
                .IsRequired()
                .HasColumnType("nvarchar(100)");

            builder.Property(p => p.Cidade)
                .IsRequired()
                .HasColumnType("nvarchar(100)");

            builder.Property(p => p.Estado)
                .IsRequired()
                .HasColumnType("nvarchar(50)");


            //Defino nome da tabela
            builder.ToTable("Enderecos");
        }

    }
}
