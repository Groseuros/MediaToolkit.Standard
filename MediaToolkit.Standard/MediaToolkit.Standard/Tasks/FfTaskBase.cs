using System.Collections.Generic;
using System.Threading.Tasks;
using MediaToolkit.Standard.Core.Interfaces;
using MediaToolkit.Standard.Services;

namespace MediaToolkit.Standard.Tasks
{
    /// <summary>
    /// Common interface for FF tasks.
    /// </summary>
    public abstract class FfTaskBase<TResult>
    {
        /// <summary>
        /// Override to create the call parameters.
        /// </summary>
        public abstract IList<string> CreateArguments();

        /// <summary>
        /// Override to execute the command.
        /// </summary>
        public abstract Task<TResult> ExecuteCommandAsync(IFfProcess ffProcess);

        /// <summary>
        /// Internal method for execution with the service instance.
        /// </summary>
        internal abstract Task<TResult> ExecuteAsync(MediaToolkitService ffService);
    }
}
