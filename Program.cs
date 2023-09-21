using ToDoAppUsingRepositoryPattern.Application.Service.Server;
using ToDoAppUsingRepositoryPattern.Application.Service.Interfaces.ServerInterfases;
using ToDoAppUsingRepositoryPattern.Application.Service.Server.RequestProcessor;

IRequestProcessor requestHandler = new RequestProcessor();
ServerProvider server = new(requestHandler);
await server.StartAsync();