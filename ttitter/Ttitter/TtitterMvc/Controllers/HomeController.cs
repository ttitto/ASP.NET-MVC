namespace TtitterMvc.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Ttitter.Data.Data;
    using TtitterMvc.Infrastructure.Services.Contracts;
    using TtitterMvc.ViewModels.Tteets;
    using Ttitter.Data.Models;

    public class HomeController : BaseController
    {
        private static readonly int tteetsPageSize = 10;

        private IHomeService homeService;
        private ITteetService tteetService;

        public HomeController(IBaseService baseService, IHomeService homeService, ITteetService tteetService)
            : base(baseService)
        {
            this.homeService = homeService;
            this.tteetService = tteetService;
        }

        public ActionResult Index(int? id)
        {
            int? page = id ?? 1;
            page = page < 1 ? 1 : page;

            IEnumerable<TteetViewModel> pagedTteetViewModels;

            if (this.Request.IsAjaxRequest())
            {
                pagedTteetViewModels = this.tteetService
                    .GetPagedPublicTteets(tteetsPageSize, (int)page)
                    .AsQueryable<Tteet>()
                    .Project()
                    .To<TteetViewModel>();

                return PartialView("_Tteets", pagedTteetViewModels);
            }

            pagedTteetViewModels = this.tteetService
                .GetPagedPublicTteets(tteetsPageSize, 1)
                .AsQueryable<Tteet>()
                   .Project()
                   .To<TteetViewModel>();

            return View("Index", pagedTteetViewModels);
        }
    }
}