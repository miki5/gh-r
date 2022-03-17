using GitHubApplication.Interface;
using GitHubApplication.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using static GitHubApplication.Models.UserHubResponse;

namespace GitHubApplication.Services
{
    public class ClientWebService : IClientWebService
    {
        private const string SHOW_USER_ALL_REPOSITORY_INFO = "/repos";

        public String GetGitHubApi(TransferDTO hub)
        {
            return WebClientGitHubApi(hub.Username, false);
        }

        public UserGitHubInfo MapUserData(string responseData, bool fullUserInfo, string username)
        {
            UserGitHubInfo userGitHubInfo = new UserGitHubInfo();

            try
            {
                JToken jtoken = JToken.Parse(responseData);
                userGitHubInfo.GitHubUserInfo = jtoken.ToObject<GitHubUserInfo>();

                if (fullUserInfo)
                {
                    string responseDataRepos = WebClientGitHubApi(username, fullUserInfo);
                    jtoken = JToken.Parse(responseDataRepos);
                    userGitHubInfo.GitHubUserInfoRepos = jtoken.ToObject<List<GitHubUserInfoRepos>>();
                }

                if(userGitHubInfo.GitHubUserInfoRepos != null && userGitHubInfo.GitHubUserInfoRepos.Count > 0)
                    userGitHubInfo.StargazerRepos = userGitHubInfo.GitHubUserInfoRepos
                        .OrderByDescending(x => x.Stargazers_count)
                        .Take(5);

                return userGitHubInfo;
            }
            catch (JsonException ex)
            {
                throw new JsonException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private String WebClientGitHubApi(string username, bool fullUserInfo)
        {
            string fullInfo = fullUserInfo ? SHOW_USER_ALL_REPOSITORY_INFO : string.Empty;
            var url = $"https://api.github.com/users/{username}" + fullInfo;

            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "GET";
            request.ContentType = "application/json";
            request.UserAgent = "TestApp";
            try
            {
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    return reader.ReadToEnd();
                }
            }
            catch(Exception ex)
            {
                return null;
            }

        }

    }
}