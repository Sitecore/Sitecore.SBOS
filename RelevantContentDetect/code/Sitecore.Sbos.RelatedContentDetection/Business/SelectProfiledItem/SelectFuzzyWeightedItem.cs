using System;
using System.Linq;
using Sitecore.Sbos.RelevantContentDetect.Business.CalculateItemProfile;
using Sitecore.Sbos.RelevantContentDetect.Data;

namespace Sitecore.Sbos.RelevantContentDetect.Business.SelectProfiledItem
{
    public class SelectFuzzyWeightedItem : SelectFuzzyProfiledItem
    {
        public SelectFuzzyWeightedItem()
            : base(new CalculateWeight())
        {
        }

        public override string StringKey
        {
            get { return stringKey; }
        }
        public const string stringKey = "fuzzy weight";

        public override IProfiledItemResult GetProfiledItem(IProfiledItemList list)
        {

            var resultItemList = list.Where(pi => pi.ContentProfile != null);
            if (resultItemList.Count() == 0)
            {
                return new ProfiledItemResult(null, "No Profiled Items");
            }
            var resultItem = resultItemList.OrderByDescending(i =>
            {
                var a = i.ProfiledItemCalculation as IProfiledItemWeight;
                return a.Weight;
            }).FirstOrDefault();

            if (resultItem == null)
            {
                return new ProfiledItemResult(null, "Error selecting weighted item");
            }

            var result = (IProfiledItemWeight)resultItem.ProfiledItemCalculation;

            var resultMessage = string.Format("Selected highest weighted profiled item");

            return new ProfiledItemResult(resultItem, resultMessage);
        }

        public override IProfiledItemResult GetFuzzyProfiledItem(IProfiledItemList list)
        {
            double fuzzy = new Random().NextDouble();

            double sum = 0.0d;

            var resultItemList = list.Where(pi => pi.ContentProfile != null);
            if (resultItemList.Count() == 0)
            {
                return new ProfiledItemResult(null, "No Profiled Items");
            }
            var resultItem = resultItemList.FirstOrDefault(item =>
            {
                var profile = item.ProfiledItemCalculation as IProfiledItemWeight;
                sum = sum + profile.Weight;
                return (fuzzy <= sum);
            });

            if (resultItem == null)
            {
                return new ProfiledItemResult(null, "Error selecting fuzzy weighted item");
            }

            var result = (IProfiledItemWeight)resultItem.ProfiledItemCalculation;

            var resultMessage = string.Format("Random roll is {0:N2} selecting {1} with a {2:P2} weight", fuzzy * 100d, resultItem.Item.DisplayName, result.Weight);

            return new ProfiledItemResult(resultItem, resultMessage);
        }

        

    }
}
