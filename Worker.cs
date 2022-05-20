#region Library
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
#endregion

namespace BackWorker
{
    public class Worker : IWorker
    {
        private readonly ILogger<Worker> logger;
        private int number = 0;
        public Worker(ILogger<Worker> logger)
        {
            this.logger = logger;
        }

        public async Task DoWork(CancellationToken cancellationToken)
        {
            await DoCheckNotConfirmedProfile(cancellationToken);
        }

        public async Task DoCheckNotConfirmedProfile(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                await Task.Delay(5000);
                Interlocked.Increment(ref number);
                logger.LogInformation($"Printing from worker {number}");
            }
        }
    }
}
