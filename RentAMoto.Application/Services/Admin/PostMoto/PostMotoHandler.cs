using MediatR;
using RentAMoto.Application.Services.Admin.PostMoto.Handlers;
using RentAMoto.Infrastructure.Interfaces;

namespace RentAMoto.Application.Services.Admin.PostMoto
{
    public class PostMotoHandler : IRequestHandler<PostMotoRequest, PostMotoResponse>
    {
        private readonly IMotoRepository _motoRepository;

        public PostMotoHandler(IMotoRepository motoRepository)
        {
            _motoRepository = motoRepository;
        }
        public async Task<PostMotoResponse> Handle(PostMotoRequest request, CancellationToken cancellationToken)
        {
            var response = new PostMotoResponse();

            var h0 = new PostNovaMotoHandler(_motoRepository);

            await h0.Process(request, response);

            return response;

        }
    }
}