namespace Master1Tech.Shared.DTOs.Service
{
    public class ServiceSummaryDto
    {
        public int ServiceID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
    }
}
