//using Newtonsoft.Json;
using System.Text.Json;
using System.Net;
using ToDoAppUsingRepositoryPattern.Infrastructure.Abstracts.ServerAbstracts;
using ToDoAppUsingRepositoryPattern.Infrastructure.Interfaces.ServerInterfases;
using ToDoAppUsingRepositoryPattern.Infrastructure.Models;
namespace ToDoAppUsingRepositoryPattern.Infrastructure.Server.RequestProcessor
{
    internal class HandlePostRequest : Response, IPostRequest
    {
        public async Task HandlePostRequestAsync<T>(HttpListenerRequest request, HttpListenerResponse response)
        {
            using StreamReader reader = new(request.InputStream);
            string requestBody = await reader.ReadToEndAsync();
            try
            {
                T model = JsonSerializer.Deserialize<T>(requestBody)!;

                Console.WriteLine(requestBody);

                ResponseModel<int> responseData = new(true, " Data received and processed successfully", 200);                
                await SendResponse(response, HttpStatusCode.OK, responseData);
            }
            catch (Exception ex)
            {
                ResponseModel<string> responseData = new(false, "Bad Request: Invalid request body format", ex.Message);

                await SendResponse(response, HttpStatusCode.BadRequest, responseData);
                await Console.Out.WriteLineAsync(ex.Message);
            }
        }
    }
}
