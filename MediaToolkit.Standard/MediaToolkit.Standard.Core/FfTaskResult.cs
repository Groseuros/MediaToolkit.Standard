namespace MediaToolkit.Standard.Core
{
    /// <summary>
    /// The ffmpeg/ffprobe execution result
    /// </summary>
    public class FfTaskResult
    {
        public FfTaskResult(string output, string error)
        {
            Output = output;
            Error = error;
        }

        /// <summary>
        /// The standard output.
        /// </summary>
        public string Output { get; private set; }

        /// <summary>
        /// The error output.
        /// </summary>
        public string Error { get; private set; }
    }
}
