namespace IndustryApiExample.Helpers
{
    public static class HtmlHelpers
    {
        public static string GetIndustryIcon(string industry)
        {
            return industry switch
            {
                "Software Development" => "fas fa-laptop-code",
                "Non-profit and Charity" => "fas fa-heart",
                "Education" => "fas fa-graduation-cap",
                "Healthcare" => "fas fa-hospital",
                "Government" => "fas fa-landmark",
                "Arts and Entertainment" => "fas fa-theater-masks",
                _ => "fas fa-briefcase",
            };
        }
    }
}
