namespace LostTech.Storage
{
    using System.Threading;
    using System.Threading.Tasks;

    public interface IQueueIn<in T>
    {
        Task Enqueue(T message, CancellationToken cancellationToken);
    }
}
