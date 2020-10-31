using System;
using System.Collections.Generic;
using System.Linq;

namespace Chinook.Core.Extensions
{
    public static class ExceptionExtensions
    {
        public static IEnumerable<Exception> GetAllExceptions(this Exception ex)
        {
            if (ex == null) { yield break; }
            yield return ex;
            IEnumerable<Exception> innerExceptions = Enumerable.Empty<Exception>();

            if (ex is AggregateException exception && exception.InnerExceptions.Any())
            {
                innerExceptions = exception.InnerExceptions;
            }
            else if (ex.InnerException != null)
            {
                innerExceptions = new Exception[] { ex.InnerException };
            }

            foreach (var innerEx in innerExceptions)
            {
                yield return innerEx;
                foreach (var msg in innerEx.GetAllExceptions())
                {
                    yield return msg;
                }
            }
        }

    }
}
