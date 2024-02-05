using RentAMoto.Application.Commom;
using RentAMoto.Application.Dtos;
using RentAMoto.Infrastructure.Interfaces;

namespace RentAMoto.Application.Services.Admin.PostMoto.Handlers
{
    public class PostNovaMotoHandler : Handler<PostMotoRequest, PostMotoResponse, MotoResponseDto>
    {
        private readonly IMotoRepository _motoRepository;

        public PostNovaMotoHandler(IMotoRepository motoRepository)
        {
            _motoRepository = motoRepository;
        }
        public override async Task Process(PostMotoRequest request, PostMotoResponse response)
        {
            try
            {
                var moto = await _motoRepository.GetMotoByPlacaAsync(request.Placa);

                if (moto != null)
                {
                    response.HasError = true;
                    response.Error = "Já existe uma moto com essa placa";
                    return;
                }

                var novaMoto = new Domain.Entities.Moto
                {
                    Placa = request.Placa,
                    Modelo = request.Modelo,
                    Ano = request.Ano,
                    Disponivel = true
                };

                await _motoRepository.AddMotoAsync(novaMoto);

                response.Data = new MotoResponseDto
                {
                    Ano = novaMoto.Ano,
                    Placa = novaMoto.Placa,
                    Modelo = novaMoto.Modelo
                };

            }
            catch (Exception ex)
            {
                response.HasError = true;
                response.Error = $"Erro ao cadastrar moto. {ex.Message}";
            }
        }
    }
}