using System;
using System.Net.Http;
using System.Threading.Tasks;
using FallenTemple.Stockfighter.Common.Models;

namespace FallenTemple.Stockfighter.StockExchange
{
    internal static class StockExchangeUtility
    {
        /// <summary>
        /// Converts the response into an actual model if possible; if not, sets
        /// <see cref="BaseModel.IsSuccess"/> = false and 
        /// </summary>
        /// <typeparam name="T">Model type to create from the HTTP response.</typeparam>
        /// <param name="response">HTTP response to convert into a model.</param>
        /// <returns>Model converted from the HTTP response, or a model with an
        /// appropriate <see cref="BaseModel.ErrorMessage"/> if conversion fails.</returns>
        public static async Task<T> GetResponseOrErrorModel<T>(HttpResponseMessage response) where T : BaseModel
        {
            try
            {
                var result = response.Content.ReadAsAsync<T>().ConfigureAwait(false);
                return await result;
            }
            catch (Exception)
            {
                T result = Activator.CreateInstance<T>();
                result.IsSuccess = false;
                result.ErrorMessage = "Failed to convert the HTTP response into a " + typeof(T).Name + " object.";
                return result;
            }
        }
    }
}
