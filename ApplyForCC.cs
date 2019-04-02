using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace LearnAzureFunctions
{
  public static class ApplyForCC
  {
    [FunctionName("ApplyForCC")]
    [return: Queue("ccApplication")]
    public static async Task<CCApplication> Run(
      [HttpTrigger(AuthorizationLevel.Function,
          "post",
          Route = null)]HttpRequestMessage req,
      //[Queue("ccApplication")] IAsyncCollector<CCApplication> applicationQueue,
      TraceWriter log)
    {
      log.Info("C# HTTP trigger function processed a request.");

      CCApplication ccApplication = await req.Content.ReadAsAsync<CCApplication>();
      log.Info($"Received Credit Card Application from : {ccApplication.Name }");
      //await applicationQueue.AddAsync(ccApplication);
      return ccApplication;
      //return req.CreateResponse(HttpStatusCode.OK,
      //  $"Application received and submitted for {ccApplication.Name}");
    }
  }
}