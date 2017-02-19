namespace LostTech.Storage
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public static class QueueBatching
    {
        public static async Task Enqueue<T>(this IQueueIn<T> queue, IEnumerable<T> items, CancellationToken cancellationToken)
        {
            if (queue == null)
                throw new ArgumentNullException(nameof(queue));
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            foreach (var item in items) {
                if (cancellationToken.IsCancellationRequested)
                    throw new TaskCanceledException();
                await queue.Enqueue(item, cancellationToken).ConfigureAwait(false);
            }
        }

        public static async Task<T[]> Dequeue<T>(this IQueueOut<T> queue, long count, CancellationToken cancellationToken)
        {
            if (queue == null)
                throw new ArgumentNullException(nameof(queue));
            if (count <= 0)
                throw new ArgumentOutOfRangeException(paramName: nameof(count));

            var items = new List<T>();
            for (int i = 0; i < count; i++) {
                if (cancellationToken.IsCancellationRequested)
                    throw new TaskCanceledException();
                var item = await queue.Dequeue(cancellationToken).ConfigureAwait(false);
                items.Add(item);
            }
            return items.ToArray();
        }
    }
}
