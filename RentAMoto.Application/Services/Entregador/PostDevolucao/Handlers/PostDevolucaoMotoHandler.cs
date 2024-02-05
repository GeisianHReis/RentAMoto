using RentAMoto.Application.Commom;
using RentAMoto.Infrastructure.Interfaces;

namespace RentAMoto.Application.Services.Entregador.PostDevolucao.Handlers
{
    public class PostDevolucaoMotoHandler : Handler<PostDevolucaoRequest, PostDevolucaoResponse, string>
    {
        private readonly IEntregadorRepository _entregadorRepository;
        private readonly ILocacaoRepository _locacaoRepository;

        public PostDevolucaoMotoHandler(IEntregadorRepository entregadorRepository, ILocacaoRepository locacaoRepository)
        {
            _entregadorRepository = entregadorRepository;
            _locacaoRepository = locacaoRepository;
        }
        public override async Task Process(PostDevolucaoRequest request, PostDevolucaoResponse response)
        {
            try
            {
                var entregador = await _entregadorRepository.GetEntregadorByIdAsync(request.EntregadorId);
                var locacao = _locacaoRepository.GetLocacaoByEntregadorIdAsync(request.EntregadorId);

                if (entregador == null)
                {
                    response.HasError = true;
                    response.Error = "Entregador não encontrado";
                    return;
                }

                if (locacao.Result == null)
                {
                    response.HasError = true;
                    response.Error = "Não existe locação para este entregador";
                    return;
                }
                var diasLocacao = locacao.Result.DataPrevisaoTermino - locacao.Result.DataInicio;
                var diasAtraso = locacao.Result.DataPrevisaoTermino - request.DataDevolucao;
                var diasAtrasoValorAbsoluto = Math.Abs(diasAtraso.Value.Days);
                double valorTotal = 0;
                double multa = 0;
                var diasLocacaoRealizadas = 0;

                if (diasLocacao.Value.TotalDays == 7)
                {
                    var valorDiaria = 30;
                    diasLocacaoRealizadas = 7 - diasAtraso.Value.Days;
                    valorTotal = 7 * valorDiaria;

                    if (diasAtraso.Value.Days > 0)
                    {
                        multa = diasAtraso.Value.Days * 0.2 * valorDiaria;
                        valorTotal += multa;
                    }

                    if (diasAtraso.Value.Days <= 0)
                    {
                        var valorAdicionalPorDia = 50;
                        multa = diasAtrasoValorAbsoluto * valorAdicionalPorDia;
                        valorTotal += multa;
                    }
                }

                if (diasLocacao.Value.TotalDays == 15)
                {
                    var valorDiaria = 28;
                    diasLocacaoRealizadas = 15 - diasAtraso.Value.Days;
                    valorTotal = 15 * valorDiaria;

                    if (diasAtraso.Value.Days > 0)
                    {
                        multa = diasAtraso.Value.Days * 0.4 * valorDiaria;
                        valorTotal += multa;
                    }

                    if (diasAtraso.Value.Days <= 0)
                    {
                        var valorAdicionalPorDia = 50;
                        multa = diasAtrasoValorAbsoluto * valorAdicionalPorDia;
                        valorTotal += multa;
                    }
                }

                if (diasLocacao.Value.TotalDays == 30)
                {
                    var valorDiaria = 22;
                    diasLocacaoRealizadas = 30 - diasAtraso.Value.Days;
                    valorTotal = diasLocacaoRealizadas * valorDiaria;

                    if (diasAtraso.Value.Days > 0)
                    {
                        multa = diasAtraso.Value.Days * 0.6 * valorDiaria;
                        valorTotal += multa;
                    }

                    if (diasAtraso.Value.Days <= 0)
                    {
                        var valorAdicionalPorDia = 50;
                        multa = diasAtrasoValorAbsoluto * valorAdicionalPorDia;
                        valorTotal += multa;
                    }

                }
                response.Data = "Dias de locação realizados: " + diasLocacaoRealizadas +
                                " Multa : " + multa.ToString("C") +
                                " Total da locação: " + valorTotal.ToString("C");

            }
            catch (Exception ex)
            {
                response.HasError = true;
                response.Error = ex.Message;
            }
        }
    }
}