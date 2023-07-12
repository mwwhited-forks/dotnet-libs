namespace Nucleus.Core.Contracts.Models
{
    public class ResponseModel<T>
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public T? Response { get; set; }
    }
}
