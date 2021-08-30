namespace _1_App.Core.Domain.Common.Response
{
    public class ApiResponse<T>
    {
        public T Data { get; set; }
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public static ApiResponse<T> Fail(string errorMessage)
        {
            return new ApiResponse<T> { Succeeded = false, Message = errorMessage };
        }
        public static ApiResponse<T> Success(T data, string successMessage = null)
        {
            var apiRes = new ApiResponse<T> { Succeeded = true, Data = data, Message = successMessage };
            return apiRes;
        }
    }
}
