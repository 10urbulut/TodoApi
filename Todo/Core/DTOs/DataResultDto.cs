namespace Todo.Core
{
    public class DataResult<T>
    {
        public DataResult(T data, bool isSuccess = true)
        {
            this.Data = data;
            IsSuccess = isSuccess;
        }
        public DataResult(bool isSuccess = false)
        {
            IsSuccess = isSuccess;
        }



        public T? Data { get; set; }
        public bool IsSuccess { get; set; }
    }
}