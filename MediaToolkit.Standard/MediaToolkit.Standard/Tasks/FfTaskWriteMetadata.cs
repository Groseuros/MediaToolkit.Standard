using MediaToolkit.Standard.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MediaToolkit.Standard.Tasks
{
    /// <summary>
    /// The task adds basic metadata info to a given audio file
    /// </summary>
    public class FfTaskWriteMetadata : FfMpegTaskBase<bool>
    {
        private readonly string inputFilePath;
        private readonly string outputFilePath;
        private readonly string titleTag;
        private readonly string artistTag;
        private readonly string albumTag;
        private readonly string genreTag;
        private readonly string commentTag;


        public FfTaskWriteMetadata(string inputFilePath, string outputFilePath, string titleTag, string artistTag, string albumTag, string genreTag, string commentTag) 
        {
            this.inputFilePath = inputFilePath;
            this.outputFilePath = outputFilePath;
            this.titleTag = titleTag;
            this.artistTag = artistTag;
            this.albumTag = albumTag;
            this.genreTag = genreTag;
            this.commentTag = commentTag;
        }

        public override IList<string> CreateArguments()
        {
            var arguments = new[]
           {
                "-i",
                $@"{inputFilePath}",
                "-q:a",
                "0",
                "-map",
                "a",
                $@"-metadata",
                $@"title={titleTag}",
                 $@"-metadata",
                $@"artist={artistTag}",
                 $@"-metadata",
                $@"album={albumTag}",
                 $@"-metadata",
                $@"genre={genreTag}",
                 $@"-metadata",
                $@"comment={commentTag}",
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
