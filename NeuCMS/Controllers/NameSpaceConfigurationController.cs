using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lib.Web.Mvc.JQuery.JqGrid;
using NeuCMS.Core.Entities;
using NeuCMS.Models;
using NeuCMS.Repositories.EntityFramework;
using NeuCMS.Serializers;

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

        public ActionResult EditNameSpace(int id)
        {
            PartialViewResult partial = null;

            if (id == 0)
            {
                partial = PartialView("EditNameSpace", new NameSpaceGridModel());
            }
            else
            {
                using (var db = new ContentRepository())
                {
                    var nameSpaceQry = from n in db.NameSpaces
                                       where n.Id == id
                                       select
                                           new NameSpaceGridModel()
                                               {Description = n.Description, Id = n.Id, NameSpaceName = n.NameSpaceName};
                    partial = PartialView("EditNameSpace", nameSpaceQry.FirstOrDefault());
                }
            }

            return partial;
        }

        [HttpPost]
        public ActionResult SaveNameSpace([FromURLEncodedJson]NameSpaceGridModel nameSpace)
        {
            if (nameSpace.Id == 0)
            {
                var ns = new NameSpace();
                ns.Description = nameSpace.Description;
                ns.NameSpaceName = nameSpace.NameSpaceName;
                using (var db = new ContentRepository())
                {
                    db.NameSpaces.Add(ns);
                    db.SaveChanges();
                    db.Commit();
                }
            }
            else
            {
                using (var db = new ContentRepository())
                {
                    var nameSpaceQry = from n in db.NameSpaces where n.Id == nameSpace.Id select n;
                    if (nameSpaceQry.Any())
                    {
                        var ns = nameSpaceQry.First();
                        ns.Description = nameSpace.Description;
                        ns.NameSpaceName = nameSpace.NameSpaceName;
                        db.SaveChanges();
                        db.Commit();
                    }
                }
            }
            return View("Index");
        }

    }
}
