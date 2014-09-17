using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

/// <summary>
/// This class allows you to log messages.
/// </summary>
public class LogManager
{
    #region Member variables
    /// <summary>
    /// The path of the log file.
    /// </summary>
    public string LogFilePath { get; private set; } 
    #endregion

    #region Constructors
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="logFilePath">Log file path.</param>
    public LogManager(string logFilePath)
    {
        this.LogFilePath = logFilePath;
    } 
    #endregion

    #region Public methods
    /// <summary>
    /// This method allows you to log a message in the specified file.
    /// </summary>
    /// <param name="message">Message to log.</param>
    public void Log(string message)
    {
        using (StreamWriter sw = System.IO.File.AppendText(this.LogFilePath))
        {
            sw.WriteLine("[{0:G}]\t{1}", DateTime.Now, message);
        }
    } 
    #endregion
}