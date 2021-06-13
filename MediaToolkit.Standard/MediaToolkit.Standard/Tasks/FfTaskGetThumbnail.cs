using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using MediaToolkit.Standard.Core.Interfaces;
using MediaToolkit.Standard.Models;
using MediaToolkit.Standard.Tasks.Results;

namespace MediaToolkit.Standard.Tasks
{
    /// <summary>
    /// The tasks extracts the video thumbnail.
    /// </summary>
    public class FfTaskGetThumbnail : FfMpegTaskBase<GetThumbnailResult>
    {
        private readonly string inputFilePath;
        private readonly ThumbnailOptions options;

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="inputFilePath">Full path to the input video file.</param>
        /// <param name="options">The task options.</param>
        public FfTaskGetThumbnail(string inputFilePath, ThumbnailOptions options)
        {
            this.inputFilePath = inputFilePath;
            this.options = options;
        }

        public override IList<string> CreateArguments()
        {
            var arguments = new List<string>
            {
                "-hide_banner",
                "-loglevel",
                "info",
                "-ss",
                options.SeekSpan.TotalSeconds.ToString(),
                "-i",
                $@"{inputFilePath}",
                "-t",
                "1"
            };

            arguments.Add("-f");
            arguments.Add(string.IsNullOrEmpty(options.OutputFormat)
              ? OutputFormat.RawVideo
              : options.OutputFormat);

            if (!string.IsNullOrEmpty(options.PixelFormat))
            {
                arguments.Add("-pix_fmt");
                arguments.Add(options.PixelFormat);
            }

            arguments.Add("-vframes");
            arguments.Add("1");

            if (options.FrameSize != null)
            {
                arguments.Add("-s");
                arguments.Add(options.FrameSize.ToString());
            }

            arguments.Add("-");

            return arguments;
        }

        public override async Task<GetThumbnailResult> ExecuteCommandAsync(IFfProcess ffProcess)
        {
            await ffProcess.ProcessTask;

            byte[] thumbnailData;
            using (var ms = new MemoryStream())
            {
                await ffProcess.OutputReader.BaseStream.CopyToAsync(ms);
                thumbnailData = ms.ToArray();
            }

            return new GetThumbnailResult(thumbnailData);
        }
    }
}
