using System.IO;
using System.Web;

namespace UserRegistrationPortal.Services
{
    public class UploadFileServiceImplementation : IUploadFileService
    {
        public void UploadFile(HttpPostedFileBase file, string destination = "~/Uploads/Images/", string filename = null)
        {
            string path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath(destination), Path.GetFileName(filename==null ? file.FileName : filename));
            file.SaveAs(path);
        }
    }
}