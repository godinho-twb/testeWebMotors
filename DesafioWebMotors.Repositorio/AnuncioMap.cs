using DesafioWebMotors.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioWebMotors.Infra.Repositorio
{
    public class AnuncioMap : IEntityTypeConfiguration<Anuncio>
    {
        public void Configure(EntityTypeBuilder<Anuncio> builder)
        {
            builder.ToTable("tb_AnuncioWebmotors");

            builder.HasKey("ID");

            builder.Property(c => c.ID)
                .HasColumnName("ID")
                .IsRequired()
                .UseSqlServerIdentityColumn();

            builder.Property(c => c.Marca)
                .HasColumnName("marca")
                .HasColumnType("varchar(45)")
                .HasMaxLength(45)
                .IsRequired();

            builder.Property(c => c.Modelo)
                .HasColumnName("modelo")
                .HasColumnType("varchar(45)")
                .HasMaxLength(45)
                .IsRequired();

            builder.Property(c => c.Versao)
                .HasColumnName("versao")
                .HasColumnType("varchar(45)")
                .HasMaxLength(45)
                .IsRequired();

            builder.Property(c => c.Ano)
                .HasColumnName("ano")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(c => c.Quilometragem)
                .HasColumnName("quilometragem")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(c => c.Observacao)
                .HasColumnName("observacao")
                .HasColumnType("text")
                .IsRequired();
        }
    }
}
