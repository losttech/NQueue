namespace LostTech.Storage.InMemory
{
    using System.Threading;
    using System.Threading.Tasks;
    using Concurrent = System.Collections.Concurrent;

    public sealed class ConcurrentQueue<T> : IQueueIn<T>, IQueueOut<T>
    {
        readonly Concurrent.ConcurrentQueue<T> queue = new Concurrent.ConcurrentQueue<T>();

        public Task<T> Dequeue(CancellationToken cancellationToken)
        {
            T result;
            while (!this.queue.TryDequeue(out result))
                if (cancellationToken.IsCancellationRequested)
                    throw new TaskCanceledException();

            return Task.FromResult(result);
        }

        public Task Enqueue(T message, CancellationToken cancellationToken)
        {
            this.queue.Enqueue(message); 
            return Task.CompletedTask;
        }
    }
}
