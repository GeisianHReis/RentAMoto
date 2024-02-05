using RentAMoto.Domain.Entities;

namespace RentAMoto.Infrastructure.Interfaces
{
    public interface IEntregadorRepository
    {
        Task<Entregador> GetEntregadorByIdAsync(int entregadorId);
        
        Task<Entregador> GetEntregadorByCNHAsync(string numeroCNH);
        Task<Entregador> GetEntregadorByCNPJAsync(string numeroCNH);
        Task<bool> AddEntregadorAsync(Entregador entregador);
        Task<bool> AtualizarCadastroComFotoCNHAsync(int entregadorId, byte[] fotoCnh, string formatoArquivo);
        Task<Entregador> Update(Entregador entregador);
    }
}