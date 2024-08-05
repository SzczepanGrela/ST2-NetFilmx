namespace NetFilmx_Service.Result
{
    public class QResult<T> : CResult
    {
        private QResult(bool isSuccess, string message, IEnumerable<Error> errors, T data) : base(isSuccess, message, errors)
        {
            Data = data;
        }

        public T Data { get; }

        public static QResult<T> Ok(T data)
            => new QResult<T>(true, "", Enumerable.Empty<Error>(), data);

        public static QResult<T> Fail(string message, IEnumerable<Error> errors = null)
            => new QResult<T>(false, message, errors ?? Enumerable.Empty<Error>(), default);

        public static QResult<T> Fail(FluentValidation.Results.ValidationResult validationResult)
            => new QResult<T>(
                false,
                string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)),
                validationResult.Errors.Select(x => new Error(x.PropertyName, x.ErrorMessage)), default
            );
    }



}
