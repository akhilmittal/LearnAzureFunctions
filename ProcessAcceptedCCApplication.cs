using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;

namespace LearnAzureFunctions
{
  public static class ProcessAcceptedCCApplication
  {
    [FunctionName("ProcessAcceptedCCApplication")]
    public static void Run([BlobTrigger("accepted-application/{name}",
          Connection = "")]string ccApplicationJson, string name, TraceWriter log)
    {
      CCApplication ccApplication = JsonConvert.DeserializeObject<CCApplication>(ccApplicationJson);
      log.Info($"ProcessAcceptedCCApplication Blob Trigger for \n Name:{ccApplication.Name}");
    }
  }
}
