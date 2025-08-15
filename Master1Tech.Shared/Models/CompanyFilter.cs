namespace Master1Tech.Models
{
    public class CompanyFilter
    {

        public List<int>? Services { get; set; }
        public List<int>? Technologies { get; set; }
        public List<int>? Industries { get; set; }
        public List<string>? Year { get; set; }
        public string SortBy { get; set; } = "Name";
    }
}
