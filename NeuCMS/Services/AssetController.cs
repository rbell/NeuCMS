using System.IO;
using System.Web.Mvc;

namespace NeuCMS.Services
{
    public class AssetController : Controller
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
