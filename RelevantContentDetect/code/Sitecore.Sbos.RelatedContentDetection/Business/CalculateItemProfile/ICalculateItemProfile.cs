using Sitecore.Analytics.Data.Items;
using Sitecore.Sbos.RelevantContentDetect.Data;

namespace Sitecore.Sbos.RelevantContentDetect.Business.CalculateItemProfile
{
    public interface ICalculateItemProfile
    {
        void Calculate(Analytics.Tracking.Profile profile, IProfiledItemList list, string profileName, ProfileItem profileItem);
    }
}
