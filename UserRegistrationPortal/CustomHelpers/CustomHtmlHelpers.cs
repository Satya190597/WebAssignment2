using System.Web;
using System.Web.Mvc;
using UserRegistrationPortal.Models;

namespace UserRegistrationPortal.CustomHelpers
{
    public static class CustomHtmlHelpers
    {
        /// <summary>
        /// Used To Upload Image
        /// </summary>
        public static IHtmlString ImageUploader(this HtmlHelper helper,HtmlAttribute htmlAttribute)
        {
            TagBuilder tag = new TagBuilder("input");
            tag.Attributes.Add("type", "file");
            tag.Attributes.Add("id",htmlAttribute.Id);
            tag.Attributes.Add("name",htmlAttribute.Name);
            tag.Attributes.Add("class",htmlAttribute.Css);
            return new MvcHtmlString(tag.ToString());
        }
        /// <summary>
        /// Used To Display Image
        /// </summary>
       public static IHtmlString ImageRenderer(this HtmlHelper helper,HtmlAttribute htmlAttribute)
        {
            TagBuilder tag = new TagBuilder("img");
            tag.Attributes.Add("width",htmlAttribute.Width);
            tag.Attributes.Add("height", htmlAttribute.Height);
            tag.Attributes.Add("src", htmlAttribute.Src);
            tag.Attributes.Add("id", htmlAttribute.Id);
            tag.Attributes.Add("class", htmlAttribute.Css);
            return new MvcHtmlString(tag.ToString());
        }
    }
}