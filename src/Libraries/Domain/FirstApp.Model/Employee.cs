using FirstApp.Shared.Common;

namespace FirstApp.Model;

public class Employee:BaseEntity,IEntity
{
    /// <summary>
    /// Gets or sets the name of the employee.
    /// </summary>
    /// <value>
    /// The name of the employee.
    /// </value>
    public string EmployeeName { get; set; } = string.Empty;
    /// <summary>
    /// Gets or sets the address.
    /// </summary>
    /// <value>
    /// The address.
    /// </value>
    public string Address { get; set; }= string.Empty;
    /// <summary>
    /// Gets or sets the join date.
    /// </summary>
    /// <value>
    /// The join date.
    /// </value>
    /// 
    public string Gender {  get; set; } = string.Empty;
    public DateTimeOffset JoinDate { get; set; }
    /// <summary>
    /// Gets or sets a value indicating whether this <see cref="Employee"/> is SSC.
    /// </summary>
    /// <value>
    ///   <c>true</c> if SSC; otherwise, <c>false</c>.
    /// </value>
    public bool Ssc { get; set; }
    /// <summary>
    /// Gets or sets a value indicating whether this <see cref="Employee"/> is HSC.
    /// </summary>
    /// <value>
    ///   <c>true</c> if HSC; otherwise, <c>false</c>.
    /// </value>
    public bool Hsc { get; set; }
    /// <summary>
    /// Gets or sets a value indicating whether this <see cref="Employee"/> is MSC.
    /// </summary>
    /// <value>
    ///   <c>true</c> if MSC; otherwise, <c>false</c>.
    /// </value>
    public bool Msc { get; set; }
    /// <summary>
    /// Gets or sets a value indicating whether this <see cref="Employee"/> is BSC.
    /// </summary>
    /// <value>
    ///   <c>true</c> if BSC; otherwise, <c>false</c>.
    /// </value>
    public bool Bsc { get; set; }
    /// <summary>
    /// Gets or sets the picture.
    /// </summary>
    /// <value>
    /// The picture.
    /// </value>
    public string Picture { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the counrty identifier.
    /// </summary>
    /// <value>
    /// The counrty identifier.
    /// </value>
    public int CounrtyId { get; set; }
    /// <summary>
    /// Gets or sets the state identifier.
    /// </summary>
    /// <value>
    /// The state identifier.
    /// </value>
    public int StateId { get; set; }
    /// <summary>
    /// Gets or sets the city identifier.
    /// </summary>
    /// <value>
    /// The city identifier.
    /// </value>
    public int CityId { get; set; }
    /// <summary>
    /// Gets or sets the department identifier.
    /// </summary>
    /// <value>
    /// The department identifier.
    /// </value>
    public int DepartmentId { get; set; }


    /// <summary>
    /// Gets or sets the country.
    /// </summary>
    /// <value>
    /// The country.
    /// </value>
    
    public Country Country { get; set; }=new Country();

    /// <summary>
    /// Gets or sets the state.
    /// </summary>
    /// <value>
    /// The state.
    /// </value>
    /// 
    
    public State State { get; set; }=new State();
    /// <summary>
    /// Gets or sets the city.
    /// </summary>
    /// <value>
    /// The city.
    /// </value>
    /// 
    
    public City City { get; set; }=new City();

    public Department Department { get; set; } = new Department();




}
