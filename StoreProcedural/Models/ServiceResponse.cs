namespace StoreProcedural.Models
{
    public class ServiceResponse<T>
    {
        public T? Data { get; set; }
        public bool status { get; set; } = true;

        public string message { get; set; }
    }
}
