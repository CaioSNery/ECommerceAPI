using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ECommerceAPI.Dtos;
using ECommerceAPI.Entities;

namespace ECommerceAPI.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {



            CreateMap<Produto, ProdutoReadDTO>().ReverseMap();
            CreateMap<ProdutoCreateDTO, Produto>().ReverseMap();


            CreateMap<Categoria, CategoriaDTO>().ReverseMap();
            CreateMap<CategoriaCreateDTO, Categoria>().ReverseMap();


            CreateMap<Cliente, ClienteReadDTO>().ReverseMap();
            CreateMap<ClienteCreateDTO, Cliente>().ReverseMap();

            
            CreateMap<PedidoCreateDTO, Pedido>().ReverseMap();

            CreateMap<CarrinhoDTO, Carrinho>().ReverseMap();
            

        }
    }
}