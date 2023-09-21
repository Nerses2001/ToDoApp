using Newtonsoft.Json;
using System.Net;
using System.Text;
using ToDoAppUsingRepositoryPattern.Core.Models;

namespace ToDoAppUsingRepositoryPattern.Core.Abstractions.ServerAbstracts
{
    abstract class Response
    {
        protected virtual async Task SendResponse<T>(HttpListenerResponse response, HttpStatusCode statusCode, ResponseModel<T> responseData)
        {
            string jsonResponse = JsonConvert.SerializeObject(responseData);
            byte[] buffer = Encoding.UTF8.GetBytes(jsonResponse);

            response.ContentType = "application/json";
            response.StatusCode = (int)statusCode;
            response.ContentLength64 = buffer.Length;

            await response.OutputStream.WriteAsync(buffer);

            response.Close();
        }
    }
}
