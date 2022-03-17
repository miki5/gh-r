using GitHubApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GitHubApplication.Controllers
{
    public class InfoController : Controller
    {
        public ActionResult NoContent()
        {
            return View();
        }

        public ActionResult ShowUserData()
        {
            UserHubResponse.UserGitHubInfo info = (UserHubResponse.UserGitHubInfo)TempData["gitHubUserData"];
            
            if (info == null)
               return RedirectToAction(nameof(WebController.GitHubUsername), "Web");

            return View(info);
        }
    }
}