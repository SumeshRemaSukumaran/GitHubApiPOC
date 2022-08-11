using GitHubApiPOC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Linq;

namespace GitHubApiPOC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkflowController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetWorkflows(string token)
        {
            Uri baseUrl = new Uri("https://api.github.com/repos/SumeshRemaSukumaran/JWTSample/actions");
            RestClient client = new RestClient(baseUrl);
            RestRequest request = new RestRequest("workflows", Method.Get);

            request.AddHeader("Authorization", "token " + token);
            RestResponse response = client.Execute(request);

            var respose = JsonConvert.DeserializeObject<Workflows>(response.Content);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var workflowId = respose.workflows.FirstOrDefault(s => s.WorkflowName == "learn-github-actions").WorkflowId;
                request = new RestRequest($"workflows/{workflowId}/runs", Method.Get);
                request.AddHeader("Authorization", "token " + token);

                RestResponse exe = client.Execute(request);
                var respose1 = JsonConvert.DeserializeObject<WorkFlowRun>(exe.Content);

                var lastRun = respose1.workflow_runs.OrderByDescending(s => s.run_number).FirstOrDefault();
                return Ok(lastRun);

            }

            return Ok(respose);
        }
    }
}
