using System.Reflection.Metadata;
using RentAMoto.Application.Commom;
using RentAMoto.Application.Dtos;
using RentAMoto.Infrastructure.Interfaces;

namespace RentAMoto.Application.Services.Admin.GetAll.Handlers
{
    public class GetAllMotoHandler : Handler<GetAllRequest, GetAllResponse, MotoResponseGetAllDto>
    {
        private readonly IMotoRepository _motoRepository;

        public GetAllMotoHandler(IMotoRepository motoRepository)
        {
            _motoRepository = motoRepository;
        }
        public override async Task Process(GetAllRequest request, GetAllResponse response)
        {
            try
            {
                var motos = await _motoRepository.GetAllMotosAsync(request.Placa);

                if (motos == null)
                {
                    response.HasError = true;
                    response.Error = "Nenhuma moto encontrada.";
                    return;
                }

                response.Data.Motos.AddRange(motos.Select(m => new MotoResponseDto()
                {
                    Ano = m.Ano,
                    Modelo = m.Modelo,
                    Placa = m.Placa
                }
                ));

            }
            catch (Exception ex)
            {
                response.HasError = true;
                response.Error = $"Erro ao buscar motos. {ex.Message}";
            }
        }
    }
}