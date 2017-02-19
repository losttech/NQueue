namespace LostTech.Storage
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IBatchedQueueIn<in T>
    {
        Task Enqueue(IEnumerable<T> items, CancellationToken cancellationToken);
        long? EnqueueItemLimit { get; }
    }
}
