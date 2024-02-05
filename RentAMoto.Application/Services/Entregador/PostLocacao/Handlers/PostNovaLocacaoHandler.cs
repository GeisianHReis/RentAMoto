using RentAMoto.Application.Commom;
using RentAMoto.Application.Dtos;
using RentAMoto.Application.Enum;
using RentAMoto.Domain.Entities;
using RentAMoto.Infrastructure.Interfaces;

namespace RentAMoto.Application.Services.Entregador.PostLocacao.Handlers
{
    public class PostNovaLocacaoHandler : Handler<PostLocacaoRequest, PostLocacaoResponse, string>
    {
        private readonly IMotoRepository _motoRepository;
        private readonly ILocacaoRepository _locacaoRepository;
        private readonly IEntregadorRepository _entregadorRepository;

        public PostNovaLocacaoHandler(IMotoRepository motoRepository, ILocacaoRepository locacaoRepository, IEntregadorRepository entregadorRepository)
        {
            _motoRepository = motoRepository;
            _locacaoRepository = locacaoRepository;
            _entregadorRepository = entregadorRepository;
        }
        public override async Task Process(PostLocacaoRequest request, PostLocacaoResponse response)
        {
            try
            {
                var moto = _motoRepository.GetAllMotosAsync(null).Result.Where(x => x.Disponivel).FirstOrDefault();
                var entregador = _entregadorRepository.GetEntregadorByIdAsync(request.EntregadorId);

                if (moto == null)
                {
                    response.HasError = true;
                    response.Error = "Nenhuma moto disponível";
                    return;
                }

                if (entregador == null)
                {
                    response.HasError = true;
                    response.Error = "Entregador não encontrado";
                    return;
                }

                var dataAtual = DateTime.UtcNow;
                var dias = request.PlanoLocacao switch
                {
                    PlanoLocacao.SeteDias => 7,
                    PlanoLocacao.QuinzeDias => 15,
                    PlanoLocacao.TrintaDias => 30,
                    _ => 0
                };
                var locacao = new Locacao
                {
                    DataInicio = dataAtual.AddDays(1),
                    DataPrevisaoTermino = dataAtual.AddDays(dias + 1),
                    MotoId = moto.Id,
                    EntregadorId = entregador.Result.Id,
                };

                await _locacaoRepository.AddLocacaoAsync(locacao);

                response.Data = "Locação realizada com sucesso";
            }
            catch (Exception ex)
            {
                response.HasError = true;
                response.Error = ex.Message;
            }
        }
    }
}