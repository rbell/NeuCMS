using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeuCMS.Platforms.MVC3
{
    public static class ContentManger
    {
        public static void InitContent(dynamic viewBag)
        {
            viewBag.NeuCMS = new Content();
        }
    }

    public class Content
    {
        public Content()
        {
            Message = "ASP.NET MVC Website!";
        }

        public string Message { get; set; }
    }
}
