﻿using System;
using System.ComponentModel.DataAnnotations;

namespace GitHubApplication.Models
{
    public partial class UserHubResponse
    {
        public class GitHubUserInfo
        {
            [Display(Name = "Username")]
            public string Login { get; set; }
            public int Id { get; set; }
            public string Node_id { get; set; }
            public string Avatar_url { get; set; }
            public string Gravatar_id { get; set; }
            public string Url { get; set; }
            public string Html_url { get; set; }
            public string Followers_url { get; set; }
            public string Following_url { get; set; }
            public string Gists_url { get; set; }
            public string Starred_url { get; set; }
            public string Subscriptions_url { get; set; }
            public string Organizations_url { get; set; }
            public string Repos_url { get; set; }
            public string Events_url { get; set; }
            public string Received_events_url { get; set; }
            public string Type { get; set; }
            public bool Site_admin { get; set; }
            
            [Display(Name = "User full name")]
            public string Name { get; set; }
            public string Company { get; set; }
            public string Blog { get; set; }

            [Display(Name = "User location")]
            public string Location { get; set; }
            public object Email { get; set; }
            public object Hireable { get; set; }
            public string Bio { get; set; }
            public object Twitter_username { get; set; }
            public int Public_repos { get; set; }
            public int Public_gists { get; set; }
            public int Followers { get; set; }
            public int Following { get; set; }
            public DateTime? Created_at { get; set; }
            public DateTime? Updated_at { get; set; }
        }
    }
}