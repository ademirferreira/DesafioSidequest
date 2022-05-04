using DesafioSidequest.Business.Interfaces;
using DesafioSidequest.Business.Models;
using DesafioSidequest.Data.Context;

namespace DesafioSidequest.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(AppDbContext db) : base(db)
        {}
    }
}