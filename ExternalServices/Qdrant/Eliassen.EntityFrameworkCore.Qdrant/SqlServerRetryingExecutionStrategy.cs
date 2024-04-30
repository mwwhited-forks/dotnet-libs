
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Eliassen.EntityFrameworkCore;

public class QdrantRetryingExecutionStrategy : ExecutionStrategy
{
    private readonly HashSet<int>? _additionalErrorNumbers;

    /// <summary>
    ///     The default minimum time delay between retries for throttling errors.
    /// </summary>
    protected static readonly TimeSpan DefaultMinDelayThrottling = TimeSpan.FromSeconds(5);

    public QdrantRetryingExecutionStrategy(
        DbContext context)
        : this(context, DefaultMaxRetryCount)
    {
    }

    public QdrantRetryingExecutionStrategy(
        ExecutionStrategyDependencies dependencies)
        : this(dependencies, DefaultMaxRetryCount)
    {
    }

    public QdrantRetryingExecutionStrategy(
        DbContext context,
        int maxRetryCount)
        : this(context, maxRetryCount, DefaultMaxDelay, errorNumbersToAdd: null)
    {
    }

    public QdrantRetryingExecutionStrategy(
        ExecutionStrategyDependencies dependencies,
        int maxRetryCount)
        : this(dependencies, maxRetryCount, DefaultMaxDelay, errorNumbersToAdd: null)
    {
    }

    public QdrantRetryingExecutionStrategy(
        ExecutionStrategyDependencies dependencies,
        IEnumerable<int> errorNumbersToAdd)
        : this(dependencies, DefaultMaxRetryCount, DefaultMaxDelay, errorNumbersToAdd)
    {
    }

    public QdrantRetryingExecutionStrategy(
        DbContext context,
        int maxRetryCount,
        TimeSpan maxRetryDelay,
        IEnumerable<int>? errorNumbersToAdd)
        : base(
            context,
            maxRetryCount,
            maxRetryDelay)
    {
        _additionalErrorNumbers = errorNumbersToAdd?.ToHashSet();
    }

    public QdrantRetryingExecutionStrategy(
        ExecutionStrategyDependencies dependencies,
        int maxRetryCount,
        TimeSpan maxRetryDelay,
        IEnumerable<int>? errorNumbersToAdd)
        : base(dependencies, maxRetryCount, maxRetryDelay)
    {
        _additionalErrorNumbers = errorNumbersToAdd?.ToHashSet();
    }

    public virtual IEnumerable<int>? AdditionalErrorNumbers
        => _additionalErrorNumbers;

    protected override bool ShouldRetryOn(Exception exception) => false;

    protected override TimeSpan? GetNextDelay(Exception lastException)
    {
        var baseDelay = base.GetNextDelay(lastException);
        if (baseDelay == null)
        {
            return null;
        }

        return CallOnWrappedException(lastException, IsMemoryOptimizedError)
            ? TimeSpan.FromMilliseconds(baseDelay.Value.TotalSeconds)
            : CallOnWrappedException(lastException, IsThrottlingError)
                ? baseDelay + DefaultMinDelayThrottling
                : baseDelay;
    }

    private static bool IsMemoryOptimizedError(Exception exception) => false;

    private static bool IsThrottlingError(Exception exception) => false
}
