using System.Collections.Generic;
using EPiServer.Framework.Web.Resources;
using EPiServer.Shell;
using Geta.Epi.FontThumbnail.Initialization;

namespace Geta.Epi.FontThumbnail
{
    /// <summary>
    /// Provides the required resources needed for the font
    /// </summary>
    [ClientResourceProvider]
    internal class FontAwesomeClientResourceProvider : IClientResourceProvider
    {
        public IEnumerable<ClientResource> GetClientResources()
        {
            // Only load the fonts when they're needed to save load time
            if (TreeIconUIDescriptorInitialization.EnabledAndInUse)
            {
                yield return new ClientResource
                {
                    Name = "geta.fontawesome",
                    //Name = "epi.shell.ui",
                    Path = Paths.ToClientResource("Geta.Epi.FontThumbnail", "ClientResources/css/all.min.css"),
                    //Path = "https://use.fontawesome.com/releases/v5.5.0/css/all.css",
                    ResourceType = ClientResourceType.Style,
                };
            }
        }
    }
}
