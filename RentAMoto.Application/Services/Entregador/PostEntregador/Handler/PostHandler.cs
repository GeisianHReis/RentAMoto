using RentAMoto.Application.Commom;
using RentAMoto.Application.Dtos;
using RentAMoto.Infrastructure.Interfaces;
using RentAMoto.Domain.Entities;

namespace RentAMoto.Application.Services.Entregador.PostEntregador.Handler
{
    public class PostHandler : Handler<PostEntregadorRequest, PostEntregadorResponse, EntregadorDto>
    {
        private readonly IEntregadorRepository _entregadorRepository;

        public PostHandler(IEntregadorRepository entregadorRepository)
        {
            _entregadorRepository = entregadorRepository;
        }

        public override async Task Process(PostEntregadorRequest request, PostEntregadorResponse response)
        {
            try
            {
                var entregadorExistenteCnh = await _entregadorRepository.GetEntregadorByCNHAsync(request.NumeroCNH);

                var entregadorExistenteCnpj = await _entregadorRepository.GetEntregadorByCNPJAsync(request.CNPJ);

                if (entregadorExistenteCnh != null || entregadorExistenteCnpj != null)
                {
                    response.HasError = true;
                    response.Error = "Entregador já cadastrado.";
                    return;
                }
                
                var entregador = new Domain.Entities.Entregador
                {
                    Nome = request.Nome,
                    DataNascimento = request.DataNascimento,
                    CNPJ = request.CNPJ,
                    NumeroCNH = request.NumeroCNH,
                    TipoCNH = (Domain.Entities.TipoCNH)request.TipoCNH
                };

                await _entregadorRepository.AddEntregadorAsync(entregador);

                response.Data = new EntregadorDto
                {
                    Nome = entregador.Nome,
                    DataNascimento = entregador.DataNascimento,
                    CNPJ = entregador.CNPJ,
                    NumeroCNH = entregador.NumeroCNH
                };
            }
            catch (Exception ex)
            {
                response.HasError = true;
                response.Error = $"Erro ao cadastrar entregador. {ex.Message}";
            }
        }
    }
}