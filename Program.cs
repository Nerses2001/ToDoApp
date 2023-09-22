using ToDoAppUsingRepositoryPattern.Application.Service.Interfaces.ServerInterfases;
using ToDoAppUsingRepositoryPattern.Application.Service.Interfaces.UserServiceIntefaces;
using ToDoAppUsingRepositoryPattern.Application.Service.Server;
using ToDoAppUsingRepositoryPattern.Application.Service.UserService;
using ToDoAppUsingRepositoryPattern.Infrastructure.Data.DbContexts;
using ToDoAppUsingRepositoryPattern.Infrastructure.Interfaces.RepasitoryInterfaces;
using ToDoAppUsingRepositoryPattern.Infrastructure.Repository.UserRepository;
using ToDoAppUsingRepositoryPattern.Infrastructure.Server.RequestProcessor;
using ToDoAppUsingRepositoryPattern.Presentation.Controllers;
using ToDoAppUsingRepositoryPattern.Presentation.Interfases;

ToDoAppContext context = new();

IUserRepository userRepository = new UserRepository(context);
IUserService userService = new UserService(userRepository);

IUserController userController = new UserServiceController(userService);
IPostRequest postRequest = new HandlePostRequest(userController);

IRequestProcessor requestHandler = new RequestProcessor(postRequest);

ServerProvider server = new(requestHandler);

await server.StartAsync();