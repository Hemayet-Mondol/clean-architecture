using FirstApp.Shared.Enum;

namespace FirstApp.Shared.Common;

public interface IEntity<T>
    where T : IEquatable<T>
{
    DateTimeOffset Created { get; set; }
    string? CreatedBy { get; set; }
    DateTimeOffset? LastModified { get; set; }
    string? LastModifiedBy { get; set; }
    EntityStutas Stutas { get; set; }
    T Id { get; set; }
}
public interface IEntity : IEntity<int> { }
