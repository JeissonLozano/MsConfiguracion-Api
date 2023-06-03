using MediatR;
using Microsoft.AspNetCore.Mvc;
using MsConfiguracion.Application.Zona.Commands;
using MsConfiguracion.Application.Zona.Queries;
using MsConfiguracion.Domain.DTOs;

namespace MsConfiguracion.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZonaController : ControllerBase
    {
        private readonly IMediator mediator;

        public ZonaController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Obtener todas las zonas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<ZonaDto>> GetAllAsync()
        {
            return await mediator.Send(new GetAllZonaQuery());
        }

        /// <summary>
        /// Buscar zonas por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ZonaDto> GetAsync(Guid id)
        {
            return await mediator.Send(new GetZonaByIdQuery(id));
        }

        /// <summary>
        /// Registrar zona
        /// </summary>
        /// <param name="Zona"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task PostAsync(ZonaCreateCommand Zona)
        {
            await mediator.Send(Zona);
        }

        /// <summary>
        /// Actualizar zona
        /// </summary>
        /// <param name="Zona"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task PutAsync(ZonaUpdateAsyncCommand Zona, Guid id)
        {
            await mediator.Send(new ZonaUpdateAsyncCommand(id,
                Zona.Nombre, Zona.Descripcion, Zona.Estado));
        }

        /// <summary>
        /// Eliminar zona
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]

        public async Task DeleteAsync(Guid id)
        {
            await mediator.Send(new ZonaDeleteAsyncCommand(id));
        }

    }
}
