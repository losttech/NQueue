namespace LostTech.Storage
{
    using System.Threading;
    using System.Threading.Tasks;

    public interface IBatchedQueueOut<T>
    {
        Task<T[]> Dequeue(long count, CancellationToken cancellationToken);
        long? DequeueItemLimit { get; }
    }
}
