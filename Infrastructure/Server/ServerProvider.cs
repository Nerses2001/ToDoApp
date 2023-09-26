using System.Net;
using ToDoAppUsingRepositoryPattern.Core.Abstractions.ServerAbstracts;
using ToDoAppUsingRepositoryPattern.Core.Interfaces.ServerInterfases;

namespace ToDoAppUsingRepositoryPattern.Application.Service.Server
{
    internal class ServerProvider : BaseServerProvider, IServerProvider, IDisposable
    {
        private readonly HttpListener _listener;
        //  private readonly IUserRepository _userRepository;
        private readonly IRequestProcessor _request;

        public ServerProvider(IRequestProcessor request)
        {
            _listener = new();
            _listener.Prefixes.Add($"{BaseUrl}:{Port}/");

            _request = request;
        }


        public async Task StartAsync()
        {
            Console.WriteLine("Listening for requests...");
            Console.WriteLine($"{BaseUrl}:{Port}/");
            _listener.Start();
            while (true)
            {
                if (_listener.IsListening)
                {
                    HttpListenerContext context = await _listener.GetContextAsync();
                    await _request.HandleRequestAsync(context);


                }
                else
                    throw new Exception("Listener dont Lisining");
                
            }
        }

        public void Dispose()
        {
            _listener.Stop();
            _listener.Close();
        }

    }
}
