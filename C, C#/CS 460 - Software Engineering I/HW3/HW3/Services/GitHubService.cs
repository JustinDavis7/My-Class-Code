using HW3.Models;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using HW3.Models.DTO;
using System.Text.Json;
using Newtonsoft.Json;

namespace HW3.Services
{
    public class GitHubService : IGitHubService
    {
        public string BaseSource { get; }
        public string UserName;
        public string UserToken;

        public void SetCredentials(string username, string token)
        {
            UserName = username;
            UserToken = token;
        }
        public GitHubService (string token, string uri, string username)
        {
            BaseSource = uri;
            SetCredentials(username, token);
        }
        public GitHubUser GetUser()
        {
            string source = string.Format(BaseSource, "/user");
            string jsonResponse = GetJsonStringFromEndpoint(UserToken, source, UserName);
            Debug.WriteLine(jsonResponse);

            GitHubUser me = new GitHubUser();
            me.FromJson(jsonResponse);
            return me;
        }

        public IEnumerable<GitHubRepository> GetRepositories()
        {
            string source = string.Format(BaseSource, "/user/repos");
            string jsonResponse = GetJsonStringFromEndpoint(UserToken, source, UserName);
            var output = new List<GitHubRepository>();
            JArray repos = JArray.Parse(jsonResponse);

            for(int i = 0; i < repos.Count; i++)
            {
                GitHubRepository tempRepository = new GitHubRepository();
                tempRepository.FromJson(repos[i].ToString());
                output.Add(tempRepository);
            }
            return output;
        }

        public GitHubRepository GetRepository(string owner, string repositoryName)
        {
            string source = string.Format(BaseSource, "/repos/" + owner + "/" + repositoryName);
            string jsonResponse = GetJsonStringFromEndpoint(UserToken, source, UserName);

            GitJsonDTO? gitJsonDTO = null;
            try
            {
                gitJsonDTO = System.Text.Json.JsonSerializer.Deserialize<GitJsonDTO>(jsonResponse);
            }
            catch(System.Text.Json.JsonException)
            {
                // Log it, figure out how to handle
                gitJsonDTO = null;
            }

            if(gitJsonDTO != null)
            {
                var repo = new GitHubRepository(gitJsonDTO.name, gitJsonDTO.owner.login, gitJsonDTO.owner.url, gitJsonDTO.full_name, gitJsonDTO.owner.avatar_url, gitJsonDTO.updated_at);
                return repo;
            }

            return null;
        }

        public IEnumerable<GitHubCommit> GetCommits(string owner, string repositoryName)
        {
            string source = string.Format(BaseSource, "/repos/" + owner + "/" + repositoryName + "/commits");
            string jsonResponse = GetJsonStringFromEndpoint(UserToken, source, UserName);

            List<GitHubCommit> output = new List<GitHubCommit>();

            // Deserialize the string into POCO's (that we wrote)
            List<GitJsonDTO>? gitJsonDTO = null;
            try
            {
                gitJsonDTO = System.Text.Json.JsonSerializer.Deserialize<List<GitJsonDTO>>(jsonResponse);
            }
            catch(System.Text.Json.JsonException)
            {
                // Log it, figure out how to handle
                gitJsonDTO = null;
            }

            if(gitJsonDTO != null)
            {
                foreach(var commit in gitJsonDTO)
                {
                    var sha = commit.sha;
                    var message = commit.commit.message;
                    var name = commit.commit.committer.name;
                    var date = commit.commit.committer.date;
                    var url = commit.html_url;
                    
                    output.Add(new GitHubCommit(sha, name, date, message, url));
                }
                return output;
            }
            return Enumerable.Empty<GitHubCommit>();
        }

        public IEnumerable<GitHubBranch> GetBranches(string owner, string repositoryName)
        {
            string source = string.Format(BaseSource, "/repos/" + owner + "/" + repositoryName + "/branches");
            string jsonResponse = GetJsonStringFromEndpoint(UserToken, source, UserName);

            List<GitHubBranch> output = new List<GitHubBranch>();

            // Deserialize the string into POCO's (that we wrote)
            List<GitJsonDTO>? gitJsonDTO = null;
            try
            {
                gitJsonDTO = System.Text.Json.JsonSerializer.Deserialize<List<GitJsonDTO>>(jsonResponse);
            }
            catch(System.Text.Json.JsonException)
            {
                // Log it, figure out how to handle
                gitJsonDTO = null;
            }

            if(gitJsonDTO != null)
            {
                foreach(var commit in gitJsonDTO)
                {
                    output.Add(new GitHubBranch(commit.name));
                }
                return output;
            }
            return Enumerable.Empty<GitHubBranch>();
        }

        // This is a singleton, we are only supposed to have one per application
        // Better to use IHttpClientFactory with dependency injection but that's too much for this simple HW
        public static readonly HttpClient _httpClient = new HttpClient();

        public string GetJsonStringFromEndpoint(string token, string uri, string username)
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri)
            {
                Headers =
                    {
                        { "Accept", "application/json" },
                        { "Authorization", "token " + token},
                        { "User-Agent", username }
                    }
            };
            HttpResponseMessage response = _httpClient.Send(httpRequestMessage);
            // This is only a minimal version; make sure to cover all your bases here
            if (response.IsSuccessStatusCode)
            {
                // Note there is only an async version of this so to avoid forcing you to use all async I'm waiting for the result manually
                string responseText = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                return responseText;
            }
            else
            {
                // What to do if failure? 401? Should throw and catch specific exceptions that explain what happened
                return null;
            }
        }
    }
}