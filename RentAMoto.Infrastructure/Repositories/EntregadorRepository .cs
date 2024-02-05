using Microsoft.EntityFrameworkCore;
using RentAMoto.Domain.Entities;
using RentAMoto.Infrastructure.Context;
using RentAMoto.Infrastructure.Interfaces;

namespace RentAMoto.Infrastructure.Repositories
{
    public class EntregadorRepository : IEntregadorRepository
    {
        private readonly ApplicationDbContext _context;

        public EntregadorRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddEntregadorAsync(Entregador entregador)
        {
            _context.Entregadores.Add(entregador);

            await _context.SaveChangesAsync();

            return true;
        }

        public Task<bool> AtualizarCadastroComFotoCNHAsync(int entregadorId, byte[] fotoCnh, string formatoArquivo)
        {
            throw new NotImplementedException();
        }

        public Task<Entregador> GetEntregadorByCNHAsync(string numeroCNH)
        {
            return _context.Entregadores.FirstOrDefaultAsync(e => e.NumeroCNH == numeroCNH);
        }

        public Task<Entregador> GetEntregadorByCNPJAsync(string numeroCNH)
        {
            return _context.Entregadores.FirstOrDefaultAsync(e => e.CNPJ == numeroCNH);
        }

        public Task<Entregador> GetEntregadorByIdAsync(int entregadorId)
        {
            return _context.Entregadores.FirstOrDefaultAsync(e => e.Id == entregadorId);
        }

        public async Task<Entregador> Update(Entregador entregador)
        {
            _context.Entregadores.Update(entregador);

            await _context.SaveChangesAsync();

            return entregador;
        }
    }
}