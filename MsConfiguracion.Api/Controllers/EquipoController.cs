using MediatR;
using Microsoft.AspNetCore.Mvc;
using MsConfiguracion.Application.Equipos.Commands;
using MsConfiguracion.Application.Equipos.Queries;
using MsConfiguracion.Domain.DTOs;

namespace MsConfiguracion.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipoController : ControllerBase
    {
        private readonly IMediator mediator;

        public EquipoController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Obtener todos los equipos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<EquiposDto>> GetAllAsync()
        {
            return await mediator.Send(new GetAllEquipossQuery());
        }


        /// <summary>
        /// Buscar equipo por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<EquiposDto> GetAsync(Guid id)
        {
            return await mediator.Send(new GetEquiposByIdQuery(id));
        }

        /// <summary>
        /// Registrar equipo
        /// </summary>
        /// <param name="Equipos"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task PostAsync(EquiposCreateCommand Equipos)
        {
            await mediator.Send(Equipos);
        }

        /// <summary>
        /// Actualizar equipo
        /// </summary>
        /// <param name="Equipos"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task PutAsync(EquiposUpdateAsyncCommand Equipos, Guid id)
        {
            await mediator.Send(new EquiposUpdateAsyncCommand(id, 
                Equipos.Codigo, Equipos.Estado, Equipos.Observaciones, Equipos.IdTipoEquipo));
        }

        /// <summary>
        /// Eliminar equipo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task DeleteAsync(Guid id)
        {
            await mediator.Send(new EquiposDeleteAsyncCommand(id));
        }
    }
}
