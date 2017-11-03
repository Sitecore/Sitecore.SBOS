using System.Linq;
using Sitecore.Analytics.Data;
using Sitecore.Analytics.Data.Items;
using Sitecore.Data.Fields;
using Sitecore.Sbos.RelevantContentDetect.Data;

namespace Sitecore.Sbos.RelevantContentDetect.Business.CalculateItemProfile
{
    public class CalculateItemProfile : ICalculateItemProfile
    {
        protected const string TrackingFieldName = "__Tracking";

        public virtual void Calculate(Analytics.Tracking.Profile profile, IProfiledItemList list, string profileName, ProfileItem profileItem)
        {
            list.ToList().ForEach(item => CalculateProfiledItem(profile, item, profileName, profileItem));
        }

        private static void CalculateProfiledItem(Analytics.Tracking.Profile profile, IProfiledItem item, string profileName, ProfileItem profileItem)
        {

            Field field = item.Item.Fields[TrackingFieldName];
            if (field == null)
            {
                return;
            }

            var trackingField = new TrackingField(field);
            //ContentProfile contentProfile = trackingField.GetProfile(profileItem);
            ContentProfile contentProfile = trackingField.Profiles.FirstOrDefault(p => p.Name == profileName);
            
            //var visitProfile = visit.GetOrCreateProfile(profileName);
            
            if (contentProfile == null || !contentProfile.IsSavedInField)
            {
                return;
            }

            item.SetContentProfile(contentProfile);

            return;

        }
    }

}
