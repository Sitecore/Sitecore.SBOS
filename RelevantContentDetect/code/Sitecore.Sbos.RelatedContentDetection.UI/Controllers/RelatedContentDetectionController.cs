using System.Web.Mvc;
using Sitecore.Mvc.Controllers;
using Sitecore.Mvc.Presentation;
using Sitecore.Sbos.RelatedContentDetection.UI.Models;

namespace Sitecore.Sbos.RelatedContentDetection.UI.Controllers
{
    public class RelatedContentDetectionController : SitecoreController
    {
        private IRelatedContentDetectionItemRepository repository;

        public RelatedContentDetectionController() : this(new RelatedContentDetectionItemRepository())
        {
        }
        public RelatedContentDetectionController(IRelatedContentDetectionItemRepository repository)
        {
            this.repository = repository;
        }
        // GET: RelatedContentDetection
        public ActionResult RelatedContentDetectionList()
        {
            return View(repository.Get(RenderingContext.Current.ContextItem));
        }
    }
}