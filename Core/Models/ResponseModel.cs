

namespace ToDoAppUsingRepositoryPattern.Infrastructure.Models
{
    public class ResponseModel<T>
    {
        public bool Success { get; private set; }
        public string Message { get; private set; }
        public T Data { get; private set; }

        public ResponseModel(bool success, string message, T Data)
        {
            this.Success = success;
            this.Message = message;
            this.Data = Data;
        }
    }
}
