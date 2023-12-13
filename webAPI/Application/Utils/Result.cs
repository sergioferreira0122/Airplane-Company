namespace webAPI.Application.Utils
{
    public class Result<T>
    {
        public int HttpCode { get; set; }
        public T? Data { get; set; }

        public Result(int httpCode)
        {
            HttpCode = httpCode;
        }

        public Result(int httpCode, T? data)
        {
            HttpCode = httpCode;
            Data = data;
        }
    }
}