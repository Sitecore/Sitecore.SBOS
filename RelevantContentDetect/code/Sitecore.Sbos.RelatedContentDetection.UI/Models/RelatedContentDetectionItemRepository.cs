using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Items;
using Sitecore.Foundation.SitecoreExtensions.Extensions;
using Sitecore.Mvc.Presentation;

namespace Sitecore.Sbos.RelatedContentDetection.UI.Models
{
    public class RelatedContentDetectionItemRepository : IRelatedContentDetectionItemRepository
    {
        public RelatedContentDetectionItem Get(Item contextItem)
        {
            var items = contextItem.Children.Where((i => i.IsDerived(Templates.RelatedContentDetectionItem.ID)));

            return new RelatedContentDetectionItem()
            {
                Title = "Needs to be replaced",
                Summary = "Needs to be replaced"
            };
        }
    }
}