using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HW3.Models;
using HW3.Services;

namespace HW3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }

    [Route("[controller]")]
    [ApiController]
    public class APIController : ControllerBase
    {
        private readonly ILogger<APIController> _logger;
        private readonly IGitHubService _user;
        public APIController(ILogger<APIController> logger, IGitHubService user)
        {
            _logger = logger;
            _user = user;
        }

        [HttpGet("user")]
        public ActionResult User()
        {
            GitHubUser user = _user.GetUser();
            return Ok(user);
        }

        [HttpGet("repositories")]
        public ActionResult Repositories()
        {
            IEnumerable<GitHubRepository> repository = _user.GetRepositories();
            return Ok(repository);
        }

        [HttpGet("repository")]
        public ActionResult Repository(string owner, string repositoryName)
        {
            GitHubRepository repo = _user.GetRepository(owner, repositoryName);
            return Ok(repo);
        }

        [HttpGet("branches")]
        public ActionResult Branches(string owner, string repositoryName)
        {
            IEnumerable<GitHubBranch> branch = _user.GetBranches(owner, repositoryName);
            return Ok(branch);
        }

        [HttpGet("commits")]
        public ActionResult Commits(string owner, string repositoryName)
        {
            IEnumerable<GitHubCommit> commits = _user.GetCommits(owner, repositoryName);
            return Ok(commits);
        }
    }

}