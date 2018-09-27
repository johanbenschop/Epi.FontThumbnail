using System.Collections.Generic;
using System.Linq;
using EPiServer.Framework.Web.Resources;
using EPiServer.Shell;
using Geta.Epi.FontThumbnail.Initialization;

namespace Geta.Epi.FontThumbnail
{
    [ClientResourceProvider]
    public class ClientResourceProvider : IClientResourceProvider
    {
        public IEnumerable<ClientResource> GetClientResources()
        {
            //System.Diagnostics.Debugger.Break();

            // Only load the fonts when they're needed to save load time
            if (TreeIconUIDescriptorInitialization.EnabledAndInUse)
            {
                var clientResource = new ClientResource
                {
                    Name = "geta.fontawesome",
                    Path = Paths.ToClientResource("Geta.Epi.FontThumbnail", "ClientResources/css/all.min.css"),
                    ResourceType = ClientResourceType.Style,
                    Dependencies = new List<string> { "epi.shell.ui" } // epi.shell.ui ?
                };

                return new[]
                {
                    clientResource
                };
            }

            return Enumerable.Empty<ClientResource>();
        }
    }
}
