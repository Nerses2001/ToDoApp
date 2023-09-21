namespace ToDoAppUsingRepositoryPattern.Core.Models
{
    internal class RequestGeneralModel
    {
        public readonly string EndUrl;
        public readonly string Type;
        public readonly string CType;

        public RequestGeneralModel(string endUrl, string type = "POST", string rContentType = "application/json")
        {
            EndUrl = endUrl;
            Type = type;
            CType = rContentType;
        }
    }
}
