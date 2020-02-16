using Google.Api.Gax.ResourceNames;
using Google.Cloud.ErrorReporting.V1Beta1;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeechToText
{
    class GCErrorReporting
    {
        private string project_id = "";

        public void report(Exception e)
        {
            // Create the report and execute the request.
            var reporter = ReportErrorsServiceClient.Create();

            // Get the project ID from the json file
            using (StreamReader r = new StreamReader("../../../S2TPrivateKey.json"))
            {
                string json = r.ReadToEnd();
                project_id = Newtonsoft.Json.Linq.JObject.Parse(json)["project_id"].ToString();
            }
            var projectName = new ProjectName(project_id);//construct the ProjectName object

            // Add a service context to the report. For more details see:
            // https://cloud.google.com/error-reporting/reference/rest/v1beta1/projects.events#ServiceContext
            ServiceContext serviceContext = new ServiceContext()
            {
                Service = "SpeechToText",
                Version = "0.1",
            };
            ReportedErrorEvent errorEvent = new ReportedErrorEvent()
            {
                Message = e.ToString(),
                ServiceContext = serviceContext,
            };
            reporter.ReportErrorEvent(projectName, errorEvent);
        }

    }
}
