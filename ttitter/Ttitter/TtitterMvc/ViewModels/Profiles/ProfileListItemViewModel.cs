using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TtitterMvc.ViewModels.Profiles
{
    public class ProfileListItemViewModel
    {
        [DisplayName("Active Profile")]
        public int? ProfileId { get; set; }

        public IEnumerable<SelectListItem> Profiles { get; set; }
    }
}