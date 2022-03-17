using GitHubApplication.Interface;
using GitHubApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GitHubApplication.Controllers
{
    public class WebController : Controller
    {
        IClientWebService _clientWebService;
        public WebController(IClientWebService clientWebService)
        {
            this._clientWebService = clientWebService;
        }

        // GET: Web view
        public ActionResult GitHubUsername()
        {
            TransferDTO model = new TransferDTO();
            return View(model);
        }

        // GET: Post data to the Github api and get User info
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult GitHubUsername(TransferDTO model)
        {
            if (model is null)
                throw new ArgumentNullException(nameof(model));

            if (string.IsNullOrWhiteSpace(model.Username))
                return View();

            var responseApi = this._clientWebService.GetGitHubApi(model);

            if (string.IsNullOrWhiteSpace(responseApi))
                return RedirectToAction(nameof(InfoController.NoContent), "Info");

            var userData = this._clientWebService.MapUserData(responseApi, model.FullUserInfo, model.Username);

            if (userData != null)
            {
                TempData["gitHubUserData"] = userData;
                return RedirectToAction(nameof(InfoController.ShowUserData), "Info");
            }

            return View(model);
        }

    }
}