using Geta.Epi.FontThumbnail.Controllers;
using Geta.Epi.FontThumbnail.Mvc;
using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using Xunit;

namespace Geta.Epi.FontThumbnail.Tests
{
    public class ThumbnailIconControllerTest
    {
        public ThumbnailIconControllerTest()
        {
            ConfigurationManager.AppSettings["FontThumbnail.CachePath"] = @"C:\Dev\TestOutput\";
        }

        [Fact]
        public void TestGenerateThumbnail_FontAwesome5Rotation()
        {
            // Arrange
            var service = new FontThumbnailService();
            var controller = new ThumbnailIconController(service);
            var settings = new Settings.ThumbnailSettings
            {
                FontSize = Constants.DefaultFontSize,
                BackgroundColor = Constants.DefaultBackgroundColor,
                ForegroundColor = Constants.DefaultForegroundColor,
                Height = Constants.DefaultHeight,
                Width = Constants.DefaultWidth,
                EmbeddedFont = "fa-brands-400.ttf"
            };

            // Act
            settings.Character = (int)FontAwesome5Brands.FontAwesome;

            settings.Rotate = Rotations.Rotate90;
            //controller.GenerateThumbnail(settings);
            RenderAndSave(service, settings);

            settings.Rotate = Rotations.Rotate180;
            //controller.GenerateThumbnail(settings);
            RenderAndSave(service, settings);

            settings.Rotate = Rotations.Rotate270;
            //controller.GenerateThumbnail(settings);
            RenderAndSave(service, settings);

            settings.Rotate = Rotations.FlipHorizontal;
            //controller.GenerateThumbnail(settings);
            RenderAndSave(service, settings);

            settings.Rotate = Rotations.FlipVertical;
            //controller.GenerateThumbnail(settings);
            RenderAndSave(service, settings);

            settings.Rotate = Rotations.None;
            //controller.GenerateThumbnail(settings);
            RenderAndSave(service, settings);
        }

        private static void RenderAndSave(FontThumbnailService service, Settings.ThumbnailSettings settings)
        {
            var stream = service.GenerateImage(settings);
            using (var fileStream = File.Create($@"C:\Dev\TestOutput\{settings.Character}-{settings.Rotate}.png"))
            {
                stream.Seek(0, SeekOrigin.Begin);
                stream.CopyTo(fileStream);
                stream.Dispose();
                stream.Close();
            }
        }

        [Fact]
        public void TestGenerateThumbnail_FontAwesome5Brands()
        {
            // Arrange
            var service = new FontThumbnailService();
            var controller = new ThumbnailIconController(service);
            var values = (FontAwesome5Brands[])Enum.GetValues(typeof(FontAwesome5Brands));
            var settings = new Settings.ThumbnailSettings
            {
                FontSize = Constants.DefaultFontSize,
                BackgroundColor = Constants.DefaultBackgroundColor,
                ForegroundColor = Constants.DefaultForegroundColor,
                Height = Constants.DefaultHeight,
                Width = Constants.DefaultWidth,
                EmbeddedFont = "fa-brands-400.ttf"
            };

            // Act
            foreach (var item in values)
            {
                settings.Character = (int)item;
                //var image = service.GenerateImage(settings);
                var result = controller.GenerateThumbnail(settings) as ImageResult;
            }
        }

        [Fact]
        public void TestGenerateThumbnail_FontAwesome5Regular()
        {
            // Arrange
            var service = new FontThumbnailService();
            var controller = new ThumbnailIconController(service);
            var values = (FontAwesome5Regular[])Enum.GetValues(typeof(FontAwesome5Regular));
            var settings = new Settings.ThumbnailSettings
            {
                FontSize = Constants.DefaultFontSize,
                BackgroundColor = Constants.DefaultBackgroundColor,
                ForegroundColor = Constants.DefaultForegroundColor,
                Height = Constants.DefaultHeight,
                Width = Constants.DefaultWidth,
                EmbeddedFont = "fa-regular-400.ttf"
            };

            // Act
            foreach (var item in values)
            {
                settings.Character = (int)item;
                //var image = service.GenerateImage(settings);
                var result = controller.GenerateThumbnail(settings) as ImageResult;
            }
        }

        [Fact]
        public void TestGenerateThumbnail_FontAwesome5Solid()
        {
            // Arrange
            var service = new FontThumbnailService();
            var controller = new ThumbnailIconController(service);
            var values = (FontAwesome5Solid[])Enum.GetValues(typeof(FontAwesome5Solid));
            var settings = new Settings.ThumbnailSettings
            {
                FontSize = Constants.DefaultFontSize,
                BackgroundColor = Constants.DefaultBackgroundColor,
                ForegroundColor = Constants.DefaultForegroundColor,
                Height = Constants.DefaultHeight,
                Width = Constants.DefaultWidth,
                EmbeddedFont = "fa-solid-900.ttf"
            };

            // Act
            foreach (var item in values)
            {
                settings.Character = (int)item;
                //var image = service.GenerateImage(settings);
                var result = controller.GenerateThumbnail(settings) as ImageResult;
            }
        }
    }
}
