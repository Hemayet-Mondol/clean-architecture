using FirstApp.Shared.Enum;

namespace FirstApp.Shared.Common
{
    public class BaseEntity : IEntity
    {
        public DateTimeOffset Created { get ; set ; }=                                                              DateTimeOffset.Now;
        public string? CreatedBy { get ; set ; }
        public DateTimeOffset? LastModified { get; set ; }=DateTimeOffset.Now;
        public string? LastModifiedBy { get ; set ; }
        public EntityStutas Stutas { get ; set ; }
        public int Id { get ; set ; }
    }
}
