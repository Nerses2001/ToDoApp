using System.Net;
using ToDoAppUsingRepositoryPattern.Infrastructure.Abstracts.ServerAbstracts;
using ToDoAppUsingRepositoryPattern.Infrastructure.Interfaces.RepasitoryInterfaces;
using ToDoAppUsingRepositoryPattern.Infrastructure.Interfaces.ServerInterfases;
using ToDoAppUsingRepositoryPattern.Infrastructure.Server.RequestProcessor;

namespace ToDoAppUsingRepositoryPattern.Infrastructure.Server
{
    internal class ServerProvider:BaseServerProvider,IServerProvider,IDisposable
    {
        private readonly HttpListener _listener;
      //  private readonly IUserRepository _userRepository;
        private readonly IRequestProcessor _request;

        public ServerProvider(IRequestProcessor request)
        {
            this._listener = new();
            _listener.Prefixes.Add($"{baseUrl}:{port}/");

            this._request = request;
        }

      
        public async Task StartAsync()
        {
            Console.WriteLine("Listening for requests...");
            Console.WriteLine($"{baseUrl}:{port}/");
            _listener.Start();
            while (true)
            {
                if (_listener.IsListening)
                {
                    HttpListenerContext context = await _listener.GetContextAsync();
                    await _request.HandlePostRequestAsync(context);

                    
                }
                else
                {
                    throw new Exception("Listener dont Lisining");
                }
            }
        }

        public void Dispose()
        {
            _listener.Stop();
            _listener.Close();
        }

    }
}
