namespace CQRS.Models
{
    public class Envelop<T>
    {
        public string Message { get; set; } = string.Empty;
        public bool isSucess { get; set; } = false;

        public T? Data { get; set; }
    }
}
