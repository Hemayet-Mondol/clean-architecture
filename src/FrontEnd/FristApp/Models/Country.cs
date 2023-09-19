using System.ComponentModel.DataAnnotations;

namespace FristApp.Models;

public class Country
{
    public int Id { get; set; }
    [Display(Name ="Country Name")]
    public string CountryName { get; set; } = string.Empty;
}
