namespace ANCD.Application.Messages.Queries
{
    public sealed class QueryResult<T>
    {
        public T Data { get; private set; }

        public bool IsSuccess { get; private set; }

        public IReadOnlyCollection<string> Errors => _errors?.ToList().AsReadOnly();

        private ICollection<string> _errors;

        public static QueryResult<T> Success(T data)
        {
            var result = new QueryResult<T>();
            result.IsSuccess = true;
            result.Data = data;
            return result;
        }

        public static QueryResult<T> Fail(string error)
        {
            var result = new QueryResult<T>();
            result._errors = new List<string>(1);
            result._errors.Add(error);
            return result;
        }

        public static QueryResult<T> Fail(ICollection<string> errors)
        {
            var result = new QueryResult<T>();
            result._errors = errors;
            return result;
        }
    }
}
