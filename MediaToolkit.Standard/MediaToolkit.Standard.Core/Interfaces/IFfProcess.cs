using System.Threading.Tasks;

namespace MediaToolkit.Standard.Core.Interfaces
{
    /// <summary>
    /// The interface for executed FF tool process.
    /// </summary>
    public interface IFfProcess
    {
        /// <summary>
        /// The task awaiting the process complete.
        /// </summary>
        Task ProcessTask { get; }

        /// <summary>
        /// The standard output.
        /// </summary>
        IProcessStreamReader OutputReader { get; }

        /// <summary>
        /// The standard error.
        /// </summary>
        IProcessStreamReader ErrorReader { get; }
    }
}
