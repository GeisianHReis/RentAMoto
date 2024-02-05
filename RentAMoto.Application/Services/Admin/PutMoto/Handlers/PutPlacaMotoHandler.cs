using RentAMoto.Application.Commom;
using RentAMoto.Application.Dtos;
using RentAMoto.Infrastructure.Interfaces;

namespace RentAMoto.Application.Services.Admin.PutMoto.Handlers
{
    public class PutPlacaMotoHandler : Handler<PutMotoRequest, PutMotoResponse, MotoResponseDto>
    {
        private readonly IMotoRepository _motoRepository;

        public PutPlacaMotoHandler(IMotoRepository motoRepository)
        {
            _motoRepository = motoRepository;
        }
        public override async Task Process(PutMotoRequest request, PutMotoResponse response)
        {
            try
            {

                var moto = await _motoRepository.GetMotoByPlacaAsync(request.PlacaAtual);

                if (moto == null)
                {
                    response.Error = "Moto não encontrada";
                    response.HasError = true;
                    return;
                }

                moto.Placa = request.PlacaNova;

                await _motoRepository.Update(moto);

                response.Data = new MotoResponseDto
                {
                    Modelo = moto.Modelo,
                    Placa = moto.Placa,
                    Ano = moto.Ano
                };
            }
            catch (Exception ex)
            {
                response.Error = ex.Message;
                response.HasError = true;
            }
        }
    }
}