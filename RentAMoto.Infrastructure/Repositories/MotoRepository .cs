using LinqKit;
using LinqKit.Core;
using Microsoft.EntityFrameworkCore;
using RentAMoto.Domain.Entities;
using RentAMoto.Infrastructure.Context;
using RentAMoto.Infrastructure.Interfaces;

namespace RentAMoto.Infrastructure.Repositories
{
    public class MotoRepository : IMotoRepository
    {
        private readonly ApplicationDbContext _context;

        public MotoRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddMotoAsync(Moto moto)
        {
            _context.Motos.Add(moto);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Moto>> GetAllMotosAsync(string placa)
        {
            var predicate = PredicateBuilder.New<Moto>(true);

            if (!string.IsNullOrEmpty(placa))
            {
                predicate = predicate.And(m => m.Placa.Contains(placa));
            }

            return await _context
                .Motos
                .Where(predicate)
                .ToListAsync();
        }

        public async Task<Moto> GetMotoByIdAsync(int motoId)
        {
            return await _context.Motos.FirstOrDefaultAsync(m => m.Id == motoId);
        }

        public Task<Moto> GetMotoByPlacaAsync(string placa)
        {
            return _context.Motos.FirstOrDefaultAsync(m => m.Placa == placa);
        }

        public async Task<Moto> Update(Moto moto)
        {
            _context.Motos.Update(moto);

            await _context.SaveChangesAsync();

            return moto;
        }
    }
}