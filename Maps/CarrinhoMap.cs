using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ECommerceAPI.Maps
{
    public class CarrinhoMap : IEntityTypeConfiguration<Carrinho>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Carrinho> builder)
        {
            builder.ToTable("Carrinhos");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.QuantidadeProduto)
                .IsRequired()
                .HasColumnType("int");

            builder.HasOne(c => c.Cliente)
            .WithMany(cli => cli.Carrinhos)
            .HasForeignKey(c => c.ClienteId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Produto)
                .WithMany()
                .HasForeignKey(c => c.ProdutoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.Pedidos)
                .WithOne(p => p.Carrinho)
                .HasForeignKey(p => p.CarrinhoId)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
        
    }
