namespace TaskEngAmr.DTOs
{
    public class APIResponse
    {
        public bool Status { get; set; } = false;
        public string Message { get; set; }
    }
    public class APIRequest<T>:APIResponse where T : class
    {
        public T Response { get; set; }
    }
}
