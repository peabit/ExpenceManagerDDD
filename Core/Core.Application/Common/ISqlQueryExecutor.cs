﻿namespace Core.Application.Common;

public interface ISqlQueryExecutor
{
    Task<IEnumerable<TResult>> Query<TResult>(string query, object parameters);
    Task<TResult> QuerySingle<TResult>(string query, object parameters);
}