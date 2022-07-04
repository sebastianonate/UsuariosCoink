using MediatR;
using Microsoft.AspNetCore.Mvc;
using UsuariosCoink.Core.Application.Features.Commands;
using UsuariosCoink.Core.Application.Features.Queries;

namespace UsuariosCoink.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaisesController : ControllerBase
    {
        private readonly IMediator _mediador;
        public PaisesController(IMediator mediador)
        {
            _mediador = mediador;
        }

        [HttpGet("GetAll")]
        public Task<List<GetAllPaisesResponse>> GetAll()
        {
            return _mediador.Send(new GetAllPaisesRequest());
        }
    }
}