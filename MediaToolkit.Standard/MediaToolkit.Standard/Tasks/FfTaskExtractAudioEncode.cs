using System.Collections.Generic;
using System.Threading.Tasks;
using MediaToolkit.Standard.Core.Interfaces;

namespace MediaToolkit.Standard.Tasks
{
    /// <summary>
    /// The task extracts the native audio and encode it to the desired format.
    /// </summary>
    public class FfTaskExtractAudioEncode : FfMpegTaskBase<bool>
    {
        private readonly string inputFilePath;
        private readonly string outputFilePath;

        public FfTaskExtractAudioEncode(string inputFilePath, string outputFilePath)
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
                "-q:a",
                "0",
                "-map",
                "a",
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
