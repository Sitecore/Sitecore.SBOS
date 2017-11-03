using System;
using System.Linq;
using Sitecore.Sbos.RelevantContentDetect.Business.CalculateItemProfile;
using Sitecore.Sbos.RelevantContentDetect.Data;

namespace Sitecore.Sbos.RelevantContentDetect.Business.SelectProfiledItem
{
    public class SelectFuzzyAssociationItem : SelectFuzzyProfiledItem
    {
        public SelectFuzzyAssociationItem()
            : base(new CalculateAssociation())
        {
        }
        
        public override string StringKey
        {
            get { return stringKey; }
        }
        public const string stringKey = "fuzzy association";

        public override IProfiledItemResult GetProfiledItem(IProfiledItemList list)
        {                       
            var resultItemList = list.Where(pi => pi.ContentProfile != null);
            if (resultItemList.Count() == 0)
            {
                return new ProfiledItemResult(null, "No Profiled Items"); 
            }
            var resultItem = resultItemList.OrderByDescending(i => {
                var a = i.ProfiledItemCalculation as IProfiledItemAssociation;
                return a.Association;
            }).FirstOrDefault();

            if (resultItem == null )
            {
                return new ProfiledItemResult(null, "Error selecting fuzzy associated item");
            }

            var resultMessage = string.Format("Selected most associated item");

            return new ProfiledItemResult(resultItem, resultMessage);
        }



        public override IProfiledItemResult GetFuzzyProfiledItem(IProfiledItemList list)
        {
            var resultItemList = list.Where(pi => pi.ContentProfile != null);
            if (resultItemList.Count() == 0)
            {
                return new ProfiledItemResult(null, "No Profiled Items"); 
            }


            var fuzzy = new Random().NextDouble();
            double sum = 0.0d;
            var resultItem = resultItemList.FirstOrDefault(item =>
            {
                var profile = item.ProfiledItemCalculation as IProfiledItemAssociation;
                sum += profile.Association;
                return (fuzzy < sum);
            });

            if (resultItem == null)
            {
                return new ProfiledItemResult(null, "Error selecting fuzzy associated item");
            }

            var resultAssociation = resultItem.ProfiledItemCalculation as IProfiledItemAssociation;

            var resultMessage = string.Format("Random roll is {0:N2} selecting {1} with a {2:P2} association", fuzzy * 100d, resultItem.Item.DisplayName, resultAssociation.Association);

            return new ProfiledItemResult(resultItem, resultMessage);
        }

       

    }
}
