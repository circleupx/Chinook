﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Chinook.Core.Extensions
{
    public static class IQueryableTaggingExtensions
    {
        public static IQueryable<T> TagWithSource<T>(this IQueryable<T> queryable,
            [CallerLineNumber] int lineNumber = 0,
            [CallerFilePath] string filePath = "",
            [CallerMemberName] string memberName = "")
        {
            return queryable.TagWith($"{memberName}  - {filePath}:{lineNumber}");
        }

        public static IQueryable<T> TagWithSource<T>(this IQueryable<T> queryable,
            string tag,
            [CallerLineNumber] int lineNumber = 0,
            [CallerFilePath] string filePath = "",
            [CallerMemberName] string memberName = "")
        {
            return queryable.TagWith($"{tag}{Environment.NewLine}{memberName}  - {filePath}:{lineNumber}");
        }
    }
}
