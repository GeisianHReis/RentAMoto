using Microsoft.AspNetCore.Mvc;
using RentAMoto.Application.Services.Entregador.GetAllPedidos;
using RentAMoto.Application.Services.Entregador.PostDevolucao;
using RentAMoto.Application.Services.Entregador.PostEntregador;
using RentAMoto.Application.Services.Entregador.PostLocacao;
using RentAMoto.Application.Services.Entregador.PutEntregador;

namespace RentAMoto.API.Controllers
{
    public class EntregadorController : ApiControllerBase
    {
        private readonly ILogger<EntregadorController> _logger;

        public EntregadorController(ILogger<EntregadorController> logger)
        {
            _logger = logger;
        }

        [HttpPost("cadastrar")]
        public async Task<ActionResult> PostEntregador([FromBody] PostEntregadorRequest request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("atualizar-cnh")]
        public async Task<ActionResult> PutEntregador([FromForm] PutEntregadorRequest request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("pedidos")]
        public async Task<ActionResult> GetAllPedidos([FromQuery] GetAllRequest request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("alugar-moto")]
        public async Task<ActionResult> PostLocacao([FromBody] PostLocacaoRequest request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("devolver-moto")]
        public async Task<ActionResult> PostDevolucao([FromBody] PostDevolucaoRequest request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }
    }
}