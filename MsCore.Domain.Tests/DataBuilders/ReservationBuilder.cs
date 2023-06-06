using MsConfiguracion.Domain.Entities;
using System;

namespace MsConfiguracion.Domain.Tests.DataBuilders
{
    public class ZonaBuilder
    {
        private Guid _id = Guid.NewGuid();
        private Guid _EquiposId = Guid.NewGuid();
        private DateTime _startDate = DateTime.Now;
        private DateTime _endDate = DateTime.Now.AddDays(1);

        public ZonaBuilder(Guid id)
        {
            _id = id;
        }

        public ZonaBuilder WithEquiposId(Guid EquiposId)
        {
            _EquiposId = EquiposId;
            return this;
        }

        public ZonaBuilder WithStartDate(DateTime startDate)
        {
            _startDate = startDate;
            return this;
        }

        public ZonaBuilder WithEndDate(DateTime endDate)
        {
            _endDate = endDate;
            return this;
        }

        public Zona Build()
        {
            return new Zona
            {
                Id = _id,
                EquiposId = _EquiposId,
                StartDate = _startDate,
                EndDate = _endDate
            };
        }
    }

}
