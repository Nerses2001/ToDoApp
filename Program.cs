using ToDoAppUsingRepositoryPattern.Application.Service.Interfaces.ServerInterfases;
using ToDoAppUsingRepositoryPattern.Application.Service.Interfaces.UserServiceIntefaces;
using ToDoAppUsingRepositoryPattern.Application.Service.Server;
using ToDoAppUsingRepositoryPattern.Application.Service.UserService;
using ToDoAppUsingRepositoryPattern.Infrastructure.Data.DbContexts;
using ToDoAppUsingRepositoryPattern.Infrastructure.Interfaces.RepasitoryInterfaces;
using ToDoAppUsingRepositoryPattern.Infrastructure.Repository.UserRepository;
using ToDoAppUsingRepositoryPattern.Infrastructure.Server;
using ToDoAppUsingRepositoryPattern.Infrastructure.Server.RequestProcessor;

ToDoAppContext context = new();
IUserRepository userRepository = new UserRepository(context);
IUserService userService = new UserService(userRepository);
IPostRequest postRequest = new HandlePostRequest(userService);
IRequestProcessor requestHandler = new RequestProcessor(postRequest);
ServerProvider server = new(requestHandler);
await server.StartAsync();