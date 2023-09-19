using FirstApp.Shared.Common;

namespace FirstApp.Model;

public class City:BaseEntity,IEntity
{
    /// <summary>
    /// Gets or sets the name of the city.
    /// </summary>
    /// <value>
    /// The name of the city.
    /// </value>
    public string CityName { get; set; } = string.Empty;
    /// <summary>
    /// Gets or sets the state.
    /// </summary>
    /// <value>
    /// The state.
    /// </value>
    public int StateId { get; set; }
    public State State { get; set; }=new State();
    public ICollection<Employee> Employees { get; set; }=new HashSet<Employee>();


}
