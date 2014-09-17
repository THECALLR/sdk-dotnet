using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// This class represents a connection between two steps.
/// </summary>
public class StepCommandConnection
{
    #region Member variables
    /// <summary>
    /// The command waiting result that will validate the redirection to the next step. 
    /// </summary>
    public string StepResult { get; private set; }

    /// <summary>
    /// Next step ID.
    /// </summary>
    public int NextStepId { get; private set; }
    #endregion

    #region Constructors
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="stepResult">Step result.</param>
    /// <param name="nextStepId">Next step ID.</param>
    public StepCommandConnection(string stepResult, int nextStepId)
    {
        this.StepResult = stepResult;
        this.NextStepId = nextStepId;
    } 
    #endregion
}