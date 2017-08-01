namespace VacationTracking.Data.Models
{
    public class Role
    {
        /// <summary>
        /// Role Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Role Name
        /// </summary>
        public string Name { get; set; }

        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }
    }
}
