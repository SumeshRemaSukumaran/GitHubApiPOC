using Newtonsoft.Json;

namespace GitHubApiPOC.Models
{
    public class Workflows
    {

        public int total_count { get; set; }
        public Workflow[] workflows { get; set; }
    }

    public class Workflow
    {
        [JsonProperty("id")]
        public int WorkflowId { get; set; }

        [JsonProperty("name")]
        public string WorkflowName { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

    }


}
