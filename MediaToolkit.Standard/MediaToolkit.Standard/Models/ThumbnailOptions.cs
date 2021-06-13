using System;
using System.Collections.Generic;
using System.Text;

namespace MediaToolkit.Standard.Models
{
    /// <summary>
    /// Input options for the get thumbnail task.
    /// </summary>
    public class ThumbnailOptions
    {
        /// <summary>
        /// The video fram time span.
        /// </summary>
        public TimeSpan SeekSpan { get; set; }

        public FrameSize FrameSize { get; set; }

        /// <summary>
        /// The video/audio stream format. Set empty/null to let the ffmpeg guess that.
        /// rawvideo by default
        /// </summary>
        public string OutputFormat { get; set; }

        /// <summary>
        /// The pixel format. Set empty/null to let the ffmpeg guess that.
        /// </summary>
        public string PixelFormat { get; set; }
    }
}
