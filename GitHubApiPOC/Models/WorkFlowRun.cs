namespace GitHubApiPOC.Models
{
    public class WorkFlowRun
    {
        public int total_count { get; set; }
        public Workflow_Runs[] workflow_runs { get; set; }
    }
    public class Workflow_Runs
    {
        public long id { get; set; }
        public string name { get; set; }
        public string head_branch { get; set; }
        public int run_number { get; set; }
        public string _event { get; set; }
        public string status { get; set; }
        public string conclusion { get; set; }
        public int workflow_id { get; set; }
    }
}

