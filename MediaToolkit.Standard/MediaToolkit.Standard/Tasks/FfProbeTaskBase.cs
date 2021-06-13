using System.Threading.Tasks;
using MediaToolkit.Standard.Services;

namespace MediaToolkit.Standard.Tasks
{
    /// <summary>
    /// The base class for all ffprobe tasks.
    /// </summary>
    public abstract class FfProbeTaskBase<TResult> : FfTaskBase<TResult>
    {
        internal override Task<TResult> ExecuteAsync(MediaToolkitService ffService)
        {
            return ffService.ExecuteAsync(this);
        }
    }
}
