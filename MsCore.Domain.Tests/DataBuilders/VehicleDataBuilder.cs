using MsConfiguracion.Domain.Entities;
using System;

namespace MsConfiguracion.Domain.Tests.DataBuilders
{
    public class EquiposBuilder
    {
        private Guid _id = Guid.NewGuid();
        private string _brand = "Unknown";
        private string _model = "Unknown";
        private int _year = DateTime.Now.Year;
        private bool _isAvailable = true;

        public EquiposBuilder(Guid id)
        {
            _id = id;
        }

        public EquiposBuilder WithBrand(string brand)
        {
            _brand = brand;
            return this;
        }

        public EquiposBuilder WithModel(string model)
        {
            _model = model;
            return this;
        }

        public EquiposBuilder WithYear(int year)
        {
            _year = year;
            return this;
        }

        public EquiposBuilder WithAvailability(bool isAvailable)
        {
            _isAvailable = isAvailable;
            return this;
        }

        public Equipos Build()
        {
            return new Equipos
            { 
                Id = _id, 
                Brand = _brand, 
                Model = _model, 
                Year = _year, 
                IsAvailable = _isAvailable 
            };
        }
    }

}
