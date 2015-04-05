using System;
using Aliencube.AppUtilities.Interfaces;
using FluentAssertions;
using NUnit.Framework;

namespace Aliencube.AppUtilities.Tests
{
    [TestFixture]
    public class AppTest
    {
        private IAppUtility _app;

        [SetUp]
        public void Init()
        {
            this._app = new AppUtility();
        }

        [TearDown]
        public void Cleanup()
        {
            if (this._app != null)
            {
                this._app.Dispose();
            }
        }

        [Test]
        [TestCase("~/Test", "AppUtilities.Tests")]
        [TestCase("/Test", "AppUtilities.Tests")]
        [TestCase("Test", "AppUtilities.Tests")]
        [TestCase(@"C:\Test", @"C:\Test")]
        [TestCase("../Test", "AppUtilities.Tests")]
        [TestCase("", "AppUtilities.Tests")]
        [TestCase(null, "AppUtilities.Tests")]
        public void GetFullPath_GivenVirtualPath_ReturnFullPath(string virtualPath, string expectedPath)
        {
            try
            {
                var result = this._app.MapPath(virtualPath);
                result.Should().Contain(expectedPath);
            }
            catch (ArgumentNullException ex)
            {
                ex.ParamName.Should().Be("virtualPath");
            }
            catch (ArgumentException ex)
            {
                ex.Message.Should().Be("Invalid path");
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        [TestCase("~/Test", "AppUtilities.Tests")]
        [TestCase("/Test", "AppUtilities.Tests")]
        [TestCase("Test", "AppUtilities.Tests")]
        [TestCase(@"C:\Test", @"C:\Test")]
        [TestCase("../Test", "AppUtilities.Tests")]
        [TestCase("", "AppUtilities.Tests")]
        [TestCase(null, "AppUtilities.Tests")]
        public void GetFullPath_GivenVirtualPath_ReturnTrueOrFalse(string virtualPath, string expectedPath)
        {
            string fullpath;
            var result = this._app.TryMapPath(virtualPath, out fullpath);

            if (result)
            {
                fullpath.Should().Contain(expectedPath);
            }
            else
            {
                fullpath.Should().BeNullOrWhiteSpace();
            }
        }
    }
}