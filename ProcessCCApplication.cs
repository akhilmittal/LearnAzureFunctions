using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;

namespace LearnAzureFunctions
{
  public static class ProcessCCApplication
  {
    [FunctionName("ProcessCCApplication")]
    public static void Run([QueueTrigger("ccapplication", Connection = "")]CCApplication ccApplication,
      [Blob("accepted-application/{rand-guid}")] out string acceptedCCApplication,
      [Blob("rejected-application/{rand-guid}")] out string rejectedCCApplication,
      TraceWriter log)
    {
      log.Info($"C# Queue trigger function processed: {ccApplication.Name}");

      bool isApplicationAccepted = ccApplication.YearlyIncome > 100000 && ccApplication.Age > 23;

      if (isApplicationAccepted)
      {
        acceptedCCApplication = JsonConvert.SerializeObject(ccApplication);
        rejectedCCApplication = null;
      }
      else
      {
        rejectedCCApplication = JsonConvert.SerializeObject(ccApplication);
        acceptedCCApplication = null;
      }

    }
  }
}
