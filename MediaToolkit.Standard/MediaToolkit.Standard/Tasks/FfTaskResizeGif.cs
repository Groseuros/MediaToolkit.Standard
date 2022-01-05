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
        private readonly int targetFPS;
        private readonly int targetQuality;
        private readonly int lossless;

        public FfTaskResizeGif(string inputFilePath, string outputFilePath, int targetWidth, int targetFPS = 30, int targetQuality = 75, int lossless = 0)
        {
            this.inputFilePath = inputFilePath;
            this.outputFilePath = outputFilePath;
            this.targetWidth = targetWidth;
            this.targetFPS = targetFPS;
            this.targetQuality = targetQuality;
            this.lossless = lossless;
        }

        public override IList<string> CreateArguments()
        {
            var arguments = new[]
            {
                "-y",
                "-hide_banner",
                "-i",
                $@"{inputFilePath}",
                "-lossless",
                $@"{lossless}",
                "-qscale",
                $@"{targetQuality}",
                "-filter_complex",
                $@"[0:v] fps={targetFPS},scale={targetWidth}:-1:flags=lanczos,split [a][b]; [a] palettegen=reserve_transparent=on:transparency_color=ffffff [p]; [b][p] paletteuse",
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
