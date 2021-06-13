namespace MediaToolkit.Standard.Tasks.Results
{
    /// <summary>
    /// The result type for get thumbnail task.
    /// </summary>
    public class GetThumbnailResult
    {
        public GetThumbnailResult(byte[] thumbnailData)
        {
            ThumbnailData = thumbnailData;
        }

        /// <summary>
        /// The thumbnail data.
        /// </summary>
        public byte[] ThumbnailData { get; }
    }
}
