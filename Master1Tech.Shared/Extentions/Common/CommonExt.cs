using Master1Tech.Shared.DTOs.Common;

namespace Master1Tech.Shared.Extentions.Common
{
    public static class CommonExt
    {
        public static List<FoundedYearDto> GetFoundedYears()
        {
            const int startYear = 1990;
            int endYear = DateTime.Now.Year;

            return Enumerable.Range(startYear, endYear - startYear + 1)
                             .Select(year => new FoundedYearDto { Year = year.ToString() })
                             .ToList();
        }
    }
}
