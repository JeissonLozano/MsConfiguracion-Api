using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using MsConfiguracion.Domain.Entities;
using MsConfiguracion.Domain.Interfaces;
using MsConfiguracion.Infrastructure.Context;
using System;
using System.Collections.Generic;

namespace MsConfiguracion.Api.Tests;

public class IntegrationTestBuilder : WebApplicationFactory<Program>
{
    readonly Guid _id;

    public Guid Id => this._id;

    public IntegrationTestBuilder()
    {
        _id = Guid.NewGuid();
    }

    protected override IHost CreateHost(IHostBuilder builder)
    {
        var rootDb = new InMemoryDatabaseRoot();

        builder.ConfigureServices(services =>
        {
            services.RemoveAll(typeof(DbContextOptions<PersistenceContext>));
            services.AddDbContext<PersistenceContext>(options =>
                    options.UseInMemoryDatabase("Testing", rootDb));

        });

        SeedDatabase(builder.Build().Services);

        return base.CreateHost(builder);
    }

    public void SeedDatabase(IServiceProvider services)
    {
        var Zonas = new List<Zona>
        {
            new Zona()
            {
                Id = Guid.NewGuid(),
                EquiposId =Guid.NewGuid(),
                StartDate = DateTime.Now.AddYears(-20),
                EndDate = DateTime.Now.AddYears(-20)
            }
        };

        using (var scope = services.CreateScope())
        {
            var ZonaRepo = scope.ServiceProvider.GetRequiredService<IGenericRepository<Zona>>();
            foreach (var Zona in Zonas)
            {
                ZonaRepo.AddAsync(Zona).Wait();
            }
        }
    }
}