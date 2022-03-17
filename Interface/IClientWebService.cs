using GitHubApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GitHubApplication.Models.UserHubResponse;

namespace GitHubApplication.Interface
{
    public interface IClientWebService
    {
        String GetGitHubApi(TransferDTO hub);
        UserGitHubInfo MapUserData(string responseData, bool fullUserInfo, string username);
    }
}
