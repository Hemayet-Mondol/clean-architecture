using FirstApp.Shared.Common;

namespace FirstApp.Model;

public class State:BaseEntity,IEntity
{
    /// <summary>
    /// Gets or sets the name of the state.
    /// </summary>
    /// <value>
    /// The name of the state.
    /// </value>
    public string StateName { get; set; }=string.Empty;
    /// <summary>
    /// Gets or sets the country identifier.
    /// </summary>
    /// <value>
    /// The country identifier.
    /// </value>
   public int CountryId { get; set; }
    /// <summary>
    /// Gets or sets the country.
    /// </summary>
    /// <value>
    /// The country.
    /// </value>
    public Country Country { get; set; }=new Country();

    public ICollection<City> Citys { get; set; }=new HashSet<City>();
    public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
}
