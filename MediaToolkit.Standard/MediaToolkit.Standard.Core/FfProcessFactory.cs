using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using MediaToolkit.Standard.Core.Interfaces;

namespace MediaToolkit.Standard.Core
{
    /// <summary>
    /// The process factory implementation.
    /// </summary>
    public class FfProcessFactory : IFfProcessFactory
    {
        private readonly string ffprobePath;
        private readonly string ffmpegPath;

        public FfProcessFactory(MediaToolkitOptions options, IFileSystem fileSystem)
        {
            if (options == null || string.IsNullOrEmpty(options.FfMpegPath))
            {
                throw new ArgumentNullException(nameof(options.FfMpegPath));
            }

            ffmpegPath = options.FfMpegPath;
            var ffmpegDirectoryPath = fileSystem.FileInfo.FromFileName(options.FfMpegPath).DirectoryName;
            ffprobePath = string.IsNullOrEmpty(options.FfProbePath)
              ? fileSystem.Path.Combine(ffmpegDirectoryPath, "ffprobe.exe")
              : options.FfProbePath;

            EnsureFFmpegFileExists(fileSystem);
        }

        public IFfProcess LaunchFfMpeg(IEnumerable<string> arguments)
        {
            IFfProcess ffProcess = new FfProcess(ffmpegPath, arguments);
            return ffProcess;
        }

        public IFfProcess LaunchFfProbe(IEnumerable<string> arguments)
        {
            IFfProcess ffProcess = new FfProcess(ffprobePath, arguments);
            return ffProcess;
        }

        private void EnsureFFmpegFileExists(IFileSystem fileSystem)
        {
            if (!fileSystem.File.Exists(ffmpegPath))
                throw new InvalidOperationException("Unable to locate ffmpeg executable. Make sure it exists at path passed to the MediaToolkit");

            if (!fileSystem.File.Exists(ffprobePath))
                throw new InvalidOperationException("Unable to locate ffprobe executable. Make sure it exists at path passed to the MediaToolkit");
        }
    }
}
