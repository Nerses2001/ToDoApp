namespace ToDoAppUsingRepositoryPattern.Core.Models
{
    public class ResponseModel<T>
    {
        public bool Success { get; private set; }
        public string Message { get; private set; }
        public T Data { get; private set; }

        public ResponseModel(bool success, string message, T Data)
        {
            Success = success;
            Message = message;
            this.Data = Data;
        }
    }
}
