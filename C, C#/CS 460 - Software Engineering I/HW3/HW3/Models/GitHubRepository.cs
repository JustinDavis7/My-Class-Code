using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace HW3.Models
{
    public class GitHubRepository : GitHubModel
    {
        public string Name {get; set;}
        public string Owner {get; set;}
        public string HTMLUrl {get; set;}
        public string FullName {get; set;}
        public string OwnerAvatarUrl {get; set;}
        public DateTime LastUpdated {get; set;}
        public void FromJson(string obj)
        {
            JObject userRepos = JObject.Parse(obj);
            Name = (string) userRepos["name"];
            FullName = (string) userRepos["full_name"];
            Owner = (string) userRepos["owner"]["login"];
            HTMLUrl = (string) userRepos["owner"]["html_url"];
            OwnerAvatarUrl = (string) userRepos["owner"]["avatar_url"];
            LastUpdated = (DateTime) userRepos["updated_at"];
        }

        public GitHubRepository(){}

        public GitHubRepository(string name, string owner, string htmlUrl, string fullName, string avatarUrl, DateTime lastUpdated)
        {
            Name = name;
            Owner = owner;
            HTMLUrl = htmlUrl;
            FullName = fullName;
            OwnerAvatarUrl = avatarUrl;
            LastUpdated = lastUpdated;
        }
    }
}