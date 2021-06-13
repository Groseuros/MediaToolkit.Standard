using System.Collections.Generic;
using System.Threading.Tasks;
using MediaToolkit.Standard.Core.Interfaces;

namespace MediaToolkit.Standard.Tasks
{
    /// <summary>
    /// The task extracts the native audio without re-encode.
    /// Warning: outputFile path extension MUST match the correct audio codec
    /// </summary>
    public class FfTaskExtractAudioNative : FfMpegTaskBase<bool>
    {
        private readonly string inputFilePath;
        private readonly string outputFilePath;

        public FfTaskExtractAudioNative(string inputFilePath, string outputFilePath)
        {
            this.inputFilePath = inputFilePath;
            this.outputFilePath = outputFilePath;
        }

        public override IList<string> CreateArguments()
        {
            var arguments = new[]
            {
                "-y",
                "-i",
                $@"{inputFilePath}",
                "-vn",
                "-acodec", 
                "copy",
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
