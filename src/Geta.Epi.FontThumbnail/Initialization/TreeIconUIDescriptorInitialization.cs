using EPiServer.Cms.Shell;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.Shell;
using Geta.Epi.FontThumbnail.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Geta.Epi.FontThumbnail.Initialization
{
    [InitializableModule]
    [ModuleDependency(typeof(InitializableModule))]
    internal class TreeIconUIDescriptorInitialization : IInitializableModule
    {
        public static bool EnabledAndInUse { get; internal set; }

        public void Initialize(InitializationEngine context)
        {
            var registry = context.Locate.Advanced.GetInstance<UIDescriptorRegistry>();

            EnrichDescriptorsWithIconClass(registry.UIDescriptors);
        }

        internal void EnrichDescriptorsWithIconClass(IEnumerable<UIDescriptor> uIDescriptors)
        {
            foreach (var descriptor in uIDescriptors)
            {
                var thumbnailIconAttribute = descriptor.ForType.GetCustomAttribute<ThumbnailIcon>(true);
                var treeIconAttribute = descriptor.ForType.GetCustomAttribute<TreeIcon>(true);

                if (thumbnailIconAttribute == null && treeIconAttribute?.Icon == null)
                {
                    continue;
                }

                var globallyEnabled = "true".Equals(ConfigurationManager.AppSettings[Constants.EnableTreeIcons], StringComparison.OrdinalIgnoreCase);
                if (globallyEnabled && treeIconAttribute?.Ignore != true || treeIconAttribute?.Icon != null)
                {
                    descriptor.IconClass = BuildIconClassnames(thumbnailIconAttribute, treeIconAttribute);
                    EnabledAndInUse = true;
                }
            }
        }

        private static string BuildIconClassnames(ThumbnailIcon thumbnailIconAttribute, TreeIcon treeIconAttribute)
        {
            var icon = treeIconAttribute?.Icon ?? thumbnailIconAttribute?.Icon;
            if (icon == null)
                return string.Empty;

            var builder = new StringBuilder();
            var className = ToDashCase(icon.ToString()).Replace("_", string.Empty);

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

            switch (thumbnailIconAttribute?.Rotate)
            {
                case Rotations.Rotate90:
                case Rotations.Rotate180:
                case Rotations.Rotate270:
                    builder.AppendFormat("fa-rotate-{0} ", (int)thumbnailIconAttribute.Rotate);
                    break;
                case Rotations.FlipHorizontal:
                    builder.Append("fa-flip-horizontal ");
                    break;
                case Rotations.FlipVertical:
                    builder.Append("fa-flip-vertical ");
                    break;
            }

            switch (treeIconAttribute?.Animation)
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

        private static string ToDashCase(string input)
        {
            return string.Concat(input.Select((c, i) => i > 0 && char.IsUpper(c) && (!char.IsDigit(input[i - 1]) || !char.IsDigit(input[i - 2 > 0 ? i - 2 : 0])) ? "-" + c : c.ToString())).ToLower();
        }

        public void Uninitialize(InitializationEngine context)
        {
        }
    }
}
