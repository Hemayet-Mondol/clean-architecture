using FirstApp.Shared.Common;

namespace FirstApp.Model
{
    public class Country:BaseEntity,IEntity
    {
        /// <summary>Gets or sets of the country</summary>
        /// <value>My property.</value>
        public string CountryName { get; set; }=string.Empty;
        public ICollection<State> State { get; set; }=new HashSet<State>();
        public ICollection<Employee> Employees { get; set; }=new HashSet<Employee>();
    }
}
