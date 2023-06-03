using Microsoft.VisualStudio.TestTools.UnitTesting;
using MsConfiguracion.Domain.Entities;
using MsConfiguracion.Domain.Interfaces;
using MsConfiguracion.Domain.Services;
using MsConfiguracion.Domain.Tests.DataBuilders;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using NSubstitute;
using System.Linq;

namespace MsConfiguracion.Domain.Tests
{
    [TestClass]
    public class EquiposServiceTests
    {
        private IEquiposService _EquiposService;
        private IGenericRepository<Equipos> _genericRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            _genericRepository = Substitute.For<IGenericRepository<Equipos>>();
            _EquiposService = new EquiposService(_genericRepository);
        }

        [TestMethod]
        public async Task GetAllEquipossAsync_ReturnsAllEquiposs()
        {
            // Arrange
            var Equiposs = new List<Equipos>
            {
                new EquiposBuilder(Guid.NewGuid()).Build(),
                new EquiposBuilder(Guid.NewGuid()).Build(),
                new EquiposBuilder(Guid.NewGuid()).Build()
            };
            _genericRepository.GetAsync().Returns(Equiposs);

            // Act
            var result = await _EquiposService.GetAllEquipossAsync();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(Equiposs.Count, result.Count());
            foreach (var Equipos in Equiposs)
            {
                Assert.IsTrue(result.Contains(Equipos));
            }
            await _genericRepository.Received(1).GetAsync();
        }

        [TestMethod]
        public async Task GetEquiposAsync_WithValidId_ReturnsEquipos()
        {
            // Arrange
            var EquiposId = Guid.NewGuid();
            var Equipos = new EquiposBuilder(EquiposId).Build();
            _genericRepository.GetByIdAsync(EquiposId).Returns(Equipos);

            // Act
            var result = await _EquiposService.GetEquiposAsync(EquiposId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(Equipos, result);
            await _genericRepository.Received(1).GetByIdAsync(EquiposId);
        }

        [TestMethod]
        public async Task GetEquiposAsync_WithInvalidId_ThrowsException()
        {
            // Arrange
            var invalidId = Guid.Empty;

            // Act + Assert
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => _EquiposService.GetEquiposAsync(invalidId));
            await _genericRepository.Received(0).GetByIdAsync(invalidId);
        }

        [TestMethod]
        public async Task RegisterEquiposAsync_WithValidEquipos_ReturnsRegisteredEquipos()
        {
            // Arrange
            var Equipos = new EquiposBuilder(Guid.NewGuid()).Build();
            _genericRepository.AddAsync(Equipos).Returns(Equipos);

            // Act
            var result = await _EquiposService.RegisterEquiposAsync(Equipos);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(Equipos, result);
            await _genericRepository.Received(1).AddAsync(Equipos);
        }

        [TestMethod]
        public async Task RegisterEquiposAsync_WithInvalidEquipos_ThrowsException()
        {
            // Arrange
            Equipos invalidEquipos = null;

            // Act + Assert
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => _EquiposService.RegisterEquiposAsync(invalidEquipos));
            await _genericRepository.Received(0).AddAsync(invalidEquipos);
        }

        [TestMethod]
        public async Task UpdateEquiposAsync_WithValidEquipos_UpdatesEquipos()
        {
            // Arrange
            var Equipos = new EquiposBuilder(Guid.NewGuid()).Build();

            // Act
            await _EquiposService.UpdateEquiposAsync(Equipos);

            // Assert
            await _genericRepository.Received(1).UpdateAsync(Equipos);
        }

        [TestMethod]
        public async Task UpdateEquiposAsync_WithInvalidEquipos_ThrowsException()
        {
            // Arrange
            Equipos invalidEquipos = null;

            // Act + Assert
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => _EquiposService.UpdateEquiposAsync(invalidEquipos));
        }

        [TestMethod]
        public async Task DeleteEquiposAsync_WithValidId_DeletesEquipos()
        {
            // Arrange
            var Equipos = new EquiposBuilder(Guid.NewGuid())
                .WithBrand("Toyota")
                .WithModel("Corolla")
                .WithYear(2020)
                .Build();

            _genericRepository.GetByIdAsync(Equipos.Id).Returns(Equipos);

            // Act
            await _EquiposService.DeleteEquiposAsync(Equipos.Id);

            // Assert
            await _genericRepository.Received(1).DeleteAsync(Equipos);
        }

        [TestMethod]
        public async Task DeleteEquiposAsync_WithInvalidId_ThrowsException()
        {
            // Arrange
            Guid invalidId = Guid.Empty;

            // Act + Assert
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => _EquiposService.DeleteEquiposAsync(invalidId));
        }
    }
}
