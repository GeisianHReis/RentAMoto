using Microsoft.AspNetCore.Http;

namespace RentAMoto.Infrastructure.Interfaces
{
    public interface IFotoCNHService
    {
        Task<string> SalvarFotoCNHAsync(IFormFile foto); 
    }
}