using System.Collections.Generic;

namespace GitHubApplication.Models
{
    public partial class UserHubResponse
    {
        public partial class UserGitHubInfo
        {
            public GitHubUserInfo GitHubUserInfo { get; set; }
            public List<GitHubUserInfoRepos> GitHubUserInfoRepos { get; set; }
            public IEnumerable<GitHubUserInfoRepos> StargazerRepos { get; set; }
        }
    }
}