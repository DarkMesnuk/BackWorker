#region Library
using System.Threading;
using System.Threading.Tasks;
#endregion

namespace BackWorker
{
    public interface IWorker
    {
        public Task DoWork(CancellationToken cancellationToken);
        public Task DoCheckNotConfirmedProfile(CancellationToken cancellationToken);
    }
}