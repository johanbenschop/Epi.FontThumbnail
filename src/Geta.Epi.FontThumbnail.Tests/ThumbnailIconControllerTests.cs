using Geta.Epi.FontThumbnail.Mvc;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using Xunit;

namespace Geta.Epi.FontThumbnail.Tests
{
    public class ThumbnailIconControllerTests : IClassFixture<ThumbnailIconControllerFixture>
    {
        private readonly ThumbnailIconControllerFixture fixture;

        public ThumbnailIconControllerTests(ThumbnailIconControllerFixture fixture)
        {
            this.fixture = fixture;
        }

        [Theory]
        [MemberData(nameof(GetEnumValues), typeof(FontAwesome5Solid))]
        public void TestGenerateThumbnail_FontAwesome5Solid(int value, Rotations rotation)
        {
            // Arrange
            fixture.settings.Character = value;
            fixture.settings.EmbeddedFont = "fa-solid-900.ttf";
            fixture.settings.Rotate = rotation;

            // Act
            var result = fixture.controller.GenerateThumbnail(fixture.settings) as ImageResult;

            // Assert
            Assert.NotNull(result?.Image);
            Assert.True(GetUniqueImageColors(result.Image).Count() > 1);
        }

        [Theory]
        [MemberData(nameof(GetEnumValues), typeof(FontAwesome5Regular))]
        public void TestGenerateThumbnail_FontAwesome5Regular(int value, Rotations rotation)
        {
            // Arrange
            fixture.settings.Character = value;
            fixture.settings.EmbeddedFont = "fa-regular-400.ttf";
            fixture.settings.Rotate = rotation;

            // Act
            var result = fixture.controller.GenerateThumbnail(fixture.settings) as ImageResult;

            // Assert
            Assert.NotNull(result?.Image);
            Assert.True(GetUniqueImageColors(result.Image).Count() > 1);
        }

        [Theory]
        [MemberData(nameof(GetEnumValues), typeof(FontAwesome5Brands))]
        public void TestGenerateThumbnail_FontAwesome5Brands(int value, Rotations rotation)
        {
            // Arrange
            fixture.settings.Character = value;
            fixture.settings.EmbeddedFont = "fa-brands-400.ttf";
            fixture.settings.Rotate = rotation;

            // Act
            var result = fixture.controller.GenerateThumbnail(fixture.settings) as ImageResult;

            // Assert
            Assert.NotNull(result?.Image);
            Assert.True(GetUniqueImageColors(result.Image).Count() > 1);
        }

        public static IEnumerable<object[]> GetEnumValues(Type type)
        {
            var values = Enum.GetValues(type);
            var rotationValues = Enum.GetValues(typeof(Rotations));

            foreach (var icon in values)
            {
                yield return new object[] { icon };

                //foreach (var rotation in rotationValues)
                //{
                //    yield return new object[] { icon, rotation };
                //}
            }
        }

        private static IEnumerable<Color> GetUniqueImageColors(Image image)
        {
            using (var bitmap = new Bitmap(image))
            {
                var bd = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                var arr = new byte[bd.Width * bd.Height * 3];
                var colors = new Color[bd.Width * bd.Height];
                Marshal.Copy(bd.Scan0, arr, 0, arr.Length);
                bitmap.UnlockBits(bd);

                for (int i = 0; i < colors.Length; i++)
                {
                    var start = i * 3;
                    colors[i] = Color.FromArgb(arr[start], arr[start + 1], arr[start + 2]);
                }

                return colors.Distinct();
            }
        }
    }
}
