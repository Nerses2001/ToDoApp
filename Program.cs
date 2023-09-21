using ToDoAppUsingRepositoryPattern.Infrastructure.Interfaces.ServerInterfases;
using ToDoAppUsingRepositoryPattern.Infrastructure.Server.RequestProcessor;
using ToDoAppUsingRepositoryPattern.Infrastructure.Server;

IRequestProcessor requestHandler = new RequestProcessor();
ServerProvider server = new(requestHandler);
await server.StartAsync();