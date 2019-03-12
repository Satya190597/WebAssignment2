using System.Web;

namespace UserRegistrationPortal.Services
{
    public interface IUploadFileService
    {
        /// <summary>
        /// Used To Upload A File In A Specific Directory
        /// </summary>
        void UploadFile(HttpPostedFileBase file, string destination = "~/Uploads/", string filename = null);
    }
}
