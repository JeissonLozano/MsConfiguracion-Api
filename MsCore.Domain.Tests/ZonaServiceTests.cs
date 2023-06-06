using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using MsConfiguracion.Domain.Entities;
using MsConfiguracion.Domain.Interfaces;
using MsConfiguracion.Domain.Services;
using MsConfiguracion.Domain.Tests.DataBuilders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MsConfiguracion.Domain.Tests
{
    [TestClass]
    public class ZonaServiceTests
    {
        private IZonaService _ZonaService;
        private IEquiposService _EquiposService;
        private IGenericRepository<Zona> _genericRepository;

        [TestInitialize]
        public void TesInitialize()
        {
            _genericRepository = Substitute.For<IGenericRepository<Zona>>();
            _EquiposService = Substitute.For<IEquiposService>();
            _ZonaService = new ZonaService(_genericRepository, _EquiposService);
        }

        [TestMethod]
        public async Task GetAllZonasAsync_ReturnsAllZonas()
        {
            //Arrange
            var Zonas = new List<Zona>
            {
                new ZonaBuilder(Guid.NewGuid()).Build(),
                new ZonaBuilder(Guid.NewGuid()).Build(),
                new ZonaBuilder(Guid.NewGuid()).Build(),
            };
            _genericRepository.GetAsync().Returns(Zonas);

            //Act
            var result = await _ZonaService.GetAllZonasAsync();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(Zonas.Count, result.Count());
            foreach (var Zona in Zonas)
            {
                Assert.IsTrue(result.Contains(Zona));
            }
            await _genericRepository.Received(1).GetAsync();
        }

        [TestMethod]
        public async Task GetZonaAsync_WithValidId_ReturnsZona()
        {
            //Arrange
            var ZonaId = Guid.NewGuid();
            var Zona = new ZonaBuilder(ZonaId).Build();
            _genericRepository.GetByIdAsync(ZonaId).Returns(Zona);

            //Act
            var result = await _ZonaService.GetZonaAsync(ZonaId);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(Zona, result);
            await _genericRepository.Received(1).GetByIdAsync(ZonaId);
        }

        [TestMethod]
        public async Task GetZonaAsync_WithInvalidId_ThrowsException()
        {
            //Arrange
            var invalidId = Guid.Empty;

            //Act + Assert
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => _ZonaService.GetZonaAsync(invalidId));
            await _genericRepository.Received(0).GetByIdAsync(invalidId);
        }

        [TestMethod]
        public async Task RegisterZonaAsync_WithValidZona_ReturnsRegisteredZona()
        {
            // Arrange
            var Zona = new ZonaBuilder(Guid.NewGuid()).Build();
            var Equipos = new EquiposBuilder(Zona.EquiposId).Build();

            _EquiposService.GetEquiposAsync(Zona.EquiposId).Returns(Equipos);

            _genericRepository.AddAsync(Zona).Returns(Zona);

            // Act
            var result = await _ZonaService.RegisterZonaAsync(Zona);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(Zona, result);
            await _genericRepository.Received(1).AddAsync(Zona);
            await _EquiposService.Received(1).GetEquiposAsync(Zona.EquiposId);
            await _EquiposService.Received(1).UpdateEquiposAsync(Arg.Any<Equipos>());
        }

        [TestMethod]
        public async Task RegisterZonaAsync_WithInvalidZona_ThrowsException()
        {
            //Arrange
            Zona invalidZona = null;

            //Act + Assert
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => _ZonaService.RegisterZonaAsync(invalidZona));
            await _genericRepository.Received(0).AddAsync(invalidZona);
        }

        [TestMethod]
        public async Task UpdateZonaAsync_WithValidZona_UpdatesZona()
        {
            //Arrange
            var Zona = new ZonaBuilder(Guid.NewGuid()).Build();
            _genericRepository.AddAsync(Zona).Returns(Zona);

            //Act
            await _ZonaService.UpdateZonaAsync(Zona);

            //Assert
            await _genericRepository.Received(1).UpdateAsync(Zona);
        }

        [TestMethod]
        public async Task UpdateZonaAsync_WithInvalidEquipos_ThrowsException()
        {
            //Arrange
            Zona invalidZona = null;

            //Act + Assert
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => _ZonaService.UpdateZonaAsync(invalidZona));
        }

        [TestMethod]
        public async Task DeleteZonaAsync_WithValidId_DeletesZona()
        {
            //Arrange
            var Zona = new ZonaBuilder(Guid.NewGuid())
                .WithEquiposId(Guid.NewGuid())
                .WithStartDate(DateTime.Now)
                .WithEndDate(DateTime.Now.AddDays(1))
                .Build();

            var Equipos = new EquiposBuilder(Zona.EquiposId).Build();

            _EquiposService.GetEquiposAsync(Zona.EquiposId).Returns(Equipos);

            _genericRepository.GetByIdAsync(Zona.Id).Returns(Zona);

            //Act
            await _ZonaService.DeleteZonaAsync(Zona.Id);

            //Assert
            await _genericRepository.Received(1).DeleteAsync(Zona);
            await _EquiposService.Received(1).GetEquiposAsync(Zona.EquiposId);
            await _EquiposService.Received(1).UpdateEquiposAsync(Equipos);
        }

        [TestMethod]
        public async Task DeleteZonaAsync_WithInvalidId_ThrowsException()
        {
            //Arrange
            Guid invalidId = Guid.Empty;

            //Act + Assert
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => _ZonaService.DeleteZonaAsync(invalidId));

        }
    }
}
