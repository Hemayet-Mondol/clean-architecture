using FirstApp.Shared.Common;


namespace FirstApp.Service.Repository.ViewModel
{
    public class VMDepartment : IVM
    {
        
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the department.
        /// </summary>
        /// <value>
        /// The name of the department.
        /// </value>
        public string DepartmentName { get; set; } = string.Empty;

        [JsonIgnore]
        public ICollection<VMEmployee> Employees { get; set; } = new HashSet<VMEmployee>();
    }
}
