using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwStore.Application.Core
{
    public class Result<T>
    {
        public bool IsSuccess { get; set; }
        public T Value { get; set; }
        public List<string> Errors { get; set; }
        public string Error { get; set; }

        public static Result<T> Success(T value) =>
            new Result<T> { IsSuccess = true, Value = value };

        public static Result<T> Failure(List<string> errors) =>
            new Result<T>() { IsSuccess = false, Errors = errors };

        public static Result<T> Failure(string error) =>
            new Result<T>() { IsSuccess = false, Error = error };
    }
}
