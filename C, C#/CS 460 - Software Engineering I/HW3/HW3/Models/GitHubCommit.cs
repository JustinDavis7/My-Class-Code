using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace HW3.Models
{
    public class GitHubCommit : GitHubModel
    {
        public string Sha { get; set; }
        public string Committer { get; set; }
        public DateTime WhenCommitted { get; set; }
        public string CommitMessage { get; set; }
        public string HtmlUrl { get; set; }
        
        public void FromJson(string obj)
        {
            JObject userCommits = JObject.Parse(obj);
            Sha = (string)userCommits["sha"];
            Committer = (string)userCommits["commit"]["committer"]["name"];
            WhenCommitted = (DateTime)userCommits["commit"]["committer"]["date"];
            CommitMessage = (string)userCommits["commit"]["message"];
            HtmlUrl = (string)userCommits["commit"]["url"];
        }

        public GitHubCommit(string sha, string committer, DateTime committed, string message, string url)
        {
            Sha = sha;
            Committer = committer;
            WhenCommitted = committed;
            CommitMessage = message;
            HtmlUrl = url;
        }
    }
}