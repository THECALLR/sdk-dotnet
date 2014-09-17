using System;
using System.IO;
using System.Web.Script.Serialization;
using ThecallrApi.Objects.RealTime;
using ThecallrApi.Services.Server;

/// <summary>
/// This page is an example of Real Time in order to show you one basic implementation method.
/// You are free to make your own one !
/// </summary>
public partial class RealTime : System.Web.UI.Page
{
    #region Member variables
    /// <summary>
    /// Log manager.
    /// </summary>
    private LogManager LogManager = new LogManager("C:\\temp\\realtime_log.txt");
    #endregion

    #region Page events
    /// <summary>
    /// This method is called when the page is loaded.
    /// </summary>
    protected void Page_Load(object sender, EventArgs e)
    {
        // Verify that's a JSON POST
        if (this.Request.HttpMethod == "POST" && this.Request.ContentType.ToLower() == "application/json")
        {
            try
            {
                // Request processing
                string response = this.RequestProcessing();
                if (!string.IsNullOrEmpty(response))
                {
                    // Write the JSON response
                    this.Response.ClearHeaders();
                    this.Response.ClearContent();
                    this.Response.ContentType = "application/json";
                    this.Response.Write(response);
                }
            }
            catch (Exception ex)
            {
                // Read your log file to see errors
                this.LogManager.Log(string.Format("[ERROR] {0}", ex.Message));
            }
        }
    } 
    #endregion

    #region Private methods
    /// <summary>
    /// This method processes the JSON request and returns the JSON response.
    /// </summary>
    /// <returns>The JSON response.</returns>
    private string RequestProcessing()
    {
        // JSON request and response containers
        string resultJsonResponse = null;
        string currentJsonRequest;
        // 1 - Get POST content
        using (StreamReader sr = new StreamReader(this.Request.InputStream))
        {
            currentJsonRequest = sr.ReadToEnd();
        }
        // Request Log
        this.LogManager.Log("-------------------------------------------------");
        this.LogManager.Log(string.Format("[REQUEST] {0}", currentJsonRequest));
        // We use the JavascriptSerializer to Serialize and Deserialize JSON you can find it in System.Web.Script.Serialization)
        JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
        // Initialize the JSON Serializer with our customer converter
        jsSerializer.RegisterConverters(new[] { new RealTimeResponseJavascriptConverter() });
        // 2 - Get the deserialized Request object from JSON
        RealTimeRequest currentRequestObject = jsSerializer.Deserialize<RealTimeRequest>(currentJsonRequest);
        if (currentRequestObject != null)
        {
            if (currentRequestObject.app == "__APP_ID__")
            {
                RealTimeService service = new RealTimeService();
                RealTimeResponse response = null;
                // 3 - Get the sequence to process
                int sequence = 0;
                if (!string.IsNullOrEmpty(currentRequestObject.command_error))
                    sequence = 999;
                else if (currentRequestObject.variables != null && currentRequestObject.variables.ContainsKey("sequence"))
                    sequence = (int)currentRequestObject.variables["sequence"];
                // 4 - Process the corresponding sequence
                switch (sequence)
                {
                    case 0:
                        response = service.Play("TTS|NUANCE_FR_AUDREY|Bonjour et bienvenue sur notre service, veuillez enregistrer vos nom et prénom");
                        break;
                    case 1:
                        response = service.Record(2, 10);
                        break;
                    case 2:
                        response = service.Play("TTS|NUANCE_FR_AUDREY|Vous vous appelez");
                        response.Variables["media_file"] = currentRequestObject.command_result;
                        break;
                    case 3:
                        response = service.PlayRecord(currentRequestObject.variables["media_file"].ToString());
                        break;
                    case 4:
                        response = service.Hangup();
                        break;
                    case 999:
                        response = service.Play(string.Format("TTS|NUANCE_FR_VIRGINIE|Aïe, l'erreur {0} vient d'être interceptée.", currentRequestObject.command_error));
                        break;
                    default:
                        response = service.Hangup();
                        break;
                }
                // Initialize command ID
                response.CommandId = new Random().Next(1, int.MaxValue);
                // Initialize next sequence
                response.Variables["sequence"] = sequence + 1;
                // 5 - Generate JSON response
                resultJsonResponse = jsSerializer.Serialize(response);
            }
            else
                throw new System.Exception(string.Format("The application ID '{0}' is unknown.", currentRequestObject.app));
        }
        else
            throw new System.Exception("Current request object is null.");
        // Reponse log
        this.LogManager.Log(string.Format("[RESPONSE] {0}", resultJsonResponse));
        this.LogManager.Log("-------------------------------------------------");
        return resultJsonResponse;
    }
    #endregion
}