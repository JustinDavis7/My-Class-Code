using Microsoft.AspNetCore.Authentication;

namespace HW3.Models.DTO
{
    #nullable disable
    public class GitJsonDTO
    {
        public string sha {get; set;}
        public Commit commit {get; set;}
        public Owner owner {get; set;}
        public string url {get; set;}
        public string name {get; set;}
        public string full_name {get; set;}
        public DateTime updated_at {get; set;}
        public string html_url {get; set;}
    }

    public class Commit
    {
        public Committer committer {get; set;}
        public string message {get; set;}
    }

    public class Owner
    {
        public string login {get; set;}   
        public string url {get; set;}
        public string avatar_url {get; set;}
    }

    public class Url
    {
        public string url {get; set;}
    }

    public class Committer
    {
        public string name {get; set;}
        public DateTime date {get; set;}
    }
}