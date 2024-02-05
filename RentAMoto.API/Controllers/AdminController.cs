using Microsoft.AspNetCore.Mvc;
using RentAMoto.Application.Services.Admin.GetAll;
using RentAMoto.Application.Services.Admin.PostMoto;
using RentAMoto.Application.Services.Admin.PostPedido;
using RentAMoto.Application.Services.Admin.PutMoto;

namespace RentAMoto.API.Controllers
{
    public class AdminController : ApiControllerBase
    {
        private readonly ILogger<AdminController> _logger;

        public AdminController(ILogger<AdminController> logger)
        {
            _logger = logger;
        }

        [HttpPost("cadastrar-moto")]
        public async Task<ActionResult> PostMoto([FromBody] PostMotoRequest request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        } 

        [HttpGet("motos")]
        public async Task<ActionResult> GetAllMotos([FromQuery] GetAllRequest request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("alterar-placa")]
        public async Task<ActionResult> PutMoto([FromBody] PutMotoRequest request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("cadastrar-pedido")]
        public async Task<ActionResult> PostPedido([FromBody] PostPedidoRequest request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }
    }
}