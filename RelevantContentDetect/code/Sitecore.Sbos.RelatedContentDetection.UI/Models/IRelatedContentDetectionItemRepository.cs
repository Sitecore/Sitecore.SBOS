using Sitecore.Data.Items;

namespace Sitecore.Sbos.RelatedContentDetection.UI.Models
{
    public interface IRelatedContentDetectionItemRepository
    {
        RelatedContentDetectionItem Get(Item contextItem);
    }
}