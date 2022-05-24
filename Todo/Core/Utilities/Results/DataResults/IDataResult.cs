namespace Todo.Core.Utilities.Results.DataResult
{
        public interface IDataResult<T> : IResult
        {
            T Data { get; }
        }
}
