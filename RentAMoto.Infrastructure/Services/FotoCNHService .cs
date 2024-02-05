using Microsoft.AspNetCore.Http;
using RentAMoto.Infrastructure.Interfaces;

namespace RentAMoto.Infrastructure.Services
{
    public class FotoCNHService : IFotoCNHService
    {
        private readonly string _caminhoFotos;

        public FotoCNHService(string caminhoFotos)
        {
            _caminhoFotos = caminhoFotos;
        }

        public async Task<string> SalvarFotoCNHAsync(IFormFile foto)
        {
            if (foto == null || foto.Length == 0)
                throw new ArgumentException("A foto da CNH não foi fornecida.");

            var extensao = Path.GetExtension(foto.FileName).ToLower();
            if (extensao != ".png" && extensao != ".bmp")
                throw new ArgumentException("Formato de arquivo não suportado. Apenas PNG ou BMP são permitidos.");

            var nomeArquivo = Guid.NewGuid().ToString() + extensao;

            var caminhoCompleto = Path.Combine(_caminhoFotos, nomeArquivo);

            using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
            {
                await foto.CopyToAsync(stream);
            }

            return nomeArquivo;
        }
    }
}
