using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ECommerceAPI.Data;
using ECommerceAPI.Dtos;
using ECommerceAPI.Entities;
using ECommerceAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.Services
{
    public class ClienteService : IClienteService
    {

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ClienteService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ClienteReadDTO> BuscarClienteByIdAsync(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return null;
            }
            return _mapper.Map<ClienteReadDTO>(cliente);

        }

        public async Task<ClienteReadDTO> CriarClienteAsync(ClienteCreateDTO clienteCreateDTO)
        {
            var cliente = _mapper.Map<Cliente>(clienteCreateDTO);
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return _mapper.Map<ClienteReadDTO>(cliente);
            
        }

        public async Task<bool> DeleteClienteAsync(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)return false;
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<IEnumerable<ClienteReadDTO>> ListarClientesAsync()
        {
            var clientes = await _context.Clientes.ToListAsync();
            return _mapper.Map<IEnumerable<ClienteReadDTO>>(clientes);
            
        }

        public async Task<ClienteReadDTO> UpdateClienteAsync(int id, ClienteCreateDTO clienteUpdateDTO)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return null;
            }
            _mapper.Map(clienteUpdateDTO, cliente);
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
            return _mapper.Map<ClienteReadDTO>(cliente);
            
        }
    }
}