using System.ComponentModel.DataAnnotations;

namespace FristApp.Models
{
    public class State
    {
        public int Id { get; set; }
        [Display(Name ="State Name")]
        public string StateName { get; set; } = string.Empty;
        public int countryId { get; set; }

        public Country Country { get; set; }
        

    }
}
