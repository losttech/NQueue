namespace LostTech.Storage
{
    using System.Threading;
    using System.Threading.Tasks;

    public interface IQueueOut<T>
    {
        Task<T> Dequeue(CancellationToken cancellationToken);
    }
}
