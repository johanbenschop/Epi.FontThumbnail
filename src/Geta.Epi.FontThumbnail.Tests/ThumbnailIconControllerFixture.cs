using System;
using System.Configuration;
using System.IO;
using EPiServer.Web;
using Geta.Epi.FontThumbnail.Controllers;
using Geta.Epi.FontThumbnail.Settings;

namespace Geta.Epi.FontThumbnail.Tests
{
    public class ThumbnailIconControllerFixture : IDisposable
    {
        public ThumbnailIconController controller;
        public ThumbnailSettings settings;

        public ThumbnailIconControllerFixture()
        {
            var temporaryDirectory = VirtualPathUtilityEx.RebasePhysicalPath(Constants.DefaultCachePath);

            if (Directory.Exists(temporaryDirectory))
            {
                Directory.Delete(temporaryDirectory, true);
            }

            Directory.CreateDirectory(temporaryDirectory);

            var service = new FontThumbnailService();
            controller = new ThumbnailIconController(service);
            settings = new ThumbnailSettings
            {
                FontSize = Constants.DefaultFontSize,
                BackgroundColor = Constants.DefaultBackgroundColor,
                ForegroundColor = Constants.DefaultForegroundColor,
                Height = Constants.DefaultHeight,
                Width = Constants.DefaultWidth
            };
        }

        public void Dispose()
        {
        }
    }
}
