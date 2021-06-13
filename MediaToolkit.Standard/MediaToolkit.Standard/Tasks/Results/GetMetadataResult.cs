using MediaToolkit.Standard.Models;

namespace MediaToolkit.Standard.Tasks.Results
{
    /// <summary>
    /// The result type for get metadata task.
    /// </summary>
    public class GetMetadataResult
    {
        public GetMetadataResult(FfProbeOutput metadata)
        {
            Metadata = metadata;
        }

        /// <summary>
        /// The result metadata.
        /// </summary>
        public FfProbeOutput Metadata { get; private set; }
    }
}
