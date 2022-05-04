using System;
using System.Threading.Tasks;
using DesafioSidequest.Business.Models;

namespace DesafioSidequest.Business.Interfaces
{
    public interface IClienteService : IDisposable
    {
        Task<bool> Adicionar(Cliente cliente);
        Task<bool> Atualizar(Cliente cliente);
        Task<bool> Remover(Guid id);
    }
}