using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using MediaToolkit.Standard.Core.Interfaces;
using MediaToolkit.Standard.Models;
using MediaToolkit.Standard.Tasks.Results;

namespace MediaToolkit.Standard.Tasks
{
    /// <summary>
    /// The task retrieves the file metadata using ffprobe.
    /// </summary>
    public class FfTaskGetMetadata : FfProbeTaskBase<GetMetadataResult>
    {
        private readonly string filePath;

        public FfTaskGetMetadata(string filePath)
        {
            this.filePath = filePath;
        }

        public override IList<string> CreateArguments()
        {
            var arguments = new[]
            {
                "-v",
                "quiet",
                "-print_format",
                "json",
                "-show_format",
                "-show_streams",
                filePath
            };

            return arguments;
        }

        public override async Task<GetMetadataResult> ExecuteCommandAsync(IFfProcess ffProcess)
        {
            await ffProcess.ProcessTask;
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            string output = await ffProcess.OutputReader.ReadToEndAsync();
            FfProbeOutput ffProbeOutput = JsonSerializer.Deserialize<FfProbeOutput>(output, options);
            GetMetadataResult result = new GetMetadataResult(ffProbeOutput);

            return result;
        }
    }
}
