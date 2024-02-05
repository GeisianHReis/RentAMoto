using Microsoft.EntityFrameworkCore;
using RentAMoto.Domain.Entities;
using RentAMoto.Infrastructure.Context;
using RentAMoto.Infrastructure.Interfaces;

namespace RentAMoto.Infrastructure.Repositories
{
    public class LocacaoRepository : ILocacaoRepository
    {
        private readonly ApplicationDbContext _context;

        public LocacaoRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddLocacaoAsync(Locacao locacao)
        {
            _context.Locacoes.Add(locacao);

            await _context.SaveChangesAsync();
            
            return true;
        }

        public Task<Locacao> GetLocacaoByEntregadorIdAsync(int entregadorId)
        {
            return _context.Locacoes.FirstOrDefaultAsync(x => x.EntregadorId == entregadorId);
        }
    }
}