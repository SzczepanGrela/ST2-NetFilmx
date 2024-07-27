using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using FluentValidation.Results;

namespace NetFilmx_Service
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

    public class Result
    {
        private Result(bool isSuccess, string message, IEnumerable<Error> errors)
        {
            IsSuccess = isSuccess;
            IsFailrue = !isSuccess;
            Message = message;
            Errors = errors;
        }
        public string Message { get; }
        public bool IsFailrue { get; }
        public bool IsSuccess { get; }
        public IEnumerable<Error> Errors { get; }
        public static Result Fail(string message)
            => new Result(false, message, Enumerable.Empty<Error>());


        public static Result Fail(FluentValidation.Results.ValidationResult validationResult)
            => new Result(
                false,
                string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)),
                validationResult.Errors.Select(x => new Error(x.PropertyName, x.ErrorMessage))
            );




        public static Result Ok()
            => new Result(true, "", Enumerable.Empty<Error>());
    }
}
