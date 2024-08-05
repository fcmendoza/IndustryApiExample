using Newtonsoft.Json;

namespace IndustryApiExample.Models
{
    public class IndustryModel
    {
        [JsonProperty("industry")]
        public string Industry { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("positions")]
        public string[] Positions { get; set; }

        [JsonProperty("averageSalaries")]
        public AverageSalaryModel[] AverageSalaries { get; set; }
    }

    public class AverageSalaryModel
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("salary")]
        public string Salary { get; set; }
    }
}
