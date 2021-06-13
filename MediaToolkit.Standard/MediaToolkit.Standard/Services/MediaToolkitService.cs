using System.IO.Abstractions;
using System.Threading.Tasks;
using MediaToolkit.Standard.Core;
using MediaToolkit.Standard.Core.Interfaces;
using MediaToolkit.Standard.Services.Interfaces;
using MediaToolkit.Standard.Tasks;

namespace MediaToolkit.Standard.Services
{
    /// <summary>
    /// The FF service implementation.
    /// </summary>
    public class MediaToolkitService : IMediaToolkitService
    {
        private readonly IFfProcessFactory processFactory;

        public MediaToolkitService(IFfProcessFactory processFactory)
        {
            this.processFactory = processFactory;
        }

        /// <summary>
        /// Factory method.
        /// </summary>
        public static IMediaToolkitService CreateInstance(string ffMpegPath)
        {
            var options = new MediaToolkitOptions
            {
                FfMpegPath = ffMpegPath
            };

            var fileSystem = new FileSystem();
            var ffProcessFactory = new FfProcessFactory(options, fileSystem);
            var result = new MediaToolkitService(ffProcessFactory);

            return result;
        }

        public Task<TResult> ExecuteAsync<TResult>(FfTaskBase<TResult> task)
        {
            var result = task.ExecuteAsync(this);
            return result;
        }

        /// <summary>
        /// Dispatcher for ffprobe tasks.
        /// </summary>
        internal Task<TResult> ExecuteAsync<TResult>(FfProbeTaskBase<TResult> task)
        {
            var arguments = task.CreateArguments();
            var ffProcess = processFactory.LaunchFfProbe(arguments);

            return task.ExecuteCommandAsync(ffProcess);
        }

        /// <summary>
        /// Dispatcher for ffmpeg tasks.
        /// </summary>
        internal Task<TResult> ExecuteAsync<TResult>(FfMpegTaskBase<TResult> task)
        {
            var arguments = task.CreateArguments();
            var ffProcess = processFactory.LaunchFfMpeg(arguments);

            return task.ExecuteCommandAsync(ffProcess);
        }
    }
}
