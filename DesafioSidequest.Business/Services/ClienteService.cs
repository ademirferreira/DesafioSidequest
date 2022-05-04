using System;
using System.Linq;
using System.Threading.Tasks;
using DesafioSidequest.Business.Interfaces;
using DesafioSidequest.Business.Models;

namespace DesafioSidequest.Business.Services
{
    public class ClienteService : BaseService, IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository, INotificador notificador) : base(notificador)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<bool> Adicionar(Cliente cliente)
        {
            if (_clienteRepository.Buscar(c => c.Documento == cliente.Documento).Result.Any())
            {
                Notificar("Já existe um cliente com esse documento");
                return false;
            }

            await _clienteRepository.Adicionar(cliente);
            return true;
        }

        public async Task<bool> Atualizar(Cliente cliente)
        {
            if (_clienteRepository.Buscar(c => c.Documento == cliente.Documento 
                                          && c.Id != cliente.Id).Result.Any())
            {
                Notificar("Já existe um cliente com esse documento");
                return false;
            }

            await _clienteRepository.Atualizar(cliente);
            return true;
        }

        public async Task<bool> Remover(Guid id)
        {
            await _clienteRepository.Remover(id);
            return true;
        }
        public void Dispose() => _clienteRepository.Dispose();
    }
}