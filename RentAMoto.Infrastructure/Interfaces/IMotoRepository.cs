using RentAMoto.Domain.Entities;

namespace RentAMoto.Infrastructure.Interfaces
{
    public interface IMotoRepository
    {
        Task<bool> AddMotoAsync(Moto moto);
        Task<Moto> GetMotoByIdAsync(int motoId);
        Task<Moto> GetMotoByPlacaAsync(string placa);
        Task<IEnumerable<Moto>> GetAllMotosAsync(string placa);
        Task<Moto> Update(Moto moto);
    }
}