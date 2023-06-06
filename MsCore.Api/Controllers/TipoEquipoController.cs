using MediatR;
using Microsoft.AspNetCore.Mvc;
using MsCore.Application.TipoEquipo.Commands;
using MsCore.Application.TipoEquipo.Queries;
using MsCore.Domain.DTOs;

namespace MsCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoEquipoController : ControllerBase
    {
        private readonly IMediator mediator;

        public TipoEquipoController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Obtener todos los tipos de equipo
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<TipoEquipoDto>> GetAllAsync()
        {
            return await mediator.Send(new GetAllTipoEquiposQuery());
        }


        /// <summary>
        /// Buscar tipo equipo por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<TipoEquipoDto> GetAsync(Guid id)
        {
            return await mediator.Send(new GetTipoEquipoByIdQuery(id));
        }

        /// <summary>
        /// Registrar tipo equipo
        /// </summary>
        /// <param name="TipoEquipo"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task PostAsync(TipoEquipoCreateCommand TipoEquipo)
        {
            await mediator.Send(TipoEquipo);
        }

        /// <summary>
        /// Actualizar tipo equipo
        /// </summary>
        /// <param name="TipoEquipo"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task PutAsync(TipoEquipoUpdateAsyncCommand TipoEquipo, Guid id)
        {
            await mediator.Send(new TipoEquipoUpdateAsyncCommand(id,
                TipoEquipo.NombreTipoEquipo, TipoEquipo.Descripcion));
        }

        /// <summary>
        /// Eliminar tipo equipo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task DeleteAsync(Guid id)
        {
            await mediator.Send(new TipoEquipoDeleteAsyncCommand(id));
        }
    }
}
