using HW3.Models;

namespace HW3.Services
{
    public interface IGitHubService
    {
        void SetCredentials(string username, string token);
        GitHubUser GetUser();
        IEnumerable<GitHubRepository> GetRepositories();
        GitHubRepository GetRepository(string owner, string repositoryName);
        IEnumerable<GitHubCommit> GetCommits(string owner, string repositoryName);
        IEnumerable<GitHubBranch> GetBranches(string owner, string repositoryName);
    }
}