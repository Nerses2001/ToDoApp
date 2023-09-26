using ToDoAppUsingRepositoryPattern.Application.Service.Server;
using ToDoAppUsingRepositoryPattern.Application.Service.TaskService;
using ToDoAppUsingRepositoryPattern.Application.Service.UserService;
using ToDoAppUsingRepositoryPattern.Core.Interfaces.ControllersInerfases;
using ToDoAppUsingRepositoryPattern.Core.Interfaces.RepasitoryInterfaces;
using ToDoAppUsingRepositoryPattern.Core.Interfaces.ServerInterfases;
using ToDoAppUsingRepositoryPattern.Core.Interfaces.ServiceInterfaces;
using ToDoAppUsingRepositoryPattern.Core.Interfaces.TaskServiceInterfaces;
using ToDoAppUsingRepositoryPattern.Infrastructure.Data.DbContexts;
using ToDoAppUsingRepositoryPattern.Infrastructure.Repository.TaskRepository;
using ToDoAppUsingRepositoryPattern.Infrastructure.Repository.UserRepository;
using ToDoAppUsingRepositoryPattern.Infrastructure.Server.RequestProcessor;
using ToDoAppUsingRepositoryPattern.Presentation.Controllers;

ToDoAppContext context = new();

IUserRepository userRepository = new UserRepository(context);
ITaskRepasitory taskRepasitory = new TaskRepository(context);
IUserService userService = new UserService(userRepository);
ITaskService taskService = new TaskService(taskRepasitory);

IUserController userController = new UserController(userService);
ITaskController taskController = new TaskController(taskService);
ITaskControllerForGet taskControllerFor = new TaskController(taskService);

IPostRequest postRequest = new HandlePostRequest(userController,taskController);
IGetRequest getRequest = new HandleGetRequest(taskControllerFor);
IRequestProcessor requestHandler = new RequestProcessor(postRequest,getRequest);

ServerProvider server = new(requestHandler);

await server.StartAsync();