using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Medallion.Shell;
using MediaToolkit.Standard.Core.Interfaces;

namespace MediaToolkit.Standard.Core
{
    /// <summary>
    /// FF process implementation
    /// </summary>
    internal class FfProcess : IFfProcess
    {
        private readonly Command command;
        private readonly StreamReaderWrapper outputReader;
        private readonly StreamReaderWrapper errorReader;

        /// <summary>
        /// Ctor.
        /// </summary>
        public FfProcess(string ffToolPath, IEnumerable<string> arguments)
        {
            command = Command.Run(ffToolPath, arguments, options => { options.DisposeOnExit(); });

            outputReader = new StreamReaderWrapper(command.StandardOutput);
            errorReader = new StreamReaderWrapper(command.StandardError);

            ProcessTask = Task.Run(async () =>
            {
                var commandResult = await command.Task;

                if (!commandResult.Success)
                {
                    var error = command.StandardError.ReadToEnd();
                    throw new InvalidOperationException(error);
                }
            });
        }

        /// <summary>
        /// IFfProcess.
        /// </summary>
        public Task ProcessTask { get; }

        /// <summary>
        /// IFfProcess.
        /// </summary>
        public IProcessStreamReader OutputReader => outputReader;

        /// <summary>
        /// IFfProcess.
        /// </summary>
        public IProcessStreamReader ErrorReader => errorReader;

        /// <summary>
        /// Use to read all the output stream with one call.
        /// </summary>
        public async Task<string> ReadOutputToEndAsync()
        {
            await ProcessTask;
            var result = await command.StandardOutput.ReadToEndAsync();

            return result;
        }

        /// <summary>
        /// Use to read all the error stream with one call.
        /// </summary>
        public async Task<string> ReadErrorToEndAsync()
        {
            await ProcessTask;
            var result = await command.StandardError.ReadToEndAsync();

            return result;
        }
    }
}
