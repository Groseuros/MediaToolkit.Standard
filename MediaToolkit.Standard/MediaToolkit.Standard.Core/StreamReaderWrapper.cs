using System.IO;
using System.Threading.Tasks;
using Medallion.Shell.Streams;
using MediaToolkit.Standard.Core.Interfaces;

namespace MediaToolkit.Standard.Core
{
    /// <summary>
    /// Provides stream reader interfaces
    /// </summary>
    internal class StreamReaderWrapper : IProcessStreamReader
    {
        private readonly ProcessStreamReader streamReader;

        /// <summary>
        /// Ctor.
        /// </summary>
        public StreamReaderWrapper(ProcessStreamReader streamReader)
        {
            this.streamReader = streamReader;
        }

        /// <summary>
        /// IProcessStreamReader
        /// </summary>
        public Stream BaseStream => streamReader.BaseStream;

        /// <summary>
        /// IProcessStreamReader
        /// </summary>
        public Task<string> ReadToEndAsync()
        {
            return streamReader.ReadToEndAsync();
        }
    }
}
