

namespace MicroProduct.Application.Dtos
{
    public class ResponseDto<T>
    {
        public int code { get; set; } = 200;
        public bool Error { get; set; } = false;
        public string? Message { get; set; } = string.Empty;
        public T? Data { get; set; } = default;

        private ResponseDto(int code, bool error = false, string? message = null, T? data = default)
        {
            this.code = code;
            Error = error;
            Message = message;
            Data = data;
        }

        public ResponseDto()
        {
        }

        public static ResponseDto<T> Success(string? message = null, T? data = default)
        {
            return new ResponseDto<T>(200, false, message, data);
        }

        public static ResponseDto<T> ErrorGeneric(int code = 400, string? message = null, T? data = default)
        {
            return new ResponseDto<T>(code, true, message, data);
        }

        public static ResponseDto<T> ErrorBadRequest(string message = "")
        {
            return new ResponseDto<T>(400, true, message, default);
        }

        public static ResponseDto<T> Information(int code = 200, string? message = null, T? data = default)
        {
            return new ResponseDto<T>(code, false, message, data);
        }

        public static ResponseDto<T> Failure(string? message = null)
        {
            return new ResponseDto<T>(500, true, message);
        }
    }
}