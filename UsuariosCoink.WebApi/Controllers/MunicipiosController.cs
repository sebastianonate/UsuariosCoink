using MediatR;
using Microsoft.AspNetCore.Mvc;
using UsuariosCoink.Core.Application.Features.Commands;
using UsuariosCoink.Core.Application.Features.Queries;

namespace UsuariosCoink.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MunicipiosController : ControllerBase
    {
        private readonly IMediator _mediador;
        public MunicipiosController(IMediator mediador)
        {
            _mediador = mediador;
        }
        [HttpGet("GetAll")]
        public Task<List<GetAllMunicipiosResponse>> GetAll()
        {
            return _mediador.Send(new GetAllMunicipiosRequest());
        }
    }
}