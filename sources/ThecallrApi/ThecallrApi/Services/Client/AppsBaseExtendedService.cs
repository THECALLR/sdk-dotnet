using System.Collections.Generic;
using System.Linq;
using ThecallrApi.Json;
using ThecallrApi.Objects.Did;

namespace ThecallrApi.Services.Client
{
    /// <summary>
    /// This class acts as an extended base class for application services that adds Did manipulation.
    /// </summary>
    public abstract class AppsBaseExtendedService : AppsBaseService
    {
        #region Constructors
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="url">API url.</param>
        /// <param name="login">Login.</param>
        /// <param name="password">Password.</param>
        public AppsBaseExtendedService(string url, string login, string password) : base(url, login, password)
        {
        }

        /// <summary>
        /// Constructor with default API url.
        /// </summary>
        /// <param name="login">Login.</param>
        /// <param name="password">Password.</param>
        public AppsBaseExtendedService(string login, string password)
            : this(null, login, password)
        {
        } 
        #endregion

        #region Public methods
        /// <summary>
        /// This method assigns a DID to a Voice App.
        /// </summary>
        /// <param name="app">App ID.</param>
        /// <param name="did">DID ID.</param>
        /// <returns>Always <c>true</c>, throws an Exception otherwise.</returns>
        public bool AssignDid(string app, string did)
        {
            List<object> parameters = new List<object>() { app, did };
            JsonResponse response = this.client.MakeRequest("apps.assign_did", parameters);
            return true;
        }

        /// <summary>
        /// This method assigns the first available DID to a Voice App.
        /// </summary>
        /// <param name="app">App ID.</param>
        /// <returns><see cref="ThecallrApi.Objects.Did.Did" /> object representing the associated DID, otherwise null if none was found.</returns>
        /// <seealso cref="ThecallrApi.Objects.Did.Did"/>
        public Did AssignFirstAvailableDid(string app)
        {
            Did did = this.GetDids(true).FirstOrDefault();
            if (did != null)
                this.AssignDid(app, did.Hash);
            return did;
        }

        /// <summary>
        /// This method unassigns a DID from its Voice App.
        /// </summary>
        /// <param name="did">DID ID.</param>
        /// <returns>Always <c>true</c>, throws an Exception otherwise.</returns>
        public bool RemoveDid(string did)
        {
            List<object> parameters = new List<object>() { did };
            JsonResponse response = this.client.MakeRequest("apps.remove_did", parameters);
            return true;
        }

        /// <summary>
        /// This method retrieves the list of (available) DIDs assigned to your account.
        /// </summary>
        /// <param name="only_available">If <c>true</c>, return only available DIDs.</param>
        /// <returns><see cref="ThecallrApi.Objects.Did.Did" /> object list representing the list of DIDs assigned to your account.</returns>
        /// <seealso cref="ThecallrApi.Objects.Did.Did"/>
        public List<Did> GetDids(bool only_available)
        {
            List<object> parameters = new List<object>() { only_available };
            JsonResponse response = this.client.MakeRequest("apps.get_dids", parameters);
            return Helper.Creator<Did>.ObjectList(response.result, "result");
        }
        #endregion
    }
}
