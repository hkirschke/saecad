using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;

using Google.Apis.Auth.OAuth2.Mvc;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
 
using SisAdot.OAuth;

namespace SisAdot.Controllers
{
  public class HomeController : Controller
  {
    public async Task<ActionResult> IndexAsync(CancellationToken cancellationToken)
    {
      var result = await new AuthorizationCodeMvcApp(this, new AppFlowMetadata()).
          AuthorizeAsync(cancellationToken);

      if (result.Credential != null)
      {
        var service = new DriveService(new BaseClientService.Initializer
        {
          HttpClientInitializer = result.Credential,
          ApplicationName = "SisAdot"
        });

        // YOUR CODE SHOULD BE HERE..
        // SAMPLE CODE:
        var list = await service.Files.List().ExecuteAsync();
        ViewBag.Message = "FILE COUNT IS: " + list.Files.Count();
        return View();
      }
      else
      {
        return new RedirectResult(result.RedirectUri);
      }
    }
  }
}