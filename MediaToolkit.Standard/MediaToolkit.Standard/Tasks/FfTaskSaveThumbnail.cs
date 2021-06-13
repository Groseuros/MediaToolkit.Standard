using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediaToolkit.Standard.Core.Interfaces;

namespace MediaToolkit.Standard.Tasks
{
    /// <summary>
    /// The task saves the video thumbnail.
    /// </summary>
    public class FfTaskSaveThumbnail : FfMpegTaskBase<bool>
    {
        private readonly string inputFilePath;
        private readonly string outputFilePath;
        private readonly TimeSpan seekSpan;

        public FfTaskSaveThumbnail(string inputFilePath, string outputFilePath, TimeSpan seekSpan)
        {
            this.inputFilePath = inputFilePath;
            this.outputFilePath = outputFilePath;
            this.seekSpan = seekSpan;
        }

        public override IList<string> CreateArguments()
        {
            var arguments = new[]
            {
                "-nostdin",
                "-y",
                "-loglevel",
                "info",
                "-ss",
                seekSpan.TotalSeconds.ToString(),
                "-i",
                $@"{inputFilePath}",
                "-vframes",
                "1",
                $@"{outputFilePath}",
            };

            return arguments;
        }

        public override async Task<bool> ExecuteCommandAsync(IFfProcess ffProcess)
        {
            await ffProcess.ProcessTask;
            return true;
        }
    }
}
