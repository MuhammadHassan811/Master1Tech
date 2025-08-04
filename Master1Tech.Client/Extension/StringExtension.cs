namespace Master1Tech.Client.Extension
{
    public static class StringExtension
    {
        public static string TruncateWithEllipsis(this string text, int maxLength)
        {
            if (string.IsNullOrEmpty(text) || text.Length <= maxLength)
            {
                return text;
            }
            // Ensure there's enough space for the ellipsis
            if (maxLength < 3)
            {
                return text.Substring(0, maxLength); // Or handle as an error
            }
            return text.Substring(0, maxLength - 3) + "...";
        }
    }
}
