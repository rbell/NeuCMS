using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lib.Web.Mvc.JQuery.JqGrid;
using NeuCMS.Models;
using NeuCMS.Repositories.EntityFramework;

namespace NeuCMS.Controllers
{
    public class NameSpaceConfigurationController : Controller
    {
        //
        // GET: /NameSpaces/

        public ActionResult Index()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult NameSpaces(JqGridRequest request)
        {
            using (var db = new ContentRepository())
            {
                var nameSpaceQry = from n in db.NameSpaces orderby n.Id select n;

                var totalRecs = db.NameSpaces.Count();
                var response = new JqGridResponse()
                                   {
                                       TotalPagesCount =
                                           (int) Math.Ceiling((float) totalRecs/(float) request.RecordsCount),
                                       PageIndex = request.PageIndex,
                                       TotalRecordsCount = totalRecs
                                   };

                var nameSpaces = nameSpaceQry
                    .Skip(request.PageIndex*request.RecordsCount)
                    .Take((request.PagesCount.HasValue ? request.PagesCount.Value : 1)*request.RecordsCount).ToList();

                var jqGridRecords = from n in nameSpaces
                        select new JqGridRecord<NameSpaceGridModel>(
                            n.Id.ToString(),
                            new NameSpaceGridModel(n));

                response.Records.AddRange(jqGridRecords);

                return new JqGridJsonResult() { Data = response };
            }
        }

        public ActionResult SaveNameSpace(NameSpaceGridModel model)
        {
            return null;
        }

    }
}
