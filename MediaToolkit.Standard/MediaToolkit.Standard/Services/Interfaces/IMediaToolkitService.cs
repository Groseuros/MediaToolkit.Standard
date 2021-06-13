using System.Threading.Tasks;
using MediaToolkit.Standard.Tasks;

namespace MediaToolkit.Standard.Services.Interfaces
{
    /// <summary>
    /// The service for invoking commands for ffmpeg and ffprobe.
    /// </summary>
    public interface IMediaToolkitService
    {
        Task<TResult> ExecuteAsync<TResult>(FfTaskBase<TResult> task);
    }
}
