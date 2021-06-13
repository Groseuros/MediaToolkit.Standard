using System.Collections.Generic;

namespace MediaToolkit.Standard.Core.Interfaces
{
    /// <summary>
    /// Factory service for FF process
    /// </summary>
    public interface IFfProcessFactory
    {
        /// <summary>
        /// Launches the ffmpeg
        /// </summary>
        IFfProcess LaunchFfMpeg(IEnumerable<string> arguments);

        /// <summary>
        /// Launches the ffprobe
        /// </summary>
        IFfProcess LaunchFfProbe(IEnumerable<string> arguments);
    }
}
