using System.Linq;
using Sitecore.Analytics.Data.Items;
using Sitecore.Sbos.RelevantContentDetect.Data;

namespace Sitecore.Sbos.RelevantContentDetect.Business.CalculateItemProfile
{

    public class CalculateWeight : CalculateDistance, ICalculateWeight
    {
        public CalculateWeight()
            : base()
        {
        }
        public override void Calculate(Analytics.Tracking.Profile profile, IProfiledItemList list, string profileName, ProfileItem profileItem)
        {
            base.Calculate(profile, list, profileName, profileItem);
            CalculateRelevantContentItemWeight(list);
        }

        private static void CalculateRelevantContentItemWeight(IProfiledItemList list)
        {
            double gravitySum = list.Where(pi => pi.ContentProfile != null).Sum(item => 
                {
                    var distance = item.ProfiledItemCalculation as IProfiledItemDistance;                    
                    return distance.Gravity;
                });
            list.Where(pi => pi.ContentProfile != null).ToList().ForEach(item => CalculateRelevantContentItemWeight(item, gravitySum));
        }

        private static void CalculateRelevantContentItemWeight(IProfiledItem item, double gravitySum)
        {
            var distance = item.ProfiledItemCalculation as IProfiledItemDistance;
            var weight = (gravitySum > 0d) ? (distance.Gravity / gravitySum) : 0d;
            item.SetCalculation(new ProfiledItemWeight(weight, distance));
        }
    }
}
