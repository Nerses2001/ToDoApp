using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ToDoAppUsingRepositoryPattern.Core.Interfaces.ControllersInerfases
{
    internal interface ITaskControllerForGet
    {
        Task GetUserTask(HttpListenerResponse response, string url, string sendUrl);
    }
}
