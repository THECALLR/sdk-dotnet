using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// This class defines the different command results you can find in our example.
/// </summary>
public static class CommandResults
{
    /// <summary>
    /// Default result.
    /// </summary>
    public static readonly string DEFAULT = "__DEFAULT__";

    /// <summary>
    /// Error result.
    /// </summary>
    public static readonly string ERROR = "__ERROR__";

    /// <summary>
    /// Timeout result.
    /// </summary>
    public static readonly string TIMEOUT = "TIMEOUT";

    /// <summary>
    /// Successful result.
    /// </summary>
    public static readonly string SUCCESS = "0";
}