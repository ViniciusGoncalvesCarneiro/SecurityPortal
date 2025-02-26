using Abp.AspNetCore.Mvc.Authorization;
using Abp.IO.Extensions;
using Abp.UI;
using Abp.Web.Models;
using GumAdvisor.SystemSurvey.Manager;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GumAdvisor.Web.Controllers
{
    public class SecuritySurveyController : GumAdvisorControllerBase
    {
        private readonly ISystemSurveyManager _systemSurveyManager;

        public SecuritySurveyController(ISystemSurveyManager systemSurveyManager)
        {
            _systemSurveyManager = systemSurveyManager;
        }

        [HttpPost]
        [AbpMvcAuthorize]
        public async Task<JsonResult> UploadAwser()
        {
            try
            {
                var file = Request.Form.Files[0];
                if (file == null)
                {
                    throw new UserFriendlyException(L("File_Empty_Error"));
                }

                if (file.Length > 10000000) //10MB
                {
                    throw new UserFriendlyException(L("File_SizeLimit_Error"));
                }

                byte[] fileBytes;
                using (var stream = file.OpenReadStream())
                {
                    fileBytes = stream.GetAllBytes();
                }

                string fileType = file.FileName.Split('-')[1];
                switch (fileType)
                {
                    case "ISO":
                        _systemSurveyManager.GetIsoFromImportedFile(fileBytes);
                        break;
                    case "MITRE":
                        _systemSurveyManager.GetMitreImportedFile(fileBytes);
                        break;
                    case "NIST":
                        _systemSurveyManager.GetNistImportedFile(fileBytes);
                        break;
                    case "CISTOISO":
                        // Falhou
                        //_systemSurveyManager.GetCisToIsoImportedFile(fileBytes);
                        // Falhou
                        break;
                    case "CISTOMITRE":
                        _systemSurveyManager.GetCisToMitreImportedFile(fileBytes);
                        break;
                    case "CISTONIST":
                        _systemSurveyManager.GetCisToNistImportedFile(fileBytes);
                        break;
                }

                return Json(new AjaxResponse(new
                {
                    //id = fileObject.Id,
                    name = file.FileName,
                    contentType = file.ContentType
                }));

            }
            catch (UserFriendlyException ex)
            {
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }
    }
}
