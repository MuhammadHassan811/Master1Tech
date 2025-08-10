namespace Master1Tech.Shared.DTOs.Common
{
    public class FoundedYearDto
    {
        public string Year { get; set; } = null!;

        public static List<FoundedYearDto> GetFoundedYears()
        {
            const int startYear = 1970;
            int endYear = DateTime.Now.Year;

            return Enumerable.Range(startYear, endYear - startYear + 1)
                             .Select(year => new FoundedYearDto { Year = year.ToString() })
                             .ToList();
        }
    }

}
