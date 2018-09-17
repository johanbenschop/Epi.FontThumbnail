using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geta.Epi.FontThumbnail.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class TreeIcon : Attribute
    {
        internal Enum Icon { get; set; }

        public Animations Animation { get; set; }

        /// <summary>
        /// Overwrites the global setting
        /// </summary>
        public bool Ignore { get; set; }

        public TreeIcon()
        {
        }

        public TreeIcon(FontAwesome icon)
        {
            Icon = icon;
        }

        public TreeIcon(FontAwesome5Brands icon)
        {
            Icon = icon;
        }

        public TreeIcon(FontAwesome5Regular icon)
        {
            Icon = icon;
        }

        public TreeIcon(FontAwesome5Solid icon)
        {
            Icon = icon;
        }
    }
}
