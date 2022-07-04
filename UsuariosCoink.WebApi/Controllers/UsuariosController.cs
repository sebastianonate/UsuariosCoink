using MediatR;
using Microsoft.AspNetCore.Mvc;
using UsuariosCoink.Core.Application.Features.Commands;
using UsuariosCoink.Core.Application.Features.Queries;

namespace UsuariosCoink.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IMediator _mediador;
        public UsuariosController(IMediator mediador)
        {
            _mediador = mediador;
        }

        [HttpPost("Create")]
        public Task<int> CreateUser(CreateUsuarioRequest request)
        {
            return _mediador.Send(request);
        }

        [HttpPost("BasicCreate")]
        public Task<int> BasicCreateUser(CreateBasicUsuarioRequest request)
        {
            return _mediador.Send(request);
        }

        [HttpGet("GetAll")]
        public Task<List<GetAllUsuariosResponse>> GetAll()
        {
            return _mediador.Send(new GetAllUsuariosRequest());
        }

        [HttpGet("{usuarioId}/GetById")]
        public Task<GetUsuarioByIdResponse> GetById(int usuarioId)
        {
            return _mediador.Send(new GetUsuarioByIdRequest(usuarioId));
        }
    }
}