using System.Linq;
using System.Web.Mvc;
using NeuCMS.Core.Entities;
using NeuCMS.Repositories.EntityFramework;

namespace NeuCMS.Controllers
{
    public class AssetController : Controller
    {

        public ActionResult Index(int id)
        {
            using (var repository = new ContentRepository() )
            {
                var asset = (from content in repository.Contents.OfType<MediaContent>()
                                    where content.Id == id
                                    select content.DigitalAsset).FirstOrDefault();
                return base.File(asset.Data, asset.ContentType);
            }
        }

    }
}
