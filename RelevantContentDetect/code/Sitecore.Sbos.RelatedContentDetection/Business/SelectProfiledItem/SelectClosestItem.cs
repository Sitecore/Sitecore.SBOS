using System.Linq;
using Sitecore.Sbos.RelevantContentDetect.Business.CalculateItemProfile;
using Sitecore.Sbos.RelevantContentDetect.Data;

namespace Sitecore.Sbos.RelevantContentDetect.Business.SelectProfiledItem
{
    public class SelectClosestItem : SelectFuzzyProfiledItem
    {
        public SelectClosestItem()
            : base(new CalculateDistance())
        {
        }

        public override string StringKey
        {
            get { return stringKey; }
        }
        public const string stringKey = "closest";

        public override IProfiledItemResult GetProfiledItem(IProfiledItemList list)
        {
            var resultItemList = list.Where(pi => pi.ContentProfile != null);
            if (resultItemList.Count() == 0)
            {
                return new ProfiledItemResult(null, "No Profiled Items"); 
            }
            var resultItem = resultItemList
                .OrderBy(i =>
                {
                    var profile = i.ProfiledItemCalculation as IProfiledItemDistance;
                    if (profile == null)
                    {
                        return double.PositiveInfinity;
                    }
                    return profile.Distance;
                }).FirstOrDefault();
            var resultDistance = resultItem.ProfiledItemCalculation as IProfiledItemDistance;
            var resultMessage = string.Format("Calculated distance {0:N2} to closest item {1}", resultDistance.Distance, resultItem.Item.Name);

            return new ProfiledItemResult(resultItem, resultMessage);
        }

        public override IProfiledItemResult GetFuzzyProfiledItem(IProfiledItemList list)
        {
            return GetProfiledItem(list);
        }
    }
}
