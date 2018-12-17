using EPiServer.Core;
using Geta.Epi.FontThumbnail.DataAnnotations;

namespace Geta.Epi.FontThumbnail.Tests.Models
{
    [ThumbnailIcon(FontAwesome5Solid.Road)]
    public class PageWithOnlyThumbnailIcon : PageData
    {
    }
}
