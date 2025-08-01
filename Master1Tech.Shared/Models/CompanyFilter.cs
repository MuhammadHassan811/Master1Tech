namespace Master1Tech.Models
{
    public class CompanyFilter
    {
        //public string Name { get; set; }
        //public string Headquarters { get; set; }
        //public int? FoundedYear { get; set; }
        //public int? EmployeesCount { get; set; }
        //public bool? IsVerified { get; set; }
        // public string SortBy { get; set; } = "Featured";
        public string Location { get; set; } = string.Empty;
        public string Services { get; set; } = string.Empty;
        public string TeamSize { get; set; } = string.Empty;
        public string HourlyRate { get; set; } = string.Empty;
        public string SortBy { get; set; } = "Featured";
    }
}
