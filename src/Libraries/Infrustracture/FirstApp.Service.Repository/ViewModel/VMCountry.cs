﻿using FirstApp.Shared.Common;


namespace FirstApp.Service.Repository.ViewModel;

public class VMCountry : IVM
{
    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    /// <value>
    /// The identifier.
    /// </value>
    public int Id { get; set; }
    /// <summary>
    /// Gets or sets the name of the country.
    /// </summary>
    /// <value>
    /// The name of the country.
    /// </value>
    public string CountryName { get; set; } = string.Empty;

    [JsonIgnore]
    public ICollection<VMState> States { get; set; } = new HashSet<VMState>();
    [JsonIgnore]
    public ICollection<VMEmployee> Employees { get; set; } = new HashSet<VMEmployee>();
}
