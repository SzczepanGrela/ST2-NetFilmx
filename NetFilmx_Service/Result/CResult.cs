namespace NetFilmx_Service.Result
{
    public class Error
    {
        public Error(string propertyName, string message)
        {
            PropertyName = propertyName;
            Message = message;
        }
        public string PropertyName { get; }
        public string Message { get; }
    }

    public class CResult
    {
        protected CResult(bool isSuccess, string message, IEnumerable<Error> errors)
        {
            IsSuccess = isSuccess;
            IsFailure = !isSuccess;
            Message = message;
            Errors = errors;
        }
        public string Message { get; }
        public bool IsFailure { get; }
        public bool IsSuccess { get; }
        public IEnumerable<Error> Errors { get; }
        public static CResult Fail(string message)
            => new CResult(false, message, Enumerable.Empty<Error>());


        public static CResult Fail(FluentValidation.Results.ValidationResult validationResult)
            => new CResult(
                false,
                string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)),
                validationResult.Errors.Select(x => new Error(x.PropertyName, x.ErrorMessage))
            );




        public static CResult Ok()
            => new CResult(true, "", Enumerable.Empty<Error>());
    }



}
