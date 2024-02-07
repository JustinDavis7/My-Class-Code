using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace HW3.Models
{
    public class GitHubBranch : GitHubModel
    {
        public string Name {get; set;}
        public void FromJson(string obj)
        {
            JObject userBranches = JObject.Parse(obj);
            Name = (string)userBranches["name"];
        }

        public GitHubBranch(string name)
        {
            Name = name;
        }
    }
}