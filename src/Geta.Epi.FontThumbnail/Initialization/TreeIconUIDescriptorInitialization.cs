using EPiServer.Cms.Shell;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.Shell;
using Geta.Epi.FontThumbnail.DataAnnotations;
using System;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Geta.Epi.FontThumbnail.Initialization
{
    [InitializableModule]
    [ModuleDependency(typeof(InitializableModule))]
    public class TreeIconUIDescriptorInitialization : IInitializableModule
    {
        private static bool GloballyEnabled => "true".Equals(ConfigurationManager.AppSettings["FontThumbnail.EnableTreeIcons"], StringComparison.OrdinalIgnoreCase);

        public void Initialize(InitializationEngine context)
        {
            var registry = context.Locate.Advanced.GetInstance<UIDescriptorRegistry>();

            foreach (UIDescriptor descriptor in registry.UIDescriptors)
            {
                var treeIconAttribute = descriptor.ForType.GetCustomAttribute<TreeIcon>(true);
                var thumbnailIconAttribute = descriptor.ForType.GetCustomAttribute<ThumbnailIcon>(true);

                if (thumbnailIconAttribute != null)
                {
                    if ((GloballyEnabled || treeIconAttribute?.Ignore != false) || treeIconAttribute?.Ignore != false)
                    {
                        descriptor.IconClass = BuildClassnames(thumbnailIconAttribute, treeIconAttribute);
                    }
                }
            }
        }

        private static string BuildClassnames(ThumbnailIcon thumbnailIconAttribute, TreeIcon treeIconAttribute)
        {
            var builder = new StringBuilder();
            var icon = treeIconAttribute.Icon ?? thumbnailIconAttribute.Icon;
            var rotate = thumbnailIconAttribute.Rotate;
            var animation = treeIconAttribute.Animation;

            string className = ToDashCase(icon.ToString()).Replace("_", string.Empty);
            switch (icon)
            {
                case FontAwesome fa:
                    builder.AppendFormat("fa fa-{0} ", className);
                    break;
                case FontAwesome5Brands fab:
                    builder.AppendFormat("fab fa-{0} ", className);
                    break;
                case FontAwesome5Regular far:
                    builder.AppendFormat("far fa-{0} ", className);
                    break;
                case FontAwesome5Solid fas:
                    builder.AppendFormat("fas fa-{0} ", className);
                    break;
            }

            switch (rotate)
            {
                case Rotations.Rotate90:
                case Rotations.Rotate180:
                case Rotations.Rotate270:
                    builder.AppendFormat("fa-rotate-{0} ", (int)rotate);
                    break;
                case Rotations.FlipHorizontal:
                    builder.Append("fa-flip-horizontal ");
                    break;
                case Rotations.FlipVertical:
                    builder.Append("fa-flip-vertical ");
                    break;
            }

            switch (animation)
            {
                case Animations.Spin:
                    builder.Append("fa-spin ");
                    break;
                case Animations.Pulse:
                    builder.Append("fa-pulse ");
                    break;
            }

            builder.Append("fa-fw");

            return builder.ToString();
        }

        public static string ToDashCase(string input)
        {
            return string.Concat(input.Select((c, i) => i > 0 && char.IsUpper(c) && (!char.IsDigit(input[i - 1]) || !char.IsDigit(input[i - 2 > 0 ? i - 2 : 0])) ? "-" + c : c.ToString())).ToLower();
        }

        public void Uninitialize(InitializationEngine context)
        {
        }
    }
}
