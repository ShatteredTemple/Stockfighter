using System.Runtime.Serialization;

namespace FallenTemple.Stockfighter.Common.Models
{
    /// <summary>
    /// Base class for stock exchange API results.
    /// </summary>
    [DataContract]
    public abstract class BaseModel
    {
        /// <summary>
        /// Whether the API call was a success.
        /// </summary>
        [DataMember(Name = "ok")]
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Error message from the exchange API (if any).
        /// </summary>
        [DataMember(Name = "error")]
        public string ErrorMessage { get; set; }
    }
}
