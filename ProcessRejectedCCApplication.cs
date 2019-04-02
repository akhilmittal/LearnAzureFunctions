using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;

namespace LearnAzureFunctions
{
  public static class ProcessRejectedCCApplication
  {
    [FunctionName("ProcessRejectedCCApplication")]
    public static void Run([BlobTrigger("rejected-application/{name}", Connection = "")]string ccApplicationJson,
      string name, TraceWriter log)
    {
      CCApplication ccApplication = JsonConvert.DeserializeObject<CCApplication>(ccApplicationJson);
      log.Info($"ProcessRejectedCCApplication Blob Trigger for \n Name:{ccApplication.Name}");
    }
  }
}
