using System;
using System.Collections.Generic;
using System.Text;

namespace WorkFollow.Business.Utilities
{
    public interface IResult
    {
        bool IsSuccess { get; set; }
        string Message { get; set; }
    }
}
