using EPiServer.DataAnnotations;
using System;

namespace Geta.Epi.FontThumbnail.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ThumbnailIcon : ImageUrlAttribute
    {
        internal Enum Icon { get; set; }
        internal Rotations Rotate { get; set; }

        public ThumbnailIcon(FontAwesome icon, string backgroundColor = "", string foregroundColor = "", int fontSize = -1, Rotations rotate = Rotations.None) 
            : base(ImageUrlHelper.GetUrl(icon, backgroundColor, foregroundColor, fontSize, rotate))
        {
            Icon = icon;
            Rotate = rotate;
        }

        public ThumbnailIcon(FontAwesome5Brands icon, string backgroundColor = "", string foregroundColor = "", int fontSize = -1, Rotations rotate = Rotations.None) 
            : base(ImageUrlHelper.GetUrl(icon, backgroundColor, foregroundColor, fontSize, rotate))
        {
            Icon = icon;
            Rotate = rotate;
        }

        public ThumbnailIcon(FontAwesome5Regular icon, string backgroundColor = "", string foregroundColor = "", int fontSize = -1, Rotations rotate = Rotations.None) 
            : base(ImageUrlHelper.GetUrl(icon, backgroundColor, foregroundColor, fontSize, rotate))
        {
            Icon = icon;
            Rotate = rotate;
        }

        public ThumbnailIcon(FontAwesome5Solid icon, string backgroundColor = "", string foregroundColor = "", int fontSize = -1, Rotations rotate = Rotations.None) 
            : base(ImageUrlHelper.GetUrl(icon, backgroundColor, foregroundColor, fontSize, rotate))
        {
            Icon = icon;
            Rotate = rotate;
        }

        public ThumbnailIcon(string customFont, int character, string backgroundColor = "", string foregroundColor = "", int fontSize = -1) 
            : base(ImageUrlHelper.GetUrl(customFont, character, backgroundColor, foregroundColor, fontSize))
        {
        }
    }
}