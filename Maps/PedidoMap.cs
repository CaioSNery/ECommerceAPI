using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.Maps
{
    public class PedidoMap : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedidos");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.DataPedido)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(p => p.Quantidade)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(p => p.ValorTotal)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.HasOne(p => p.Carrinho)
                .WithMany(c => c.Pedidos)
                .HasForeignKey(p => p.CarrinhoId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Cliente)
                .WithMany(c => c.Pedidos)
                .HasForeignKey(p => p.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}