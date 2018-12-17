using EPiServer.Core;
using Geta.Epi.FontThumbnail.DataAnnotations;

namespace Geta.Epi.FontThumbnail.Tests.Models
{
    [ThumbnailIcon(FontAwesome5Solid.Anchor)]
    [TreeIcon(Ignore = true)]
    public class PageWithThumbnailIconAndTreeIconOnIgnore : PageData
    {
    }
}
