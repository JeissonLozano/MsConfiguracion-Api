using MsCore.Domain.Entities.Base;

namespace MsCore.Domain.Entities;

public class Product : EntityBase<Guid>
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Stock { get; set; }
}
