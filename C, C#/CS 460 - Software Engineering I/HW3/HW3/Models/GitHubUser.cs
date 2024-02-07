using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace HW3.Models
{
    public class GitHubUser : GitHubModel
    {
        public string UserName { get; set;}
        public string AvatarURL { get; set;}
        public string HtmlURL {get; set;}
        public string Name { get; set;}
        public string Company { get; set;}
        public string Location { get; set;}
        public string Email { get; set;}

        public void FromJson(string obj)
        {
            JObject user = JObject.Parse(obj);
            UserName = (string)user["login"];
            AvatarURL = (string)user["avatar_url"];
            Name = (string)user["name"];
            HtmlURL = (string)user["html_url"];
            Company = (string)user["company"];
            Location = (string)user["location"];
            Email = (string)user["email"];
        }
    }
}