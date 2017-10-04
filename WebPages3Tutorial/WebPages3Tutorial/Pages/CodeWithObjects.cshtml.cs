using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebPages3Tutorial.Pages
{
    public class CodeWithObjectsModel : PageModel
    {
        public string RequestUrl { get; set; }
		public string FilePath { get; set; }
		public string MapPath { get; set; }
		public string RequestType { get; set; }

        public void OnGet()
        {
            RequestUrl = Url.Action();  // abosolute pathname for this action method
            FilePath = Request.Path;
            MapPath = Request.PathBase;
            RequestType = Request.Protocol;

        }
    }
}
