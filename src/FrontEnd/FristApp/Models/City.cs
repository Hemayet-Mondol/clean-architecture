using System.ComponentModel.DataAnnotations;

namespace FristApp.Models
{
    public class City
    {
         /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the name of the city.
        /// </summary>
        /// <value>
        /// The name of the city.
        /// </value>

        [Display (Name ="City Name")]
        public string CityName { get; set; } = string.Empty;
        public int StateId { get; set; }



    }
}
