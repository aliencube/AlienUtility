using System;

namespace Aliencube.AppUtilities.Interfaces
{
    /// <summary>
    /// This provides interfaces to the <c>AppUtility</c> class.
    /// </summary>
    public interface IAppUtility : IDisposable
    {
        /// <summary>
        /// Maps a virtual path to a physical path.
        /// </summary>
        /// <param name="virtualPath">Virtual path starting with "~/".</param>
        /// <returns>Returns the physical path mapped.</returns>
        string MapPath(string virtualPath);

        /// <summary>
        /// Maps a virtual path to a physical path.
        /// </summary>
        /// <param name="virtualPath">Virtual path starting with "~/".</param>
        /// <param name="fullpath">Physical path mapped.</param>
        /// <returns>Returns <c>True</c>, if the mapped physical path actually exists; otherwise returns <c>False</c>.</returns>
        bool TryMapPath(string virtualPath, out string fullpath);
    }
}