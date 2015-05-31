namespace TtitterMvc.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;

    using Ttitter.Data.Data;
    using TtitterMvc.Infrastructure.Services.Contracts;
    using TtitterMvc.ViewModels.Profiles;
    using Ttitter.Data.Models;
    using System.Net;
    using TtitterMvc.Infrastructure.ValidationErrors;

    [Authorize]
    public class ProfilesController : BaseController
    {
        private IProfileService profilesServices;
        private IAccountService accountServices;

        public ProfilesController(IBaseService baseService, IProfileService profilesService, IAccountService accountService)
            : base(baseService)
        {
            this.profilesServices = profilesService;
            this.accountServices = accountService;
        }

        // GET: Profiles
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetUserProfilesListItems()
        {
            var profileViewModels = this.profilesServices.GetUserProfiles();
            var activeProfile = this.profilesServices.GetUserActiveProfile();

            var model = new ProfileListItemViewModel
            {
                ProfileId = activeProfile,
                Profiles = profileViewModels.Select(pvm => new SelectListItem
                {
                    Value = pvm.Id.ToString(),
                    Text = pvm.Name
                })
            };

            return PartialView(model);
        }

        // POST: profiles/active
        [HttpPost]
        public ActionResult Active(int profileId)
        {
            try
            {
                this.accountServices.SetActiveProfileToUser(profileId);
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            catch (ValidationErrors verror)
            {
                ModelState.AddValidationErrors(verror);
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


        }

    }
}