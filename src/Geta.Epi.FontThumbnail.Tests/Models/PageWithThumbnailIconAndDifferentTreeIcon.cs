using EPiServer.Core;
using Geta.Epi.FontThumbnail.DataAnnotations;

namespace Geta.Epi.FontThumbnail.Tests.Models
{
    [ThumbnailIcon(FontAwesome5Solid.Clock)]
    [TreeIcon(FontAwesome5Regular.Clock)]
    public class PageWithThumbnailIconAndDifferentTreeIcon : PageData
    {
    }
}
