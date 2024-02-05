using RentAMoto.Application.Commom;
using RentAMoto.Application.Dtos;
using RentAMoto.Infrastructure.Interfaces;

namespace RentAMoto.Application.Services.Entregador.PutEntregador.Handlers
{
    public class PutImagemCnhEntregador : Handler<PutEntregadorRequest, PutEntregadorResponse, EntregadorDto>
    {
        private readonly IEntregadorRepository _entregadorRepository;
        private readonly IFotoCNHService _fotoCNHService;

        public PutImagemCnhEntregador(IEntregadorRepository entregadorRepository, IFotoCNHService fotoCNHService)
        {
            _entregadorRepository = entregadorRepository;
            _fotoCNHService = fotoCNHService;
        }

        public override async Task Process(PutEntregadorRequest request, PutEntregadorResponse response)
        {
            try
            {
                var entregador = await _entregadorRepository.GetEntregadorByCNHAsync(request.NumeroCNH);

                if (entregador == null)
                {
                    response.HasError = true;
                    response.Error = "Entregador não cadastrado.";
                    return;
                }
                await _fotoCNHService.SalvarFotoCNHAsync(request.FotoCNH);
                entregador.ImagemCNHUrl = request.FotoCNH.FileName;
                await _entregadorRepository.Update(entregador);

                response.Data = new EntregadorDto
                {
                    Nome = entregador.Nome,
                    NumeroCNH = entregador.NumeroCNH,
                    ImagemCNHUrl = entregador.ImagemCNHUrl
                };
            }
            catch (Exception ex)
            {
                response.HasError = true;
                response.Error = $"Erro ao atualizar CNH do entregador. {ex.Message}";
            }
        }
    }
}