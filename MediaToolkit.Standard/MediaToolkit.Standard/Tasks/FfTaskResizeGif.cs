using System.Collections.Generic;
using System.Threading.Tasks;
using MediaToolkit.Standard.Core.Interfaces;

namespace MediaToolkit.Standard.Tasks
{
    /// <summary>
    /// The task resizes the gif to the target width and keep the original aspect ratio
    /// </summary>
    public class FfTaskResizeGif : FfMpegTaskBase<bool>
    {
        private readonly string inputFilePath;
        private readonly string outputFilePath;
        private readonly int targetWidth;

        public FfTaskResizeGif(string inputFilePath, string outputFilePath, int targetWidth)
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
                "-hide_banner",
                "-i",
                $@"{inputFilePath}",
                "-filter_complex",
                $@"[0:v] scale={targetWidth}:-1:flags=lanczos,split [a][b]; [a] palettegen=reserve_transparent=on:transparency_color=ffffff [p]; [b][p] paletteuse",
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
