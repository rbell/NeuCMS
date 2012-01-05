using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NeuCMS.Controllers
{
    public class AssetsController : Controller
    {
        //
        // GET: /Asset/

        public ActionResult Asset(string id)
        {
            var dir = Server.MapPath("/Content");
            var path = Path.Combine(dir, id + ".jpg");
            return base.File(path, "image/jpeg");
        }

    }
}
