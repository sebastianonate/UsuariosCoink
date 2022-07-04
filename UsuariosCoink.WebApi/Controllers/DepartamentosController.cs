using MediatR;
using Microsoft.AspNetCore.Mvc;
using UsuariosCoink.Core.Application.Features.Commands;
using UsuariosCoink.Core.Application.Features.Queries;

namespace UsuariosCoink.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartamentosController : ControllerBase
    {
        private readonly IMediator _mediador;
        public DepartamentosController(IMediator mediador)
        {
            _mediador = mediador;
        }

        [HttpGet("GetAll")]
        public Task<List<GetAllDepartamentosResponse>> GetAll()
        {
            return _mediador.Send(new GetAllDepartamentosRequest());
        }
    }
}