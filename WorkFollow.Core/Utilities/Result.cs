using System;
using System.Collections.Generic;
using System.Text;

namespace WorkFollow.Business.Utilities
{
    public class Result<T> : IResult
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public T Data { get; set; }
        public int TotalCount { get; set; }
        public Result(bool isSuccesss, string message) : this(isSuccesss, message, default(T))
        {
        }
        public Result(bool isSuccesss, string message, T data) : this(isSuccesss, message, data, 0)
        {
        }
        public Result(bool isSuccesss, string message, T data, int totalCount)
        {
            IsSuccess = isSuccesss;
            Message = message;
            Data = data;
            TotalCount = totalCount;
        }

    }
}
