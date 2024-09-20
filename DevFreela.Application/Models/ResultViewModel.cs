namespace DevFreela.Application.Models
{
    public class ResultViewModel
    {
        public ResultViewModel(bool isSuccess = true, string error = "")
        {
            IsSuccess = isSuccess;
            Error = error;
        }

        public bool IsSuccess { get; set; }
        public string Error { get; set; }
    }

    public class ResultViewModel<T> : ResultViewModel
    {
        public ResultViewModel(T? data, bool isSuccess = true, string message = "")
            : base(isSuccess, message)
        {
            Data = data;
        }

        public T? Data { get; set; }
    }
}
