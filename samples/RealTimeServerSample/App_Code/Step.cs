using System;
using System.Collections.Generic;
using ThecallrApi.Objects.RealTime;

/// <summary>
/// This class represents a scenario step.
/// </summary>
public class Step
{
    #region Member variables
    /// <summary>
    /// Step ID.
    /// </summary>
    public int StepId { get; private set; }

    /// <summary>
    /// The Real Time response object returned by API RealTime service methods.
    /// </summary>
    public RealTimeResponse Response { get; private set; }

    /// <summary>
    /// The list of current step connections with other steps.
    /// </summary>
    public List<StepCommandConnection> Connections { get; private set; }

    /// <summary>
    /// A string containing the variable name to replace in reponse with a read command result (optional).
    /// </summary>
    public string ResultVarName { get; private set; }
    #endregion

    #region Constructors
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="stepId">Step ID.</param>
    /// <param name="response">The Real Time response object returned by API RealTime service methods.</param>
    /// <param name="resultVarName">A string containing the variable name to replace in reponse with a read command result (optional).</param>
    public Step(int stepId, RealTimeResponse response, string resultVarName = null)
    {
        this.StepId = stepId;
        this.Response = response;
        this.Connections = new List<StepCommandConnection>();
        this.ResultVarName = resultVarName;
    } 
    #endregion
}