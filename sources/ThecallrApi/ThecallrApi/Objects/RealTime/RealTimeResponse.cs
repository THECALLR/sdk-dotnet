using System.Collections.Generic;

namespace ThecallrApi.Objects.RealTime
{
    /// <summary>
    /// This class represents a Real-Time Response (Your response to our requests).
    /// </summary>
    public class RealTimeResponse
    {
        #region Member variables
        /// <summary>
        /// Command ID. Use the value you want. We will send this ID back when we have the result ready. Useful to keep track of your scenario.
        /// </summary>
        public int CommandId { get; set; }

        /// <summary>
        /// The command we have to execute (see the commands list in Real-Time).
        /// </summary>
        public string Command { get; private set; }

        /// <summary>
        /// Command parameters. See the Real-Time commands.
        /// </summary>
        public Dictionary<string, object> Params { get; private set; }

        /// <summary>
        /// Key/Value object. You can fill this object with anything, we will send it back without touching it in our next request. You can use this as a session object.
        /// </summary>
        public Dictionary<string, object> Variables { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="command">Commnd name.</param>
        public RealTimeResponse(string command)
        {
            this.Command = command;
            this.Params = new Dictionary<string, object>();
            this.Variables = new Dictionary<string, object>();
        }
        #endregion
    }
}
