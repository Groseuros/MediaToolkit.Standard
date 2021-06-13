using System.Collections.Generic;

namespace MediaToolkit.Standard.Models
{
    public class FfProbeOutput
    {
        public IList<MediaStream> Streams { get; set; }
        public Format Format { get; set; }
    }
}
