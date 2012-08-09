using System.Text;
using System.Web;
using System.Web.Mvc;

namespace NeuCMS.HtmlHelpers
{
    public static class JQModelHelper
    {
        public static HtmlString BeginJQModal(this HtmlHelper helper, string id, string title)
        {
            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext);
            var closeImgUrl = urlHelper.Content(@"~/Content/images/led-icons/cross.png");
            var content = string.Format(
                @"<div id='{0}' class='jqmWindow'>
                    <div class='jqmHeader'>
                        <div class='jqmHeaderTitle'>{1}</div>
                        <div class='jqmHeaderCloseButton'>
                            <input type='image' src='{2}' class='jqmClose'/>
                        </div>
                    </div>
                    <div class='jqmContent'>",
                id, title, closeImgUrl);
            return new HtmlString(content);
        }

        public static HtmlString EndJQMOdal(this HtmlHelper helper)
        {
            return new HtmlString("</div></div>");
        }
    }
}