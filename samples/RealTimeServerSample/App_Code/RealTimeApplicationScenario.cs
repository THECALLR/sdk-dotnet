using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThecallrApi.Objects;
using ThecallrApi.Objects.Misc;
using ThecallrApi.Services.Server;

/// <summary>
/// This class allows you to define an application scenario.
/// </summary>
public class RealTimeApplicationScenario
{
    #region Member variables
    /// <summary>
    /// Application ID.
    /// </summary>
    public string AppId { get; private set; }

    /// <summary>
    /// A dictionary storing every steps of the Real Time application scenario.
    /// </summary>
    public Dictionary<int, Step> Steps { get; private set; }

    /// <summary>
    /// The Real Time service that calls Real Time methods.
    /// </summary>
    private RealTimeService Service { get; set; }
    #endregion

    #region Constructors
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="appId">The application ID.</param>
    public RealTimeApplicationScenario(string appId)
    {
        this.AppId = appId;
        this.Service = new RealTimeService();
        this.Steps = new Dictionary<int, Step>();
        // Add default hangup step
        this.AddHangupStep(int.MaxValue);
    } 
    #endregion

    #region Public methods
    /// <summary>
    /// This method makes another call, and bridges the call on answer.
    /// </summary>
    /// <param name="stepId">The ID of the step we are defining.</param>
    /// <param name="cdrField">Value written in the CDR.</param>
    /// <param name="cli">Outbound Caller ID.</param>
    /// <param name="ringtone">Plays music or classic ringtone (possible values are defined in <see cref="ThecallrApi.Enums.RealTimeRingtones"/> class).</param>
    /// <param name="targets">Phone numbers called sequentially until one answers.</param>
    /// <param name="whisper">Callee whispering Media.</param>
    /// <param name="resultVarName">If the result has to be stored in a variable, specify the variable name (optional).</param>
    public void AddDialoutStep(int stepId, string cdrField, string cli, string ringtone, List<Target> targets, string whisper, string resultVarName = null)
    {
        Step parameters = new Step(stepId, this.Service.Dialout(cdrField, cli, ringtone, targets, whisper), resultVarName);
        this.Steps.Add(stepId, parameters);
    }

    /// <summary>
    /// This method hangs up the call.
    /// </summary>
    /// <param name="stepId">The ID of the step we are defining.</param>
    /// <param name="resultVarName">If the result has to be stored in a variable, specify the variable name (optional).</param>
    public void AddHangupStep(int stepId, string resultVarName = null)
    {
        Step parameters = new Step(stepId, this.Service.Hangup(), resultVarName);
        this.Steps.Add(stepId, parameters);
    }

    /// <summary>
    /// This method plays a Media.Library or say something with the Text-to-Speech.
    /// </summary>
    /// <param name="stepId">The ID of the step we are defining.</param>
    /// <param name="media_id">Media ID or Text to say.</param>
    /// <param name="resultVarName">If the result has to be stored in a variable, specify the variable name (optional).</param>
    public void AddPlayStep(int stepId, string media_id, string resultVarName = null)
    {
        Step parameters = new Step(stepId, this.Service.Play(media_id), resultVarName);
        this.Steps.Add(stepId, parameters);
    }

    /// <summary>
    /// This method plays a recording recorded with the <see cref="Record"/> command.
    /// </summary>
    /// <param name="stepId">The ID of the step we are defining.</param>
    /// <param name="media_file">Temporary file name.</param>
    /// <param name="resultVarName">If the result has to be stored in a variable, specify the variable name (optional).</param>
    public void AddPlayRecordStep(int stepId, string media_file, string resultVarName = null)
    {
        Step parameters = new Step(stepId, this.Service.PlayRecord(media_file), resultVarName);
        this.Steps.Add(stepId, parameters);
    }

    /// <summary>
    /// This method plays a Media and wait for a DTMF input at the same time.
    /// </summary>
    /// <param name="stepId">The ID of the step we are defining.</param>
    /// <param name="attempts">Maximum attempts. min:1 max:10.</param>
    /// <param name="maxDigits">Maximum digits. min:1 max:20.</param>
    /// <param name="mediaId">Prompt message.</param>
    /// <param name="timeoutMs">Input timeout in milliseconds. min:100 max:30000.</param>
    /// <param name="resultVarName">If the result has to be stored in a variable, specify the variable name (optional).</param>
    public void AddReadStep(int stepId, int attempts, int maxDigits, string mediaId, int timeoutMs, string resultVarName = null)
    {
        Step parameters = new Step(stepId, this.Service.Read(attempts, maxDigits, mediaId, timeoutMs), resultVarName);
        this.Steps.Add(stepId, parameters);
    }

    /// <summary>
    /// This method records the user.
    /// The recording can be stopped by pressing the hash key '#', when silence is detected, or when maximum recording duration is reached.
    /// </summary>
    /// <param name="stepId">The ID of the step we are defining.</param>
    /// <param name="maxDuration">(seconds) Maximum recording duration. Min:0 (disabled), Max:300.</param>
    /// <param name="silence">(seconds) Stop recording on silence. Min:0 (disabled), Max:20.</param>
    /// <param name="resultVarName">If the result has to be stored in a variable, specify the variable name (optional).</param>
    public void AddRecordStep(int stepId, int maxDuration, int silence, string resultVarName = null)
    {
        Step parameters = new Step(stepId, this.Service.Record(maxDuration, silence), resultVarName);
        this.Steps.Add(stepId, parameters);
    }

    /// <summary>
    /// This method sends DTMF digits.
    /// </summary>
    /// <param name="stepId">The ID of the step we are defining.</param>
    /// <param name="digits">Digits to send (0-9, , #). Example : "123#".</param>
    /// <param name="durationMs">(milliseconds) Duration of each digit. Min: 1, Max: 5000.</param>
    /// <param name="timeoutMs">(milliseconds) Amount of time between tones. Min: 0, Max: 10000.</param>
    /// <param name="resultVarName">If the result has to be stored in a variable, specify the variable name (optional).</param>
    public void AddSendDtmfStep(int stepId, string digits, int durationMs, int timeoutMs, string resultVarName = null)
    {
        Step parameters = new Step(stepId, this.Service.SendDtmf(digits, durationMs, timeoutMs), resultVarName);
        this.Steps.Add(stepId, parameters);
    }

    /// <summary>
    /// This method waits for a few seconds.
    /// </summary>
    /// <param name="stepId">The ID of the step we are defining.</param>
    /// <param name="wait">(seconds) Time to wait. Min:1, Max: 30.</param>
    /// <param name="resultVarName">If the result has to be stored in a variable, specify the variable name (optional).</param>
    public void AddWaitStep(int stepId, int wait, string resultVarName = null)
    {
        Step parameters = new Step(stepId, this.Service.Wait(wait), resultVarName);
        this.Steps.Add(stepId, parameters);
    }

    /// <summary>
    /// This method waits until silence is detected, or timeout is reached.
    /// </summary>
    /// <param name="stepId">The ID of the step we are defining.</param>
    /// <param name="iterations">Number of times to try. Min:1, Max:10.</param>
    /// <param name="silenceMs">(milliseconds) Minimum silence duration. Min:1, Max:5000.</param>
    /// <param name="timeout">(seconds) Global timeout if silence is not detected. Min:0 (disabled), Max:300.</param>
    /// <param name="resultVarName">If the result has to be stored in a variable, specify the variable name (optional).</param>
    public void AddWaitForSilenceStep(int stepId, int iterations, int silenceMs, int timeout, string resultVarName = null)
    {
        Step parameters = new Step(stepId, this.Service.WaitForSilence(iterations, silenceMs, timeout), resultVarName);
        this.Steps.Add(stepId, parameters);
    }

    /// <summary>
    /// This method adds a new connection between two steps.
    /// </summary>
    /// <param name="stepId">The ID of the step we are making a connection to a new one.</param>
    /// <param name="stepResult">The expected result to validate the connection.</param>
    /// <param name="nextStepId">The ID of the next step we are defining.</param>
    public void AddStepCommandConnection(int stepId, string stepResult, int nextStepId)
    {
        if (this.Steps.ContainsKey(stepId))
        {
            this.Steps[stepId].Connections.Add(new StepCommandConnection(stepResult, nextStepId));
        }
    }

    /// <summary>
    /// This method retrieves the next step of the one specified by its ID.
    /// </summary>
    /// <param name="stepId">The parent ID of the step we are looking for.</param>
    /// <param name="stepResult">The step result we are looking for (optional).</param>
    /// <returns>The next step, or null if not found.</returns>
    public Step GetNextStep(int stepId, string stepResult = null)
    {
        Step nextStep = null;
        Step defaultStep = null;
        if (stepId == 0)
        {
            int first_step = this.Steps.Keys.Min();
            nextStep = this.Steps[first_step];
        }
        else if (this.Steps.ContainsKey(stepId) && this.Steps[stepId].Connections.Count > 0)
        {
            foreach (StepCommandConnection connection in this.Steps[stepId].Connections)
            {
                if (connection.StepResult == stepResult)
                {
                    if (this.Steps.ContainsKey(connection.NextStepId))
                        nextStep = this.Steps[connection.NextStepId];
                    break;
                }
                else if (connection.StepResult == CommandResults.DEFAULT)
                     defaultStep = this.Steps[connection.NextStepId];
            }
        }
        else
            nextStep = this.Steps[int.MaxValue];
        return nextStep ?? defaultStep;
    }
    #endregion
}