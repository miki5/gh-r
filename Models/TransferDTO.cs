using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GitHubApplication.Models
{
    public class TransferDTO
    {
        [Required]
        public string Username { get; set; }

        [Display(Name = "Include User Repos preview")]
        public bool FullUserInfo { get; set; } = true;
    }
}