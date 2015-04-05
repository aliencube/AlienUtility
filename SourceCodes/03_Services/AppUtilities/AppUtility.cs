using System;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web.Hosting;
using Aliencube.AppUtilities.Interfaces;

namespace Aliencube.AppUtilities
{
    /// <summary>
    /// This represents the <c>AppUtility</c> class entity.
    /// </summary>
    public class AppUtility : IAppUtility
    {
        private const string PATH_TRAVERSAL = @"\.\.[\\/]";
        private const string PATH_ABSOLUTE = @"^[a-z]\:[\\/]";
        private const string PATH_BIN = @"[\\/]bin([\\/].+)?$";

        private Regex _pathTraversal;
        private Regex _pathAbsolute;
        private Regex _pathBin;

        private bool _disposed;

        /// <summary>
        /// Initialises a new instance of the <c>AppUtility</c> class.
        /// </summary>
        public AppUtility()
        {
            this.InitRegex();
        }

        /// <summary>
        /// Initialises regular expression instances.
        /// </summary>
        private void InitRegex()
        {
            this._pathTraversal = new Regex(PATH_TRAVERSAL, RegexOptions.IgnoreCase | RegexOptions.Compiled);
            this._pathAbsolute = new Regex(PATH_ABSOLUTE, RegexOptions.IgnoreCase | RegexOptions.Compiled);
            this._pathBin = new Regex(PATH_BIN, RegexOptions.IgnoreCase | RegexOptions.Compiled);
        }

        /// <summary>
        /// Maps a virtual path to a physical path.
        /// </summary>
        /// <param name="virtualPath">Virtual path starting with "~/".</param>
        /// <returns>Returns the physical path mapped.</returns>
        public string MapPath(string virtualPath)
        {
            if (String.IsNullOrWhiteSpace(virtualPath))
            {
                throw new ArgumentNullException("virtualPath");
            }

            if (this._pathAbsolute.IsMatch(virtualPath))
            {
                return virtualPath;
            }

            var path = virtualPath;
            if (this._pathTraversal.IsMatch(path))
            {
                throw new ArgumentException("Invalid path");
            }

            if (path.StartsWith("/"))
            {
                path = "~" + path;
            }

            if (path.StartsWith("~/"))
            {
                path = path.Replace("~/", "/").Replace("/", @"\");
            }
            else
            {
                throw new ArgumentException("Invalid path");
            }

            string fullpath;
            var directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (!directory.StartsWith(Environment.ExpandEnvironmentVariables("%SystemRoot%")))
            {
                directory = this._pathBin.Replace(directory, "");
                fullpath = Path.GetFullPath(directory + path);
            }
            else
            {
                fullpath = HostingEnvironment.MapPath("~" + path);
            }
            return fullpath;
        }

        /// <summary>
        /// Maps a virtual path to a physical path.
        /// </summary>
        /// <param name="virtualPath">Virtual path starting with "~/".</param>
        /// <param name="fullpath">Physical path mapped. If the return value is <c>False</c>, this will be <c>null</c>.</param>
        /// <returns>Returns <c>True</c>, if the mapped physical path actually exists; otherwise returns <c>False</c>.</returns>
        public bool TryMapPath(string virtualPath, out string fullpath)
        {
            try
            {
                fullpath = this.MapPath(virtualPath);
                if (Directory.Exists(fullpath))
                {
                    return true;
                }

                fullpath = null;
                return false;

            }
            catch
            {
                fullpath = null;
                return false;
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (this._disposed)
            {
                return;
            }

            this._disposed = true;
        }
    }
}