namespace Dto.Responses
{
    public class Response<T>
    {
        public bool Succeeded { get; set; }
        public T Data { get; set; }
        public string Errors { get; set; }
    }
}