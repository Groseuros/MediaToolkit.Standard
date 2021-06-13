using System.Collections.Generic;
using System.Threading.Tasks;
using MediaToolkit.Standard.Core.Interfaces;

namespace MediaToolkit.Standard.Tasks
{
    /// <summary>
    /// The task resizes the image to the target width and keep the original aspect ratio
    /// </summary>
    public class FfTaskResizeImage : FfMpegTaskBase<bool>
    {
        private readonly string inputFilePath;
        private readonly string outputFilePath;
        private readonly int targetWidth;

        public FfTaskResizeImage(string inputFilePath, string outputFilePath, int targetWidth)
        {
            this.inputFilePath = inputFilePath;
            this.outputFilePath = outputFilePath;
            this.targetWidth = targetWidth;
        }

        public override IList<string> CreateArguments()
        {
            var arguments = new[]
            {
                "-y",
                "-i",
                $@"{inputFilePath}",
                "-vf",
                $@"scale={targetWidth}:-1",
                $@"{outputFilePath}"
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
