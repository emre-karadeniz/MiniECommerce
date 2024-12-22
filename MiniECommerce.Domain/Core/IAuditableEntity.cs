namespace MiniECommerce.Domain.Core;

public interface IAuditableEntity
{
    DateTime CreatedDate { get; }
    DateTime? UpdatedDate { get; }
}